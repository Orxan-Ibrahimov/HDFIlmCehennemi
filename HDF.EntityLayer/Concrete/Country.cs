using HDF.EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.EntityLayer.Concrete
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
