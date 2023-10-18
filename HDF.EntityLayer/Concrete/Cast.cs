using HDF.EntityLayer.Concrete.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.EntityLayer.Concrete
{
    public class Cast : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [ValidateNever]
        public string Image { get; set; }
        [Required,NotMapped]
        public IFormFile Photo { get; set; }
        public List<MovieCast>? MovieCasts { get; set; }
    }
}
