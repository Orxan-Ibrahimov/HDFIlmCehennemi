using HDF.EntityLayer.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.EntityLayer.Concrete
{
    public class Language : BaseEntity
    {
        public string? LanguageKind { get; set; }
        public List<MovieLanguage>? MovieLanguages { get; set; }
    }
}
