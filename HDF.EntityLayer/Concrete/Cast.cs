using HDF.EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.EntityLayer.Concrete
{
    internal class Cast : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<MovieCast> MovieCasts { get; set; }
    }
}
