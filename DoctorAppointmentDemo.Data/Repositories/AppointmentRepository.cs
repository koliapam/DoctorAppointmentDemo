using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Domain.Entities;
using MyDoctorAppointment.Data.Repositories;

namespace DoctorAppointmentDemo.Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public override int LastId { get; set; }

        public AppointmentRepository(IDataStorage<Appointment> storage) : base(storage) { }

        public override void ShowInfo(Appointment source)
        {
            Console.WriteLine($"Appointment: Doctor {source.DoctorId}, Patient {source.PatientId}, Date: {source.DateTimeFrom}");
        }
    }
}
