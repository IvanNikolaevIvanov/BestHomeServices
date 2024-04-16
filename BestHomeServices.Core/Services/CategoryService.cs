using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Enumerations;
using BestHomeServices.Core.Models.Category;
using BestHomeServices.Core.Models.Specialist;
using BestHomeServices.Infrastructure.Data.Common;
using BestHomeServices.Infrastructure.Data.Models;
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
            CityEnumeration cityEnumeration = CityEnumeration.All
            , string? category = null
            )
        {
            var categoriesToShow = await repository.AllReadOnly<Category>()
                .Include(c => c.Specialists)
                .ThenInclude(s => s.City)
                .Select(c => new CategoryDetailsQueryServiceModel()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    ImgUrl = c.ImgUrl,
                    Specialists = c.Specialists.Select(s => new SpecialistViewModel()
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Description = s.Description,
                        ImageUrl = s.ImageUrl,
                        IsBusy = s.IsBusy,
                        PhoneNumber = s.PhoneNumber,
                        CityId = s.CityId,
                        CityName = s.City.Name

                    })
                })
                .ToListAsync();

            if (category != null && category != "All")
            {
                categoriesToShow = categoriesToShow
                    .Where(c => c.Title == category)
                    .ToList();
            }

            if (cityEnumeration != CityEnumeration.All)
            {
                categoriesToShow = categoriesToShow
                    .Where(c => c.Specialists
                                   .Any(s => s.CityName == cityEnumeration.ToString()))
                    .ToList();

            }

            var categoriesToReturn = categoriesToShow
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    ImgUrl = c.ImgUrl
                })
                .ToList();

            return categoriesToReturn;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllReadOnly<Category>()
                .AnyAsync(c => c.Id == id);
        }

        public async Task<CategoryDetailsViewModel> CategoryDetailsByIdAsync(int id)
        {
            var categorySpecialists = await repository.AllReadOnly<Specialist>()
                .Include(s => s.City)
                .Where(s => s.CategoryId == id)
                .Where(s => s.IsBusy == false)
                .ToListAsync();

            var specialistsToAdd = new List<SpecialistViewModel>();

            if (categorySpecialists.Any())
            {
                specialistsToAdd = categorySpecialists
               .Select(s => new SpecialistViewModel()
               {
                   Id = s.Id,
                   FirstName = s.FirstName,
                   LastName = s.LastName,
                   Description = s.Description,
                   ImageUrl = s.ImageUrl,
                   PhoneNumber = s.PhoneNumber,
                   CityId = s.CityId,
                   CityName = s.City.Name
               })
               .ToList();
            }


            var category = await repository.AllReadOnly<Category>()
                .Where(c => c.Id == id)
                .Select(c => new CategoryDetailsViewModel()
                {
                    Title = c.Title,
                    Description = c.Description,
                    ImgUrl = c.ImgUrl,

                })
                .FirstAsync();

            category.Specialists = specialistsToAdd;

            return category;
        }

        public async Task AddCategoryAsync(CategoryFormModel model)
        {
            Category categoryToAdd = new Category();

            categoryToAdd.Title = model.Title;
            categoryToAdd.Description = model.Description;
            categoryToAdd.ImgUrl = model.ImgUrl;

            await repository.AddAsync(categoryToAdd);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await repository.DeleteAsync<Category>(id);
            await repository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, CategoryDetailsViewModel model)
        {
            var category = await repository.GetByIdAsync<Category>(id);

            if (category != null)
            {
                category.Title = model.Title;
                category.Description = model.Description;
                category.ImgUrl = model.ImgUrl;

                await repository.SaveChangesAsync();
            }

        }

        public async Task<CategoryFormModel> GetCategoryFormByIdAsync(int id)
        {
            var category = await repository.AllReadOnly<Category>()
                .Where(c => c.Id == id)
                .Select(c => new CategoryFormModel()
                {
                    Title = c.Title,
                    Description = c.Description,
                    ImgUrl = c.ImgUrl,
                })
                .FirstAsync();



            return category;
        }
    }
}
