using HDF.EntityLayer.Concrete.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.EntityLayer.Concrete
{
    public class AppUser : IdentityUser
    {
        public string? Avatar { get; set; }
        public List<Movie>? Followings { get; set; }
        public List<Movie>? Watchings { get; set; }
        public List<Comment>? Comments { get; set; }       
    }
}
