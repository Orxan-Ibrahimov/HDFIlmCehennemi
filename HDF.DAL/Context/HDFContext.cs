using HDF.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDF.DAL.Context
{
    public class HDFContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-R7AR1ND;initial catalog=EasyCashDb;integrated Security=true");
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<FilmOrSerie> FilmOrSeries { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }
        public DbSet<MovieKind> MovieKinds { get; set; }
        public DbSet<MovieLanguage> MovieLanguages { get; set; }
    }
}
