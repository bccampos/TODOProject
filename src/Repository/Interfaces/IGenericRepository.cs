using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> List();

        int Create(T item);

        T Get(int id);

        bool Delete(int id);
    }
}
