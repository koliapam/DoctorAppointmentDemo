using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IGenericRepository<T> where T : Auditable
    {
        T Create(T source);
        bool Delete(int id);
        IEnumerable<T> GetAll();
        T? GetById(int id);
        T Update(int id, T source);
    }
}
