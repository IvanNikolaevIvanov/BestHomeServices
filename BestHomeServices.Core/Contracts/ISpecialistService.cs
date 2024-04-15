using BestHomeServices.Core.Models.Category;
using BestHomeServices.Core.Models.Specialist;
using BestHomeServices.Infrastructure.Data.Models;

namespace BestHomeServices.Core.Contracts
{
    public interface ISpecialistService
    {
        Task<bool> SpecialistExistsAsync(int id);

        Task HireSpecialistByIdAsync(Specialist specialist, Client client);

        Task<Specialist?> GetSpecialistByIdAsync(int id);

        Task<IEnumerable<SpecialistDetailsViewModel>> GetAllSpecialistsAsync();

        Task AddSpecialistAsync(AddSpecialistFormModel model);

        Task DeleteSpecialistAsync(int id);

        Task EditSpecialistAsync(int id, AddSpecialistFormModel model);

        Task<AddSpecialistFormModel> GetSpecialistFormByIdAsync(int id);
    }
}
