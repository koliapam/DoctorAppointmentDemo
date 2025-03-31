using DoctorAppointmentDemo.Data.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DoctorAppointmentDemo.Data.Storage
{
    public class XmlDataStorage<T> : IDataStorage<T>
    {
        private readonly string _filePath;

        public XmlDataStorage(string filePath)
        {
            _filePath = filePath;
            if (!File.Exists(_filePath))
                Save(new List<T>());
        }

        public void Save(IEnumerable<T> items)
        {
            var serializer = new XmlSerializer(typeof(List<T>));
            using var writer = new StreamWriter(_filePath);
            serializer.Serialize(writer, items);
        }

        public IEnumerable<T> Load()
        {
            if (!File.Exists(_filePath)) return new List<T>();

            var serializer = new XmlSerializer(typeof(List<T>));
            using var reader = new StreamReader(_filePath);
            return serializer.Deserialize(reader) as List<T> ?? new List<T>();
        }
    }
}
