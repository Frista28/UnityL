using L1_3.Scripts.Game.Utilities.DataManagement.SaveData;

namespace L1_3.Scripts.Game.Utilities.DataManagement.KeyStorage
{
    public interface IDataKeysStorage
    {
        string GetKeyFor<TData>() where TData : ISaveData;
    }
}