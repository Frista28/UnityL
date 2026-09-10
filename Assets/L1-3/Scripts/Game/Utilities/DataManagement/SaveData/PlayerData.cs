using System.Collections.Generic;
using L1_3.Scripts.Game.Systems.Wallet;

namespace L1_3.Scripts.Game.Utilities.DataManagement.SaveData
{
    public class PlayerData : ISaveData
    {
        public Dictionary<CurrencyTypes, int> WalletData;
    }
}