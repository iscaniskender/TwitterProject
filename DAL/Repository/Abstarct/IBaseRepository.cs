using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repository.Abstarct
{
    public interface IBaseRepository<T> where T :class
    {
        T GetById(int id);
        T GetOne(Expression<Func<T, bool>> filter);
        List<T> GetAll();

        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
