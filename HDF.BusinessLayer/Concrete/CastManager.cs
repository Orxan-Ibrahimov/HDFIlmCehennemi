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
    public class CastManager : ICastService
    {
        private readonly ICastDAL _castDAL;

        public CastManager(ICastDAL castDAL)
        {
            _castDAL = castDAL;
        }

        public void Delete(Cast t)
        {
           _castDAL.Delete(t);
        }

        public Cast GetById(int id)
        {
            return _castDAL.GetById(id);
        }

        public List<Cast> GetList()
        {
           return _castDAL.GetList();
        }

        public void Insert(Cast t)
        {
            _castDAL.Insert(t);
        }

        public void Update(Cast t)
        {
           _castDAL?.Update(t);
        }
    }
}
