using HDF.EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.EntityLayer.Concrete
{
    public class MovieCategory : BaseEntity
    {
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}
