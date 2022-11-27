using DAL.Repository.Abstarct;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Repository.Concrete
{
    public class EfRepository<T> : IBaseRepository<T> where T : class
    {
        private DbContext _dbContext;
        private DbSet<T> _dbset;
        public EfRepository(DbContext context)
        {
            _dbContext = context;
            _dbset = _dbContext.Set<T>();
            
        }
        public void Create(T entity)
        {
            _dbset.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }
        public void Update(T entity)
        {
            _dbset.Update(entity);
        }
        public T GetById(int id)
        {
            return _dbset.Find(id);
        }
        public List<T> GetAll()
        {
            return _dbset.ToList();
        }
        public T GetOne(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

       
    }
}
