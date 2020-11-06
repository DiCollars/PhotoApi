using Microsoft.EntityFrameworkCore;
using PhotoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApi.Services
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumPhoto>()
                .HasKey(t => new { t.PhotoId, t.AlbumId });

            modelBuilder.Entity<AlbumPhoto>()
                .HasOne(sc => sc.Photo)
                .WithMany(s => s.AlbumPhotos)
                .HasForeignKey(sc => sc.PhotoId);

            modelBuilder.Entity<AlbumPhoto>()
                .HasOne(sc => sc.Album)
                .WithMany(c => c.AlbumPhotos)
                .HasForeignKey(sc => sc.AlbumId);
        }
    }
}
