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
    public class LanguageManager : ILanguageService
    {
        private readonly ILanguageDAL _languageDAL;

        public LanguageManager(ILanguageDAL languageDAL)
        {
            _languageDAL = languageDAL;
        }

        public void Delete(Language t)
        {
            _languageDAL.Delete(t);
        }

        public Language GetById(int id)
        {
            return _languageDAL.GetById(id);
        }

        public List<Language> GetList()
        {
            return _languageDAL.GetList();
        }

        public void Insert(Language t)
        {
            _languageDAL.Insert(t);
        }

        public void Update(Language t)
        {
            _languageDAL.Update(t);
        }
    }
}
