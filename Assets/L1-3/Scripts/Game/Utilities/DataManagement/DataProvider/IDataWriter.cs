using L1_3.Scripts.Game.Utilities.DataManagement.SaveData;

namespace L1_3.Scripts.Game.Utilities.DataManagement.DataProvider
{
    public interface IDataWriter<in TData> where TData : ISaveData
    {
        void WriteTo(TData data);
    }
}