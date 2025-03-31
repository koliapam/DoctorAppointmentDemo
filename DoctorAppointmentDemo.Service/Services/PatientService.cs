﻿using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Data.Repositories;
using DoctorAppointmentDemo.Domain.Entities;
using DoctorAppointmentDemo.Service.Interfaces;
using System.Collections.Generic;

namespace DoctorAppointmentDemo.Service.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService()
        {
            _patientRepository = new PatientRepository();
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }

        public Patient? Get(int id)
        {
            return _patientRepository.GetById(id);
        }

        public Patient Create(Patient patient)
        {
            return _patientRepository.Create(patient);
        }

        public bool Delete(int id)
        {
            return _patientRepository.Delete(id);
        }

        public Patient Update(int id, Patient patient)
        {
            return _patientRepository.Update(id, patient);
        }
    }
}
