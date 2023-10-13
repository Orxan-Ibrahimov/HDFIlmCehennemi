using HDF.EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.EntityLayer.Concrete
{
    internal class Movie : BaseEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string FilmImage { get; set; }
        public string Annotation { get; set; }
        public decimal IMDBPoint { get; set; }
        public int MoviePoint { get; set; }
        public FilmOrSerie Kind { get; set; }
        public List<Comment> Comments { get; set; }
        public List<MovieLanguage> MovieLanguages { get; set; }
        public List<MovieCast> MovieCasts { get; set; }
        public List<MovieCategory> MovieCategories { get; set; }
        public List<MovieKind> MovieKinds { get; set; }
    }
}
