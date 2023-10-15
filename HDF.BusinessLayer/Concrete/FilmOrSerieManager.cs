using HDF.BusinessLayer.Abstract;
using HDF.DAL.Abstract;
using HDF.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.BusinessLayer.Concrete
{
    public class FilmOrSerieManager : IFilmOrSerieService
    {
        private readonly IFilmOrSerieDAL _filmOrSerieDAL;
        public FilmOrSerieManager(IFilmOrSerieDAL filmOrSerieDAL)
        {
            _filmOrSerieDAL = filmOrSerieDAL;
        }

        public void Delete(FilmOrSerie t)
        {
            _filmOrSerieDAL.Delete(t);
        }

        public FilmOrSerie GetById(int id)
        {
            return _filmOrSerieDAL.GetById(id);            
        }

        public List<FilmOrSerie> GetList()
        {
            return _filmOrSerieDAL.GetList();
        }

        public void Insert(FilmOrSerie t)
        {
            _filmOrSerieDAL.Insert(t);
        }

        public void Update(FilmOrSerie t)
        {
            _filmOrSerieDAL.Update(t);
        }
    }
}
