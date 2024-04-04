using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Models.Category;
using BestHomeServices.Core.Models.Home;
using BestHomeServices.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace BestHomeServices.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository repository;

        public CategoryService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync(
            string? categoryTitle = null,
            string? city = null)
        {
            var categoriesToShow = repository.AllReadOnly<Infrastructure.Data.Models.Category>();

            if (categoryTitle != null)
            {
                categoriesToShow = categoriesToShow
                    .Where(c => c.Title == categoryTitle);
            }

            if (city != null)
            {
                categoriesToShow = categoriesToShow
                    .Where(c => c.Cities.Any(c => c.Name == city));
            }

            var categories = await categoriesToShow
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    ImgUrl = c.ImgUrl
                })
                .ToListAsync();

            return categories;
        }
    }
}
