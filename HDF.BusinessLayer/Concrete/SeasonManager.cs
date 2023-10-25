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
    public class SeasonManager : ISeasonService
    {
        private readonly ISeasonDAL _seasonDAL;

        public SeasonManager(ISeasonDAL seasonDAL)
        {
            _seasonDAL = seasonDAL;
        }

        public void Delete(Season t)
        {
            _seasonDAL.Delete(t);
        }

        public Season GetById(int id)
        {
            return GetList().First(s => s.Id == id);
        }

        public List<Season> GetList()
        {
            return _seasonDAL.GetList().Include(s => s.Movie).Include(s => s.Episodes).ToList();
        }

        public void Insert(Season t)
        {
            _seasonDAL.Insert(t);
        }

        public void Update(Season t)
        {
            _seasonDAL.Update(t);
        }
    }
}
