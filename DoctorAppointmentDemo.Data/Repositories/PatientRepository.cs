using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Domain.Entities;
using MyDoctorAppointment.Data.Repositories;

namespace DoctorAppointmentDemo.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public override int LastId { get; set; }

        public PatientRepository(IDataStorage<Patient> storage) : base(storage) { }

        public override void ShowInfo(Patient source)
        {
            Console.WriteLine($"Patient: {source.Name} {source.Surname}, Age: {source.Age}");
        }
    }
}
