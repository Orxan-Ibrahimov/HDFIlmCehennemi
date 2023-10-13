using HDF.EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.EntityLayer.Concrete
{
    internal class Episode : BaseEntity
    {
        public string Name { get; set; }       
        public string EpisodeImage { get; set; }        
        public int SerieId { get; set; }
        public Movie Movie { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
