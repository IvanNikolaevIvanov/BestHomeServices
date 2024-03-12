using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BestHomeServices.Infrastructure.Data;

public class BestHomeServicesDb : IdentityDbContext
{
    public BestHomeServicesDb(DbContextOptions<BestHomeServicesDb> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
    }
}
