using BestHomeServices.Core.Models.Specialist;

namespace BestHomeServices.Core.Contracts
{
    public interface ISpecialistService
    {
        Task<bool> SpecialistExistsAsync(int id);

        Task<HireSpecialistFormModel> HireSpecialistByIdAsync(int id);
    }
}
