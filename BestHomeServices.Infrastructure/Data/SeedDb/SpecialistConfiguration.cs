using BestHomeServices.Infrastructure.Data.Models;
using Microsoft.Data.SqlClient;
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
             .HasOne(s => s.Category)
             .WithMany(c => c.Specialists)
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new Specialist[] { data.FirstSpecialist, data.SecondSpecialist, data.ThirdSpecialist });
            
        }
    }
}
