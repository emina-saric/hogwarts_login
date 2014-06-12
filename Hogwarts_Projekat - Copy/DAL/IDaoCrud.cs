using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public interface IDaoCrud<T>
    {
        long create(T entity);
        T read(T entity);
        T update(T entity);
        void delete(T entity);
        T getById(int id);
        List<T> getAll();
        List<T> getByExample(string ime   , string Password);
    }
}
