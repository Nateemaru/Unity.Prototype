using Zenject;

namespace _Scripts.Services.Database
{
    public class DataReader : IDataReader, IInitializable
    {
        private IStorageService _storageService;

        public DataReader(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public void Initialize()
        {
        }

        public void SaveData<TData>(string key, TData data)
        {
            _storageService.Save(key, data);
        }
        
        public void SaveArrayData<TData>(string key, TData[] data)
        {
            _storageService.SaveArray(key, data);
        }
        

        public TData GetData<TData>(string key) where TData : class
        {
            var data = _storageService.Load<TData>(key);
            return data;
        }
        
        public TData[] GetArrayData<TData>(string key) where TData : class
        {
            var data = _storageService.LoadArray<TData>(key);
            return data;
        }
    }
}