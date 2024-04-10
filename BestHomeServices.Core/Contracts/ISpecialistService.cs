using BestHomeServices.Core.Models.Specialist;
using BestHomeServices.Infrastructure.Data.Models;

namespace BestHomeServices.Core.Contracts
{
    public interface ISpecialistService
    {
        Task<bool> SpecialistExistsAsync(int id);

        Task HireSpecialistByIdAsync(int specialistId, string userId);

        Task<Specialist> GetSpecialistByIdAsync(int id);
    }
}
