using HDF.EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.EntityLayer.Concrete
{
    public class MovieKind : BaseEntity
    {
        public int? KindId { get; set; }
        public Kind? Kind { get; set; }
        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}
