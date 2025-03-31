using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Data.Repositories;
using DoctorAppointmentDemo.Domain.Entities;
using DoctorAppointmentDemo.Service.Interfaces;
using System.Collections.Generic;

namespace DoctorAppointmentDemo.Service.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService()
        {
            _appointmentRepository = new AppointmentRepository();
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment? Get(int id)
        {
            return _appointmentRepository.GetById(id);
        }

        public Appointment Create(Appointment appointment)
        {
            return _appointmentRepository.Create(appointment);
        }

        public bool Delete(int id)
        {
            return _appointmentRepository.Delete(id);
        }

        public Appointment Update(int id, Appointment appointment)
        {
            return _appointmentRepository.Update(id, appointment);
        }
    }
}
