using HDF.DAL.Abstract;
using HDF.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.DAL.Repositories
{
    public class GenericRepository<T> : IGenericDAL<T> where T : class
    {
        
        public void Delete(T t)
        {
            using var _context = new HDFContext();
            _context.Set<T>().Remove(t);
            _context.SaveChanges();

        }

        public T GetById(int id)
        {
            using var _context = new HDFContext();
            return _context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            using var _context = new HDFContext();
            return _context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            using var _context = new HDFContext();
            _context.Set<T>().Add(t);
            _context.SaveChanges();
        }

        public void Update(T t)
        {
            using var _context = new HDFContext();
            _context.Set<T>().Update(t);
            _context.SaveChanges();
        }
    }
}
