namespace _Scripts.Services.Database
{
    public interface IDataReader
    {
        public TData GetData<TData>(string key) where TData : class;
        public TData[] GetArrayData<TData>(string key) where TData : class;
        public void SaveData<TData>(string key, TData data);
        public void SaveArrayData<TData>(string key, TData[] data);
    }
}