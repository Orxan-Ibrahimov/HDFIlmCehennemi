using HDF.EntityLayer.Concrete.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.EntityLayer.Concrete
{
    internal class AppUser : IdentityUser<int>
    {
        public string Avatar { get; set; }
        public List<Movie> Followings { get; set; }
        public List<Movie> Watchings { get; set; }
        public List<Comment> Comments { get; set; }
        public string Avatar { get; set; }
        public string Avatar { get; set; }
        public string Avatar { get; set; }
        public string Avatar { get; set; }
    }
}
