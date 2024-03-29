using BestHomeServices.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestHomeServices.Infrastructure.Data.SeedDb
{
    internal class SpecialistConfiguration : IEntityTypeConfiguration<Specialist>
    {
        public void Configure(EntityTypeBuilder<Specialist> builder)
        {
            var data = new SeedData();

            
               builder
            .HasMany(s => s.Cities)
            .WithMany(c => c.Specialists)
            .UsingEntity<Dictionary<string, object>>(
            "CitySpecialist",
            r => r.HasOne<City>().WithMany().HasForeignKey("CityId"),
            l => l.HasOne<Specialist>().WithMany().HasForeignKey("SpecialistId")
            .OnDelete(DeleteBehavior.Restrict),
                je =>
                {
                    je.HasKey("CityId", "SpecialistId");
                    je.HasData(
                        new { CityId = data.LarnacaCity.Id, SpecialistId = data.FirstSpecialist.Id },
                        new { CityId = data.LarnacaCity.Id, SpecialistId = data.SecondSpecialist.Id },
                        new { CityId = data.LarnacaCity.Id, SpecialistId = data.ThirdSpecialist.Id },
                        new { CityId = data.PafosCity.Id, SpecialistId = data.FirstSpecialist.Id },
                        new { CityId = data.PafosCity.Id, SpecialistId = data.ThirdSpecialist.Id },
                        new { CityId = data.LimasolCity.Id, SpecialistId = data.FirstSpecialist.Id },
                         new { CityId = data.LimasolCity.Id, SpecialistId = data.SecondSpecialist.Id });
                });
        }
    }
}
