using System.Collections.Generic;

namespace ExampleSolution.WPF.DataAccess.Interfaces
{
    public interface IDataAccess<T>
    {
        ICollection<T> Get();

        void Save(T data);
    }
}
