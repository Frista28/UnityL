namespace L1_3.Scripts.Game.Utilities.DataManagement.Serializer
{
    public interface IDataSerializer
    {
        string Serialize<TData>(TData data);

        TData Deserialize<TData>(string serializedData);
    }
}