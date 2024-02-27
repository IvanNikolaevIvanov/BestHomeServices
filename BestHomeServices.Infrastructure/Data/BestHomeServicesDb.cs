using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BestHomeServices.Data
{
    public class BestHomeServicesDb : IdentityDbContext
    {
        public BestHomeServicesDb(DbContextOptions<BestHomeServicesDb> options)
            : base(options)
        {
        }
    }
}
