using FileManager.FileManagerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FileManager.FileManagerApi.Data{
    public class AppDbContext : DbContext{
        public DbSet<UserModel> Users => Set<UserModel>();

        public AppDbContext(DbContextOptions options) : base(options){
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<FileModel>()
                .HasKey(o => new { o.Path, o.Name });

            modelBuilder.Entity<FolderModel>()
                .HasKey(o => new { o.Path, o.Name });

            modelBuilder.Entity<RepositoryModel>()
                .HasKey(o => new { o.Path, o.Name });
        }
    }
}