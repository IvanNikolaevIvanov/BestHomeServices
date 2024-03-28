using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BestHomeServices.Infrastructure.Data.Models
{
    [Comment("Projects of the company")]
    public class Project
    {
        [Required]
        [Comment("Specialist Identifier")]
        public int SpecialistId { get; set; }

        [ForeignKey(nameof(SpecialistId))]
        public Specialist Specialist { get; set; } = null!;

        [Required]
        [Comment("Client Identifier")]
        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; } = null!;
    }
}
