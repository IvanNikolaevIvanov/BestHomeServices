using System.ComponentModel.DataAnnotations;
using static BestHomeServices.Core.Constants.MessageConstants;
using static BestHomeServices.Infrastructure.Constants.DataConstants;

namespace BestHomeServices.Core.Models.Client
{
    public class ClientInfoForm
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ClientNameMaxLength,
            MinimumLength = ClientNameMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "First And Last Name")]
        public string ClientName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(CityNameMaxLength,
            MinimumLength = CityNameMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "City")]
        public string ClientCity { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ClientAddressMaxLength,
            MinimumLength = ClientAddressMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Address")]
        public string ClientAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ClientPhoneNumberMaxLength,
            MinimumLength = ClientPhoneNumberMinLength,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Phone number")]
        public string ClientPhoneNumber { get; set; } = string.Empty;
    }
}
