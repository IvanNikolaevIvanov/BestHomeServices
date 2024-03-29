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

            builder
                .HasMany(c => c.Cities)
                .WithMany(c => c.Categories)      
                .UsingEntity<Dictionary<string, object>>(
                "CategoryCity",
                r => r.HasOne<City>().WithMany().HasForeignKey("CityId"),
                l => l.HasOne<Category>().WithMany().HasForeignKey("CategoryId")
                .OnDelete(DeleteBehavior.Restrict),
                je =>
                {
                    je.HasKey("CategoryId", "CityId");
                    je.HasData(
                            new { CategoryId = data.ElectricianCategory.Id, CityId = data.LarnacaCity.Id },
                            new { CategoryId = data.ElectricianCategory.Id, CityId = data.PafosCity.Id },
                            new { CategoryId = data.ElectricianCategory.Id, CityId = data.LimasolCity.Id },
                            new { CategoryId = data.PlumberCategory.Id, CityId = data.LarnacaCity.Id },
                            new { CategoryId = data.PlumberCategory.Id, CityId = data.LimasolCity.Id },
                            new { CategoryId = data.HandymanCategory.Id, CityId = data.LarnacaCity.Id },
                            new { CategoryId = data.HandymanCategory.Id, CityId = data.PafosCity.Id });
                });
            
              
        }
    }
}
