using BestHomeServices.Core.Enumerations;
using BestHomeServices.Core.Models.Category;
using BestHomeServices.Core.Models.Home;
using BestHomeServices.Infrastructure.Data.Models;

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

        Task AddCategoryAsync(CategoryFormModel model);

        Task DeleteCategoryAsync(int id);

        Task EditAsync(int id, CategoryDetailsViewModel model);

        Task<CategoryFormModel> GetCategoryFormByIdAsync(int id);

    }
}
