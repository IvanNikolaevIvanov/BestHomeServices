namespace BestHomeServices.Core.Models.Client
{
    public class ClientDetailsViewModel
    {
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public int CityId { get; set; }

        public string CityName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public int SpecialistId { get; set; }

        public string SpecialistName { get; set; } = string.Empty;
    }
}
