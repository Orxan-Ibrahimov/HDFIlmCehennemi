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
    public class CountryManager : ICountryService
    {
        readonly ICountryDal _countryDAL;

        public CountryManager(ICountryDal countryDAL)
        {
            _countryDAL = countryDAL;
        }
        public void Delete(Country t)
        {
            _countryDAL.Delete(t);
        }

        public Country GetById(int id)
        {
           return _countryDAL.GetById(id);
        }

        public List<Country> GetList()
        {
            return _countryDAL.GetList();
        }

        public void Insert(Country t)
        {
           _countryDAL.Insert(t);
        }

        public void Update(Country t)
        {
           _countryDAL.Update(t);
        }
    }
}
