using System.ComponentModel.DataAnnotations;
using static BestHomeServices.Core.Constants.MessageConstants;
using static BestHomeServices.Infrastructure.Constants.DataConstants;

namespace BestHomeServices.Core.Models.City
{
    public class CityFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(CityNameMaxLength,
            MinimumLength = CityNameMinLength,
            ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;
    }
}
