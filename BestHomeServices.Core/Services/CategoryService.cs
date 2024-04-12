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
            var categoriesToShow = repository.AllReadOnly<Category>();

            if (category != null && category != "All")
            {
                categoriesToShow = categoriesToShow
                    .Where(c => c.Title == category);
            }

            if (cityEnumeration != CityEnumeration.All)
            {
                categoriesToShow = categoriesToShow
                    .Where(c => c.Cities.Any(c => c.Name == cityEnumeration.ToString()));
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

        public async Task<CategoryDetailsViewModel> CategoryDetailsByIdAsync(int id)
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
                   FirstName = s.FirstName,
                   LastName = s.LastName,
                   Description = s.Description,
                   ImageUrl = s.ImageUrl,
                   PhoneNumber = s.PhoneNumber
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
                .Select(c => new CategoryDetailsViewModel()
                {
                    Title = c.Title,
                    Description = c.Description,
                    ImgUrl = c.ImgUrl,
                    //Client = new Models.Client.ClientsServiceModel()

                })
                .FirstAsync();

            category.Specialists = specialistsToAdd;

            return category;
        }
    }
}
