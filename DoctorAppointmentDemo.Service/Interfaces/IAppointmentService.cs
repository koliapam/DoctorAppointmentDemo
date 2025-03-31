using DoctorAppointmentDemo.Domain.Entities;
using System.Collections.Generic;

namespace DoctorAppointmentDemo.Service.Interfaces
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAll();
        Appointment? Get(int id);
        Appointment Create(Appointment appointment);
        bool Delete(int id);
        Appointment Update(int id, Appointment appointment);
    }
}
