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
    public class MovieCastManager : IMovieCastService
    {
        private readonly IMovieCastDAL _movieCastDAL;

        public MovieCastManager(IMovieCastDAL movieCastDAL)
        {
            _movieCastDAL = movieCastDAL;
        }

        public void Delete(MovieCast t)
        {
            _movieCastDAL.Delete(t);
        }

        public MovieCast GetById(int id)
        {
            return GetList().First(mc => mc.Id == id);
        }

        public List<MovieCast> GetList()
        {
            return _movieCastDAL.GetList().Include(mc => mc.Movie).ToList();
        }

        public void Insert(MovieCast t)
        {
            _movieCastDAL.Insert(t);
        }

        public void Update(MovieCast t)
        {
            _movieCastDAL.Update(t);
        }
    }
}
