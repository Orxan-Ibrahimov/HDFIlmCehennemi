﻿using HDF.EntityLayer.Concrete.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.EntityLayer.Concrete
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        //[Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }
        [ValidateNever]
        public string FilmImage { get; set; }
        [Required,NotMapped]
        public IFormFile FilmPhoto { get; set; }
        public string Annotation { get; set; }
        public decimal? IMDBPoint { get; set; }
        public decimal? MoviePoint { get; set; }      
        public int? CountryId { get; set; }
        [ValidateNever]
        public Country? Country { get; set; }        
        public bool IsSeries { get; set; }
        public bool IsActive { get; set; }
        public List<MovieKind>? MovieKinds { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<MovieLanguage>? MovieLanguages { get; set; }
        public List<MovieCast>? MovieCasts { get; set; }
        public List<MovieCategory>? MovieCategories { get; set; }
        public List<Season>? Seasons { get; set; }

        
    }
}
