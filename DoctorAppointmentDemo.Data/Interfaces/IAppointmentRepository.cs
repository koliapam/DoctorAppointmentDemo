using DoctorAppointmentDemo.Domain.Entities;
using MyDoctorAppointment.Data.Interfaces;

namespace DoctorAppointmentDemo.Data.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment> { }
}
