namespace BestHomeServices.Core.Models.Specialist
{
    public class SpecialistViewModel
    {
        public int Id { get; set; }

        public bool IsBusy { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

    }
}
