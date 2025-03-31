using System.Collections.Generic;

namespace DoctorAppointmentDemo.Data.Interfaces
{
    public interface IDataStorage<T>
    {
        void Save(IEnumerable<T> items);
        IEnumerable<T> Load();
    }
}
