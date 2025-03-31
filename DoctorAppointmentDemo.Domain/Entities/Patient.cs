namespace DoctorAppointmentDemo.Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int Age { get; set; }
        public string? Address { get; set; }
        public string? AdditionalInfo { get; set; }
    }
}
