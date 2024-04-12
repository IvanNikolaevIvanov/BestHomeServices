using BestHomeServices.Core.Models.Specialist;
using BestHomeServices.Infrastructure.Data.Models;

namespace BestHomeServices.Core.Contracts
{
    public interface ISpecialistService
    {
        Task<bool> SpecialistExistsAsync(int id);

        Task HireSpecialistByIdAsync(Specialist specialist, Client client);

        Task<Specialist> GetSpecialistByIdAsync(int id);
    }
}
