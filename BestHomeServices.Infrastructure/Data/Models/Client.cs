using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BestHomeServices.Infrastructure.Constants.DataConstants;

namespace BestHomeServices.Infrastructure.Data.Models
{
    [Comment("Client of the Best Home Service")]
    public class Client
    {
        [Key]
        [Comment("Client's identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ClientNameMaxLength)]
        [Comment("Client's name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(ClientAddressMaxLength)]
        [Comment("Client's address")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [Comment("Client's city's identifier")]
        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public City City { get; set; } = null!;

        [Required]
        [MaxLength(ClientPhoneNumberMaxLength)]
        [Comment("Client's phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Comment("User's identifier")]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;
    }
}
