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
    public class Episode : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [ValidateNever]
        public string EpisodeImage { get; set; }
        [Required,NotMapped]
        public IFormFile EpisodePhoto { get; set; }
        [Required]
        public int EpisodeNumber { get; set; }
        public int? SeasonId { get; set; }
        [ValidateNever]
        public Season Season { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
