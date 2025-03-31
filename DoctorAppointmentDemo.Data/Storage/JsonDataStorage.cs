using DoctorAppointmentDemo.Data.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DoctorAppointmentDemo.Data.Storage
{
    public class JsonDataStorage<T> : IDataStorage<T>
    {
        private readonly string _filePath;

        public JsonDataStorage(string filePath)
        {
            _filePath = filePath;
            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, "[]");
        }

        public void Save(IEnumerable<T> items)
        {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(items, Formatting.Indented));
        }

        public IEnumerable<T> Load()
        {
            var content = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<T>>(content) ?? new List<T>();
        }
    }
}
