using HDF.BusinessLayer.Abstract;
using HDF.DAL.Abstract;
using HDF.DAL.Repositories;
using HDF.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.BusinessLayer.Concrete
{
    public class MovieLanguageManager : IMovieLanguageService
    {
        private readonly IMovieLanguageDAL _movieLanguageDAL;

        public MovieLanguageManager(IMovieLanguageDAL movieLanguageDAL)
        {
            _movieLanguageDAL = movieLanguageDAL;
        }

        public void Insert(MovieLanguage t)
        {
            _movieLanguageDAL.Insert(t);
        }

        public void Update(MovieLanguage t)
        {
            _movieLanguageDAL.Update(t);
        }

        public void Delete(MovieLanguage t)
        {
            _movieLanguageDAL.Delete(t);
        }

        public MovieLanguage GetById(int id)
        {
            return GetList().FirstOrDefault(ml => ml.Id == id);
        }

        public List<MovieLanguage> GetList()
        {
            return _movieLanguageDAL.GetList().Include(ml => ml.Language).Include(ml => ml.Movie).ToList();
        }
 
    }
}
