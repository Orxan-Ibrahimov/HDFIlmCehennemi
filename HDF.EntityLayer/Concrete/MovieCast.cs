using HDF.EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.EntityLayer.Concrete
{
    public class MovieCast : BaseEntity
    {
        public int CastId { get; set; }
        public Cast? Cast { get; set; }
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}
