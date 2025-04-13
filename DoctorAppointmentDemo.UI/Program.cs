using System.Text;
using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Data.Repositories;
using DoctorAppointmentDemo.Service.Interfaces;
using DoctorAppointmentDemo.Service.Services;
using DoctorAppointmentDemo.Domain.Entities;
using DoctorAppointmentDemo.Data.Storage;

class Program
{
    static IPatientService _patientService;
    static IAppointmentService _appointmentService;

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Оберіть тип зберігання даних:");
        Console.WriteLine("1 - JSON");
        Console.WriteLine("2 - XML");
        Console.Write("Ваш вибір: ");

        string? choice = Console.ReadLine()?.Trim();
        string format = choice == "2" ? "XML" : "JSON";

        IDataStorage<Patient> patientStorage = StorageFactory.CreatePatientStorage(format);
        IDataStorage<Appointment> appointmentStorage = StorageFactory.CreateAppointmentStorage(format);

        _patientService = new PatientService(new PatientRepository(patientStorage));
        _appointmentService = new AppointmentService(new AppointmentRepository(appointmentStorage));

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Додати пацієнта");
            Console.WriteLine("2. Переглянути всіх пацієнтів");
            Console.WriteLine("3. Додати запис на прийом");
            Console.WriteLine("4. Переглянути всі записи");
            Console.WriteLine("5. Вийти");

            Console.Write("\nОберіть дію: ");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1": AddPatient(); break;
                case "2": ShowPatients(); break;
                case "3": AddAppointment(); break;
                case "4": ShowAppointments(); break;
                case "5": return;
                default: Console.WriteLine("Невідома команда. Спробуйте ще раз."); break;
            }
        }
    }

    static void AddPatient()
    {
        Console.Write("\nВведіть ім'я: ");
        string name = Console.ReadLine() ?? "Невідомо";

        Console.Write("Введіть прізвище: ");
        string surname = Console.ReadLine() ?? "Невідомо";

        Console.Write("Введіть вік: ");
        int age = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Введіть адресу: ");
        string? address = Console.ReadLine();

        Console.Write("Додаткова інформація: ");
        string? additionalInfo = Console.ReadLine();

        var patient = new Patient
        {
            Name = name,
            Surname = surname,
            Age = age,
            Address = address,
            AdditionalInfo = additionalInfo
        };

        _patientService.Create(patient);
        Console.WriteLine("Пацієнта успішно додано!");
    }

    static void ShowPatients()
    {
        Console.WriteLine("\nСписок пацієнтів:");
        foreach (var patient in _patientService.GetAll())
        {
            Console.WriteLine($"ID: {patient.Id} | {patient.Name} {patient.Surname} | Вік: {patient.Age}");
        }
    }

    static void AddAppointment()
    {
        Console.Write("\nВведіть ID пацієнта: ");
        int patientId = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Введіть ID лікаря: ");
        int doctorId = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Дата початку (yyyy-MM-dd HH:mm): ");
        DateTime dateTimeFrom = DateTime.Parse(Console.ReadLine() ?? "2000-01-01 00:00");

        Console.Write("Дата закінчення (yyyy-MM-dd HH:mm): ");
        DateTime dateTimeTo = DateTime.Parse(Console.ReadLine() ?? "2000-01-01 00:00");

        Console.Write("Опис: ");
        string? description = Console.ReadLine();

        var appointment = new Appointment
        {
            PatientId = patientId,
            DoctorId = doctorId,
            DateTimeFrom = dateTimeFrom,
            DateTimeTo = dateTimeTo,
            Description = description
        };

        _appointmentService.Create(appointment);
        Console.WriteLine("Запис на прийом успішно створено!");
    }

    static void ShowAppointments()
    {
        Console.WriteLine("\nСписок записів:");
        foreach (var appointment in _appointmentService.GetAll())
        {
            Console.WriteLine($"ID: {appointment.Id} | Пацієнт ID: {appointment.PatientId} | Лікар ID: {appointment.DoctorId} |  {appointment.DateTimeFrom} - {appointment.DateTimeTo}");
        }
    }
}
