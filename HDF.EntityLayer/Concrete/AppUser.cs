using HDF.EntityLayer.Concrete.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Avatar { get; set; }
        public List<Movie> Followings { get; set; }
        public List<Movie> Watchings { get; set; }
        public List<Comment> Comments { get; set; }       
    }
}
