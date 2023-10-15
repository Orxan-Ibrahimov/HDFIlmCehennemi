using HDF.EntityLayer.Concrete.Base;
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
    public class Category : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        [ValidateNever]
        public List<MovieCategory> MovieCategories { get; set; }
    }
}
