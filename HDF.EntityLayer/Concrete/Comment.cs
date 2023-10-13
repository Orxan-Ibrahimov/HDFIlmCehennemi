using HDF.EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.EntityLayer.Concrete
{
    public class Comment: BaseEntity
    {
        public string Message { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }

    }
}
