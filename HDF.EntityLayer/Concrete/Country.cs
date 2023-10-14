using HDF.EntityLayer.Concrete.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
    public class Country : BaseEntity
    {
       
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Image { get; set; }
        [ValidateNever]
        public List<Movie> Movies { get; set; }
    }
}
