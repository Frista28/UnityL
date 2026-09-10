using L1_3.Scripts.Game.Utilities.DataManagement.SaveData;

namespace L1_3.Scripts.Game.Utilities.DataManagement.DataProvider
{
    public interface IDataReader<in TData> where TData : ISaveData
    {
        void ReadFrom(TData data);
    }
}