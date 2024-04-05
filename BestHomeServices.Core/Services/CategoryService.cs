using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Models.Category;
using BestHomeServices.Core.Models.City;
using BestHomeServices.Core.Models.Home;
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

        public async Task<bool> ExistsAsync(int id)
        {

            return await repository.AllReadOnly<Category>()
                .AnyAsync(c => c.Id == id);
        }

        public async Task<CategoryFormModel> CategoryDetailsByIdAsync(int id)
        {
            var categorySpecialists = await repository.AllReadOnly<Specialist>()
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
                   Name = s.FirstName
               })
               .ToList();
            }

            //var cities = await repository.AllReadOnly<City>()
            //    .ToListAsync();

            //var citiesToAdd = new List<CityViewModel>();

            //foreach (var specialist in categorySpecialists)
            //{
            //    var cityId = specialist.CityId;

            //    if (!categoryCities.Contains(specialist.City))
            //    {
            //        categoryCities.Add(specialist.City);
            //    }
            //}  

            //if (categoryCities.Any(c => c != null))
            //{
            //     citiesToAdd = categoryCities
            //    .Select(c => new CityViewModel()
            //    {
            //        Id = c.Id,
            //        Name = c.Name
            //    })
            //    .ToList();
            //}
            

            var category = await repository.AllReadOnly<Category>()
                .Where(c => c.Id == id)
                .Select(c => new CategoryFormModel()
                {
                    Title = c.Title,
                    Description = c.Description,
                    ImgUrl = c.ImgUrl,
                    Client = new Models.Client.ClientsServiceModel()

                })
                .FirstAsync();

            category.Specialists = specialistsToAdd;

            return category;
        }
    }
}
