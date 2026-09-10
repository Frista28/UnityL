using System;
using System.Collections.Generic;
using L1_3.Scripts.Game.Utilities.DataManagement.SaveData;

namespace L1_3.Scripts.Game.Utilities.DataManagement.KeyStorage
{
    public class MapDataKeysStorage : IDataKeysStorage
    {
        private readonly Dictionary<Type, string> _keys = new()
        {
            {typeof(PlayerData), "PlayerData" },
        };

        public string GetKeyFor<TData>() where TData : ISaveData
            => _keys[typeof(TData)];
    }
}