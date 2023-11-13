using HDF.EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.EntityLayer.Concrete
{
    public class Comment: BaseEntity
    {
        public string Message { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }
        public int? MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        public int? EpisodeId { get; set; }
        [ForeignKey("EpisodeId")]
        public Episode Episode { get; set; }

    }
}
