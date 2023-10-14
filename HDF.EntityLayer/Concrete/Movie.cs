using HDF.EntityLayer.Concrete.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.EntityLayer.Concrete
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }
        public string FilmImage { get; set; }
        public string Annotation { get; set; }
        public decimal? IMDBPoint { get; set; }
        public int? MoviePoint { get; set; }
        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }        
        public int? FilmOrSerieId { get; set; }
        [ForeignKey("FilmOrSerieId")]
        public FilmOrSerie FilmOrSerie { get; set; }
        public List<MovieKind> MovieKinds { get; set; }
        public List<Comment> Comments { get; set; }
        public List<MovieLanguage> MovieLanguages { get; set; }
        public List<MovieCast> MovieCasts { get; set; }
        public List<MovieCategory> MovieCategories { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}
