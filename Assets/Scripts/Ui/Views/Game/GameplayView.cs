using Service.Score;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.Views.Game
{
    public class GameplayView : BasePresenter
    {
        [SerializeField] private Button pauseButton;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI highScoreText;
        private Data _data;

        public override void Show(IPresenterData data = null)
        {
            base.Show(data);
            _data = (Data)data;
            pauseButton.onClick.AddListener(PauseGame);
            SetScore(_data.ScoreService.Score);
            SetHighScore(_data.ScoreService.HighScore);

            _data.ScoreService.OnScoreChanged += SetScore;
            _data.ScoreService.OnHighScoreChanged += SetHighScore;
        }

        private void SetScore(int score)
        {
            scoreText.text = $"Score: {score}";
        }

        private void SetHighScore(int score)
        {
            highScoreText.text = $"High Score: {score}";
        }

        private void PauseGame()
        {
            _data.MainFlow.PauseGame(true);
        }

        public override void Close()
        {
            base.Close();
            pauseButton.onClick.RemoveListener(PauseGame);
            _data.ScoreService.OnScoreChanged -= SetScore;
            _data.ScoreService.OnHighScoreChanged -= SetHighScore;
        }

        public class Data : IPresenterData
        {
            public Data(MainFlow mainFlow, ScoreService scoreService)
            {
                MainFlow = mainFlow;
                ScoreService = scoreService;
            }

            public MainFlow MainFlow { get; }
            public ScoreService ScoreService { get; }
        }
    }
}