using HDF.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HDF.DAL.Context
{
    public class HDFContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-AIBH7MI\\SQLEXPRESS;Initial Catalog=HDF;Integrated Security = sspi;");
        }
        
        public DbSet<Country> Countries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }
        public DbSet<MovieKind> MovieKinds { get; set; }
        public DbSet<MovieLanguage> MovieLanguages { get; set; }
        public DbSet<Footer> Footer { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Movie>().
                 Property(m => m.Annotation).HasColumnType("Text");

            builder.Entity<Movie>().
                Property(m => m.IsActive).HasDefaultValue(true);

            builder.Entity<Comment>().
                HasOne(c => c.Movie)
                .WithMany(m => m.Comments)
                .HasForeignKey(c => c.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            builder.Entity<Comment>().
              HasOne(c => c.Episode)
              .WithMany(e => e.Comments)
              .HasForeignKey(c => c.EpisodeId)
              .OnDelete(DeleteBehavior.ClientSetNull); 

            builder.Entity<Comment>().
              HasOne(c => c.User)
              .WithMany(u => u.Comments)
              .HasForeignKey(c => c.UserId)
              .OnDelete(DeleteBehavior.ClientSetNull); 

            builder.Entity<Episode>().
              HasOne(e => e.Movie)
              .WithMany(e => e.Episodes)
              .HasForeignKey(c => c.MovieId)
              .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Movie>().
             HasOne(m => m.Country)
             .WithMany(c => c.Movies)
             .HasForeignKey(m => m.CountryId)
             .OnDelete(DeleteBehavior.ClientSetNull);         

            builder.Entity<MovieCast>().
             HasOne(mc => mc.Movie)
             .WithMany(c => c.MovieCasts)
             .HasForeignKey(mc => mc.MovieId)
             .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<MovieCast>().
             HasOne(mc => mc.Cast)
             .WithMany(c => c.MovieCasts)
             .HasForeignKey(m => m.CastId)
             .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<MovieCategory>().
            HasOne(mc => mc.Category)
            .WithMany(c => c.MovieCategories)
            .HasForeignKey(mc => mc.CategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<MovieCategory>().
             HasOne(mc => mc.Movie)
             .WithMany(c => c.MovieCategories)
             .HasForeignKey(m => m.MovieId)
             .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<MovieKind>().
            HasOne(mk => mk.Kind)
            .WithMany(c => c.MovieKinds)
            .HasForeignKey(mc => mc.KindId)
            .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<MovieKind>().
             HasOne(mc => mc.Movie)
             .WithMany(c => c.MovieKinds)
             .HasForeignKey(m => m.MovieId)
             .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<MovieLanguage>().
           HasOne(ml => ml.Language)
           .WithMany(c => c.MovieLanguages)
           .HasForeignKey(mc => mc.LanguageId)
           .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<MovieLanguage>().
             HasOne(mc => mc.Movie)
             .WithMany(c => c.MovieLanguages)
             .HasForeignKey(m => m.MovieId)
             .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<AppRole>()
                .HasData(
                new AppRole
                {
                    Id = 1,
                    Name = "Admin",
                    
                },
                new AppRole
                {
                    Id = 2,
                    Name = "Supervisor",
                },
                new AppRole
                {
                    Id = 3,
                    Name = "Project Manager",
                },
                new AppRole
                {
                    Id = 4,
                    Name = "Worker",
                }
                );
        }
    }
}
