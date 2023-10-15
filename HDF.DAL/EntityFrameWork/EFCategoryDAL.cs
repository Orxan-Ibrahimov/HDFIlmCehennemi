﻿using HDF.DAL.Abstract;
using HDF.DAL.Repositories;
using HDF.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.DAL.EntityFrameWork
{
    public class EFCategoryDAL : GenericRepository<Category>, ICategoryDAL
    {
    }
}
