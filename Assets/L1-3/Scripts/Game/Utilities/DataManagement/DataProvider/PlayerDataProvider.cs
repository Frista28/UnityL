using System;
using System.Collections.Generic;
using L1_3.Scripts.Game.Systems.Score;
using L1_3.Scripts.Game.Systems.Wallet;
using L1_3.Scripts.Game.Systems.Wallet.Configs;
using L1_3.Scripts.Game.Utilities.ConfigsManagement;
using L1_3.Scripts.Game.Utilities.DataManagement.SaveData;
using L1_3.Scripts.Game.Utilities.DataManagement.SaveLoadService;

namespace L1_3.Scripts.Game.Utilities.DataManagement.DataProvider
{
    public class PlayerDataProvider : DataProvider<PlayerData>
    {
        private readonly ConfigsProviderService _configsProviderService;

        public PlayerDataProvider(
            ISaveLoadService saveLoadService, 
            ConfigsProviderService configsProviderService) : base(saveLoadService)
        {
            _configsProviderService = configsProviderService;
        }

        protected override PlayerData GetOriginData()
        {
            return new PlayerData()
            {
                WalletData = InitWalletData(),
                Scores = InitScoreData(),
            };
        }

        private Dictionary<CurrencyTypes, int> InitWalletData()
        {
            Dictionary<CurrencyTypes, int> walletData = new();

            StartWalletConfig walletConfig = _configsProviderService.GetConfig<StartWalletConfig>();

            foreach (CurrencyTypes currencyType in Enum.GetValues(typeof(CurrencyTypes)))
                walletData[currencyType] = walletConfig.GetValueFor(currencyType);

            return walletData;
        }
        
        private Dictionary<ScoreTypes, int> InitScoreData()
        {
            Dictionary<ScoreTypes, int> scoreData = new();

            foreach (ScoreTypes scoreTypes in Enum.GetValues(typeof(ScoreTypes)))
                scoreData[scoreTypes] = 0;

            return scoreData;
        }
    }
}