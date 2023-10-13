using HDF.EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.EntityLayer.Concrete
{
    internal class MovieLanguage : BaseEntity
    {
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
