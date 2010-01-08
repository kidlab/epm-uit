using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPM.Models
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T GetOne(int id);

        void Add(T obj);
        void Delete(T obj);

        void Save();
    }
}
