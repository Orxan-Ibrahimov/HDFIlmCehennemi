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
    public class MovieKindManager : IMovieKindService
    {
        private readonly IMovieKindDAL _movieKindDAL;

        public MovieKindManager(IMovieKindDAL movieKindDAL)
        {
            _movieKindDAL = movieKindDAL;
        }

        public void Delete(MovieKind t)
        {
            _movieKindDAL.Delete(t);
        }

        public MovieKind GetById(int id)
        {
           return GetList().FirstOrDefault(mk => mk.Id == id);
        }

        public List<MovieKind> GetList()
        {
            return _movieKindDAL.GetList().Include(mk => mk.Movie).Include(mk => mk.Kind).ToList();
        }

        public void Insert(MovieKind t)
        {
            _movieKindDAL.Insert(t);
        }

        public void Update(MovieKind t)
        {
            _movieKindDAL.Update(t);
        }
    }
}
