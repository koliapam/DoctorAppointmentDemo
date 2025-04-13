using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Domain.Entities;

namespace DoctorAppointmentDemo.Data.Storage
{
    public static class StorageFactory
    {
        public static IDataStorage<Patient> CreatePatientStorage(string type)
        {
            return type switch
            {
                "JSON" => new JsonDataStorage<Patient>("patients.json"),
                "XML" => new XmlDataStorage<Patient>("patients.xml"),
                _ => throw new ArgumentException("Invalid storage type")
            };
        }

        public static IDataStorage<Appointment> CreateAppointmentStorage(string type)
        {
            return type switch
            {
                "JSON" => new JsonDataStorage<Appointment>("appointments.json"),
                "XML" => new XmlDataStorage<Appointment>("appointments.xml"),
                _ => throw new ArgumentException("Invalid storage type")
            };
        }
    }
}
