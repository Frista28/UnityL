using System;
using System.Collections;
using L1_3.Scripts.Game.Utilities.DataManagement.SaveData;

namespace L1_3.Scripts.Game.Utilities.DataManagement.SaveLoadService
{
    public interface ISaveLoadService
    {
        IEnumerator Load<TData>(Action<TData> onLoad) where TData : ISaveData;
        IEnumerator Save<TData>(TData data) where TData : ISaveData;
        IEnumerator Remove<TData>() where TData : ISaveData;
        IEnumerator Exists<TData>(Action<bool> onExistsResult) where TData : ISaveData;
    }
}