using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class CareerContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public CareerContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public DbSet<CareerEntry> CareerEntries { get; set; }
    public DbSet<CareerTag> CareerTags { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(Configuration.GetConnectionString("postgresDb"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<CareerEntry>()
            .HasMany(ce => ce.Tags)
            .WithMany(ct => ct.CareerEntries)
            .UsingEntity(j => j.ToTable("CareerEntryCareerTag"));

        modelBuilder
            .Entity<CareerTag>()
            .HasMany(ct => ct.CareerEntries)
            .WithMany(ce => ce.Tags)
            .UsingEntity(j => j.ToTable("CareerEntryCareerTag"));
    }
}
