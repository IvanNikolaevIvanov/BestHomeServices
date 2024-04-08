using BestHomeServices.Core.Enumerations;
using BestHomeServices.Core.Models.Category;
using BestHomeServices.Core.Models.Home;

namespace BestHomeServices.Core.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync(
            CityEnumeration cityEnumeration = CityEnumeration.All
            , string? category = null
            );

        Task<bool> ExistsAsync(int id);

        Task<CategoryDetailsViewModel> CategoryDetailsByIdAsync(int id);

    }
}
