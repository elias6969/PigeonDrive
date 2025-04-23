namespace PigeonDrive.Api.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using PigeonDrive.Api.Models;

    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Folder> Folders { get; set; } = null!;
        public DbSet<FileItem> Files { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Folder>()
                   .HasOne(f => f.Owner)
                   .WithMany(u => u.Folders)
                   .HasForeignKey(f => f.OwnerId);

            builder.Entity<FileItem>()
                   .HasOne(f => f.Folder)
                   .WithMany(d => d.Files)
                   .HasForeignKey(f => f.FolderId);
        }
    }
}
