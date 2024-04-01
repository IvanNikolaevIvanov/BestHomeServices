
using BestHomeServices.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BestHomeServices.Infrastructure.Data.SeedDb
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Client> builder)
        {
            var data = new SeedData();

            builder.HasData(new Client[] { data.FirstClient });
        }
    }
}
