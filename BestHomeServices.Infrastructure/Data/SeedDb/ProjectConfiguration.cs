using BestHomeServices.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BestHomeServices.Infrastructure.Data.SeedDb
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            var data = new SeedData();

            builder
            .HasKey(p => new { p.SpecialistId, p.ClientId });

            builder
                .HasOne(p => p.Specialist)
                .WithMany(s => s.Projects)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new Project[] { data.FirstProject });
        }
    }
}
