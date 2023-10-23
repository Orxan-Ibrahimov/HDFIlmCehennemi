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
    public class AppRoleManager : IAppRoleService
    {
        private readonly IAppRoleDAL _appRoleDAL;

        public AppRoleManager(IAppRoleDAL appRoleDAL)
        {
            _appRoleDAL = appRoleDAL;
        }

        public void Delete(AppRole t)
        {
            _appRoleDAL.Delete(t);
        }

        public AppRole GetById(int id)
        {
           return _appRoleDAL.GetList().First(x => x.Id == id);
        }

        public List<AppRole> GetList()
        {
            return _appRoleDAL.GetList().ToList();
        }

        public void Insert(AppRole t)
        {
            _appRoleDAL.Insert(t);
        }

        public void Update(AppRole t)
        { 
           _appRoleDAL.Update(t);
        }
    }
}
