using HDF.EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.EntityLayer.Concrete
{
    internal class Kind : BaseEntity
    {
        public string Name { get; set; }
        public List<MovieKind> MovieKinds { get; set; }
    }
}
