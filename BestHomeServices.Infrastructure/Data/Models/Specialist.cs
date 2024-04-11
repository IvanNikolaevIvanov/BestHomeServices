using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BestHomeServices.Infrastructure.Constants.DataConstants;

namespace BestHomeServices.Infrastructure.Data.Models
{
    [Comment("Home Specialist")]
    public class Specialist
    {
        [Key]
        [Comment("Specialist identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(SpecialistFirstNameMaxLength)]
        [Comment("Specialist's First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(SpecialistLastNameMaxLength)]
        [Comment("Specialist's Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(SpecialistPhoneNumberMaxLength)]
        [Comment("Specialist's Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(SpecialistDescriptionMaxLength)]
        [Comment("Specialist's short description")]
        public string Description { get; set; } = string.Empty;

        [MaxLength(SpecialistImageUrlMaxLength)]
        [Comment("Specialist's Photo")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [Comment("Category Identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        [Comment("Specialist's city identifier.")]
        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        [Comment("City where the specialist operates")]
        public City City { get; set; } = null!;

        [Comment("List of specialist's projects")]
        public ICollection<Project> Projects { get; set; } = new List<Project>();

        [Required]
        [Comment("A boolean stating if the specialist is available to be hired")]
        public bool IsBusy { get; set; } = false;

        //[Required]
        //[Comment("User's identifier")]
        //public string UserId { get; set; } = string.Empty;

        //[ForeignKey(nameof(UserId))]
        //public IdentityUser User { get; set; } = null!;
    }
}
