using Gameplay;
using Service;
using Service.Progress;
using Service.Score;
using Service.Skin;
using Ui;
using UnityEngine;

public class SceneContextFacade : MonoBehaviour
{
    [SerializeField] private PresenterService viewService;
    [SerializeField] private GameplayController gameplayControllerPrefab;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private ProgressConfig progressConfig;
    [SerializeField] private BallSkinAssetsConfig ballSkinAssetsConfig;
    public GameplayController GameplayControllerPrefab => gameplayControllerPrefab;
    public Camera MainCamera => mainCamera;
    public PresenterService ViewService => viewService;
    public ScoreService ScoreService { get; private set; }
    public ProgressService ProgressService { get; private set; }

    public SkinService SkinService { get; private set; }

    private void Start()
    {
        Application.targetFrameRate = 60;
        
        ScoreService = new ScoreService();
        SkinService = new SkinService(ballSkinAssetsConfig);
        ProgressService = new ProgressService(progressConfig, SkinService);
        MainFlow mainFlow = new(this);
        mainFlow.ShowMainView();
    }
}