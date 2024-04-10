using BestHomeServices.Core.Models.Specialist;

namespace BestHomeServices.Core.Models.Client
{
    public class ShowClientInfoModel
    {
        public ClientsServiceModel ClientInfo { get; set; } = null!;

        public IEnumerable<SpecialistViewModel> ClientSpecialists { get; set; } = null!;
    }
}
