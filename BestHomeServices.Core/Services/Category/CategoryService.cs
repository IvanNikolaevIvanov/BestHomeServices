using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Models.Category;
using BestHomeServices.Core.Models.Home;
using BestHomeServices.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace BestHomeServices.Core.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository repository;

        public CategoryService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<CategoryViewModel>> AllCategories()
        {
            return await repository
                .AllReadOnly<Infrastructure.Data.Models.Category>()
                .OrderBy(c => c.Id)
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    ImgUrl = c.ImgUrl
                }).ToListAsync();
        }
    }
}
