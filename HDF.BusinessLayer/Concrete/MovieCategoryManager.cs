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
    public class MovieCategoryManager : IMovieCategoryService
    {
        private readonly IMovieCategoryDAL _movieCategoryDAL;

        public MovieCategoryManager(IMovieCategoryDAL movieCategoryDAL)
        {
            _movieCategoryDAL = movieCategoryDAL;
        }

        public void Delete(MovieCategory t)
        {
            _movieCategoryDAL.Delete(t);
        }

        public MovieCategory GetById(int id)
        {
            return GetList().FirstOrDefault(mc => mc.Id == id);
        }

        public List<MovieCategory> GetList()
        {
            return _movieCategoryDAL.GetList().Include(mc => mc.Movie).Include(mc => mc.Category).ToList();
        }

        public void Insert(MovieCategory t)
        {
            _movieCategoryDAL.Insert(t);
        }

        public void Update(MovieCategory t)
        {
            _movieCategoryDAL.Update(t);
        }
    }
}
