using System.ComponentModel.DataAnnotations;

namespace BestHomeServices.Core.Models.Client
{
    public class ClientsServiceModel
    {
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public int CityId { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

    }
}
