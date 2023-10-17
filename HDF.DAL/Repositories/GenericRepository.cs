using HDF.DAL.Abstract;
using HDF.DAL.Context;
using Microsoft.EntityFrameworkCore;
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

        public DbSet<T> GetList()
        {
            var _context = new HDFContext();
            return _context.Set<T>();

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
