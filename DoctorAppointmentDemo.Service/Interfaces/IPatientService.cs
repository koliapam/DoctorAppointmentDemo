using DoctorAppointmentDemo.Domain.Entities;
using System.Collections.Generic;

namespace DoctorAppointmentDemo.Service.Interfaces
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAll();
        Patient? Get(int id);
        Patient Create(Patient patient);
        bool Delete(int id);
        Patient Update(int id, Patient patient);
    }
}
