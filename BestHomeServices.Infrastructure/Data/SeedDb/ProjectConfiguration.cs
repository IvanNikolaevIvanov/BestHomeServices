using BestHomeServices.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestHomeServices.Infrastructure.Data.SeedDb
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
            .HasKey(p => new { p.SpecialistId, p.ClientId });

            builder
                .HasOne(p => p.Specialist)
                .WithMany(s => s.Projects)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
