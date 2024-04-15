using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BestHomeServices.Core.Constants.MessageConstants;
using static BestHomeServices.Infrastructure.Constants.DataConstants;

namespace BestHomeServices.Core.Models.Specialist
{
    public class AddSpecialistFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(SpecialistFirstNameMaxLength,
            MinimumLength = SpecialistFirstNameMinLength,
            ErrorMessage = LengthMessage)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(SpecialistLastNameMaxLength,
            MinimumLength = SpecialistLastNameMinLength,
            ErrorMessage = LengthMessage)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(SpecialistPhoneNumberMaxLength,
            MinimumLength = SpecialistPhoneNumberMinLength,
            ErrorMessage = LengthMessage)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(SpecialistDescriptionMaxLength,
            MinimumLength = SpecialistDescriptionMinLength,
            ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [MaxLength(SpecialistImageUrlMaxLength)]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(int),
            SpecialistCategoryIdMinimum,
            SpecialistCategoryIdMaximum,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = "Category ID must be a whole positive number and less than {2}")]
        [Display(Name = "Category Id")]
        [Comment("Category Identifier")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(int),
            SpecialistCityIdMinimum,
            SpecialistCityIdMaximum,
            ErrorMessage = "City ID must be a whole positive number and less than {2}")]
        [Display(Name = "City Id")]
        [Comment("Specialist's city identifier.")]
        public int CityId { get; set; }
    }
}
