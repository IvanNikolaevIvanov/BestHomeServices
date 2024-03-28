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

        [Comment("The cities in which the specialist operates")]
        public ICollection<City> Cities { get; set; } = new List<City>();

        [Comment("List of specialist's projects")]
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
