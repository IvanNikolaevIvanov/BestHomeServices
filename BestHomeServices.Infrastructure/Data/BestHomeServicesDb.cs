using BestHomeServices.Infrastructure.Data.Models;
using BestHomeServices.Infrastructure.Data.SeedDb;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BestHomeServices.Infrastructure.Data;

public class BestHomeServicesDb : IdentityDbContext
{

    public BestHomeServicesDb(DbContextOptions<BestHomeServicesDb> options)
        : base(options)
    {
       
    }

    public DbSet<Category> Categories { get; set; } = null!;

    public DbSet<City> Cities { get; set; } = null!;

    public DbSet<Specialist> Specialists { get; set; } = null!;

    public DbSet<Client> Clients { get; set; } = null!;

    public DbSet<Project> Projects { get; set; } = null!;



    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new CategoryConfiguration());
        builder.ApplyConfiguration(new CityConfiguration());
        builder.ApplyConfiguration(new ClientConfiguration());
        builder.ApplyConfiguration(new SpecialistConfiguration());
        builder.ApplyConfiguration(new ProjectConfiguration());

        base.OnModelCreating(builder);
        
    }
}
