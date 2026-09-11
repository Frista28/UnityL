using System.Collections.Generic;
using L1_3.Scripts.Game.Systems.Score;
using L1_3.Scripts.Game.Systems.Wallet;
using L1_3.Scripts.Game.Utilities.Reactive;

namespace L1_3.Scripts.Game.Utilities.DataManagement.SaveData
{
    public class PlayerData : ISaveData
    {
        public Dictionary<CurrencyTypes, int> WalletData;

        public Dictionary<ScoreTypes, int> Scores;
    }
}