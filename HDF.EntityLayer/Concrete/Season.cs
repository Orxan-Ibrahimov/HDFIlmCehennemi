using HDF.EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.EntityLayer.Concrete
{
    public class Season : BaseEntity
    {
        public int SeasonNumber { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Episode>? Episodes { get; set; }
        public Movie? Movie { get; set; }
        public int MovieId { get; set; }
    }
}
