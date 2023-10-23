using HDF.EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.EntityLayer.Concrete
{
    public class Footer : BaseEntity
    {
        [Required]
        public string Website { get; set; }
        [Required]
        public string Distributed { get; set; }
        [Required]
        public string Designed { get; set; }
    }
}
