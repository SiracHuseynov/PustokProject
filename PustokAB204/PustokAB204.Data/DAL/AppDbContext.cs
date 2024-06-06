using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PustokAB204.Core.Models;
using PustokAB204.Data.Configurations;

namespace PustokAB204.Data.DAL;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Tag> Tags { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<AppUser> Users { get; set; }
    public DbSet<Author> Authors { get; set; } 
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(BookConfiguration).Assembly);
        base.OnModelCreating(builder);
    }
}
