using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Service.Skin
{
    public class SkinService
    {
        private const string SkinKey = "SkinKey";
        private const string UnlockedSkinIndexKey = "UnlockedSkinsKey";
        private readonly BallSkinAssetsConfig _ballSkinAssetsConfig;

        public SkinService(BallSkinAssetsConfig ballSkinAssetsConfig)
        {
            _ballSkinAssetsConfig = ballSkinAssetsConfig;
            if (!PlayerPrefs.HasKey(SkinKey))
            {
                UnlockSkin();
                SetDefaultSkin();
            }
            else
            {
                SetSkin(PlayerPrefs.GetString(SkinKey));
            }
        }

        public List<Tuple<bool, BallSkinData>> GetSkinsData()
        {
            int unlockedSkinIndex = PlayerPrefs.GetInt(UnlockedSkinIndexKey, 0);
            return _ballSkinAssetsConfig.BallSkins
                .Select((skin, i) => new Tuple<bool, BallSkinData>(i >= unlockedSkinIndex, skin)).ToList();
        }

        public BallSkinData GetCurrentSkinData()
        {
            return _ballSkinAssetsConfig.GetMaterialByKey(PlayerPrefs.GetString(SkinKey));
        }

        private void SetDefaultSkin()
        {
            SetSkin(_ballSkinAssetsConfig.BallSkins[0].key);
        }

        public void SetSkin(string key)
        {
            PlayerPrefs.SetString(SkinKey, key);
            PlayerPrefs.Save();
        }

        public void UnlockSkin()
        {
            int index = PlayerPrefs.GetInt(UnlockedSkinIndexKey, 0);
            if (index >= _ballSkinAssetsConfig.BallSkins.Length)
            {
                return;
            }

            PlayerPrefs.SetInt(UnlockedSkinIndexKey, index + 1);
            PlayerPrefs.Save();
        }
    }
}