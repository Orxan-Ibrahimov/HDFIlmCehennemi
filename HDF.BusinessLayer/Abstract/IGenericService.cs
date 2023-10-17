using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);
        T GetById(int id);
        List<T> GetList();
    }
}
