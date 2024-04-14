using System.ComponentModel.DataAnnotations;
using static BestHomeServices.Core.Constants.MessageConstants;
using static BestHomeServices.Infrastructure.Constants.DataConstants;

namespace BestHomeServices.Core.Models.Category
{
    public class CategoryFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(CategoryTitleMaxLength,
            MinimumLength = CategoryTitleMinLength,
            ErrorMessage = LengthMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(CategoryDescriptionMaxLength,
            MinimumLength = CategoryDescriptionMinLength,
            ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [MaxLength(CategoryImageUrlMaxLength)]
        public string ImgUrl { get; set; } = string.Empty;
    }
}
