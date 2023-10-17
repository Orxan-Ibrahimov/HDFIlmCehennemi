﻿using HDF.BusinessLayer.Abstract;
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
    public class MovieManager : IMovieService
    {
        private readonly IMovieDAL _movieDAL;

        public MovieManager(IMovieDAL movieDAL)
        {
            _movieDAL = movieDAL;
        }

        public void Delete(Movie t)
        {
            _movieDAL.Delete(t);
        }

        public Movie GetById(int id)
        {
            return _movieDAL.GetList().Include(m => m.Country).Include(m => m.FilmOrSerie).FirstOrDefault(m=>m.Id == id);
        }

        public List<Movie> GetList()
        {
            return _movieDAL.GetList().Include(m => m.Country).Include(m => m.FilmOrSerie).ToList();
        }

        public void Insert(Movie t)
        {
            _movieDAL.Insert(t);
        }

        public void Update(Movie t)
        {
            _movieDAL.Update(t);
        }
    }
}
