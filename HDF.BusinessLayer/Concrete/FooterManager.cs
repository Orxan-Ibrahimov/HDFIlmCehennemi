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
   
    public class FooterManager : IFooterService
    {
        private readonly IFooterDAL _footerDAL;

        public FooterManager(IFooterDAL footerDAL)
        {
            _footerDAL = footerDAL;
        }

        public void Delete(Footer t)
        {
            _footerDAL.Delete(t);
        }

        public Footer GetById(int id)
        {
            return _footerDAL.GetList().First(x => x.Id == id);
        }

        public List<Footer> GetList()
        {
            return _footerDAL.GetList().ToList();
        }

        public void Insert(Footer t)
        {
            _footerDAL.Insert(t);
        }

        public void Update(Footer t)
        {
            _footerDAL.Update(t);  
        }
    }
}
