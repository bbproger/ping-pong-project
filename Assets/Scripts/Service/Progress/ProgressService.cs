using Service.Skin;
using UnityEngine;

namespace Service.Progress
{
    public class ProgressService
    {
        private const string ProgressKey = "Progress";

        private readonly ProgressConfig _progressConfig;
        private readonly SkinService _skinService;

        public ProgressService(ProgressConfig progressConfig, SkinService skinService)
        {
            _skinService = skinService;
            _progressConfig = progressConfig;
        }

        public void AddProgress()
        {
            int newProgress = PlayerPrefs.GetInt(ProgressKey, 0) + _progressConfig.ProgressPerLevel;
            if (newProgress >= _progressConfig.ProgressPerLevelUp)
            {
                _skinService.UnlockSkin();
                newProgress = 0;
            }

            PlayerPrefs.SetInt(ProgressKey, newProgress);
            PlayerPrefs.Save();
        }
    }
}