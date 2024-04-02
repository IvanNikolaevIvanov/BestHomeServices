using BestHomeServices.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestHomeServices.Infrastructure.Data.SeedDb
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var data = new SeedData();

            builder.HasMany(cat => cat.Cities)
                .WithOne()
                .HasForeignKey(c => c.Id)
                .OnDelete(DeleteBehavior.Restrict);



            builder.HasData(new Category[] { data.ElectricianCategory, data.PlumberCategory, data.HandymanCategory });
            
              
        }
    }
}
