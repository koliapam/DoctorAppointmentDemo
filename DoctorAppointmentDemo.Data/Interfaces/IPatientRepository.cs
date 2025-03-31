using DoctorAppointmentDemo.Domain.Entities;
using MyDoctorAppointment.Data.Interfaces;

namespace DoctorAppointmentDemo.Data.Interfaces
{
    public interface IPatientRepository : IGenericRepository<Patient> { }
}
