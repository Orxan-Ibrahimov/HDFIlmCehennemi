using HDF.BusinessLayer.Abstract;
using HDF.DAL.Abstract;
using HDF.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public void Delete(Category t)
        {
            _categoryDAL.Delete(t);
        }

        public Category GetById(int id)
        {
            return _categoryDAL.GetList().Include(c => c.MovieCategories).ThenInclude(mc => mc.Movie).FirstOrDefault(c => c.Id == id);
        }

        public List<Category> GetList()
        {
           return _categoryDAL.GetList().Include(c => c.MovieCategories).ThenInclude(mc => mc.Movie).ToList();
        }

        public void Insert(Category t)
        {
             _categoryDAL.Insert(t);
        }

        public void Update(Category t)
        {
            _categoryDAL.Update(t);
        }
    }
}
