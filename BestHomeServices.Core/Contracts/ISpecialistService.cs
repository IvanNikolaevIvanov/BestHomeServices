using BestHomeServices.Core.Models.Specialist;

namespace BestHomeServices.Core.Contracts
{
    public interface ISpecialistService
    {
        Task<bool> SpecialistExistsAsync(int id);

        Task HireSpecialistByIdAsync(int specialistId, string userId);
    }
}
