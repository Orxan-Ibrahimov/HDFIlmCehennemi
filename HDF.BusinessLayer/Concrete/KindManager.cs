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
    public class KindManager : IKindService
    {
        private readonly IKindDAL _kindDAL;

        public KindManager(IKindDAL kindDAL)
        {
            _kindDAL = kindDAL;
        }

        public void Delete(Kind t)
        {
            _kindDAL.Delete(t);
        }

        public Kind GetById(int id)
        {
            return _kindDAL.GetById(id);
        }

        public List<Kind> GetList()
        {
            return _kindDAL.GetList();
        }

        public void Insert(Kind t)
        {
            _kindDAL.Insert(t);
        }

        public void Update(Kind t)
        {
            _kindDAL.Update(t);
        }
    }
}
