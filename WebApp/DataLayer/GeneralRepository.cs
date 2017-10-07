using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using WebApp.DataLayer;
using WebApp.Models;

namespace WebApp.DataLayer
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {
        private DbContext _context;
        private DbSet<T> _dbSet;

        public GeneralRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }

        public int Add(T entity)
        {
            _dbSet.Add(entity);
            return Save();
        }

        public int Delete(T entity)
        {
           //_context.Entry(entity).State = EntityState.Deleted;
           _dbSet.Remove(entity);
            return Save();
        }

        public T Get(Func<T, bool> func)
        {
            return GetByCretiria(func).FirstOrDefault();
        }

        public IEnumerable<T> GetByCretiria(Func<T, bool> func = null)
        {
            if (func != null)
            {
                return _dbSet.Where(func).ToList();
            }
            return _dbSet.ToList();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public int Update()
        {    
            return Save();
        }

        //public int Update(T entity)
        //{   //If this unmark, entity must retrive from context and then to be update  (Query the context) 
        //the same for deletion and update
        //      _context.Entry(entity).State = EntityState.Modified;
        //    return Save();
        //}
    }
}