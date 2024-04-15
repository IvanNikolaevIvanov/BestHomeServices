using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Models.Category;
using BestHomeServices.Core.Models.Specialist;
using BestHomeServices.Infrastructure.Data.Common;
using BestHomeServices.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BestHomeServices.Core.Services
{
    public class SpecialistService : ISpecialistService
    {
        private readonly IRepository repository;

        public SpecialistService(IRepository _repository)
        {
            repository = _repository;
        }

        public Task<bool> SpecialistExistsAsync(int id)
        {
            return repository.AllReadOnly<Specialist>()
                .AnyAsync(s => s.Id == id);
        }


        public async Task HireSpecialistByIdAsync(Specialist specialist, Client client)
        {
            //var specialist = await repository.All<Specialist>()
            //    .FirstOrDefaultAsync(s => s.Id == specialistId);

            //var client = await repository.All<Client>()
            //    .FirstOrDefaultAsync(c => c.UserId == userId);


            if (specialist != null && client != null)
            {

                var newProject = new Project()
                {
                    SpecialistId = specialist.Id,
                    ClientId = client.Id
                };

                await repository.AddAsync(newProject);

                specialist.IsBusy = true;
                specialist.Projects.Add(newProject);

                await repository.SaveChangesAsync();
            }


        }

        public async Task<Specialist?> GetSpecialistByIdAsync(int id)
        {
            return await repository.GetByIdAsync<Specialist>(id);  
        }

        public async Task<IEnumerable<SpecialistDetailsViewModel>> GetAllSpecialistsAsync()
        {
            var specialists = await repository.AllReadOnly<Specialist>()
                .Include(s => s.Category)
                .Include(s => s.City)
                .Include(s => s.Projects)
                .Select(s => new SpecialistDetailsViewModel()
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Description = s.Description,
                    ImageUrl = s.ImageUrl,
                    PhoneNumber = s.PhoneNumber,
                    CategoryId = s.CategoryId,
                    CityName = s.City.Name,
                    CategoryName = s.Category.Title,
                    CityId = s.CityId,
                    IsBusy = s.IsBusy,
                    NumberOfProjects = s.Projects.Count()
                })
                .ToListAsync();

            return specialists;
        }

        public async Task AddSpecialistAsync(AddSpecialistFormModel model)
        {
            Specialist specialistToAdd = new Specialist()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                CityId = model.CityId,
                PhoneNumber = model.PhoneNumber
            };

            await repository.AddAsync(specialistToAdd);
            await repository.SaveChangesAsync();
        }

        public async Task DeleteSpecialistAsync(int id)
        {
            await repository.DeleteAsync<Specialist>(id);
            await repository.SaveChangesAsync();
        }

        public async Task EditSpecialistAsync(int id, AddSpecialistFormModel model)
        {
            var specialistToEdit = await GetSpecialistByIdAsync(id);

            if (specialistToEdit != null)
            {
                specialistToEdit.FirstName = model.FirstName;
                specialistToEdit.LastName = model.LastName;
                specialistToEdit.PhoneNumber = model.PhoneNumber;
                specialistToEdit.Description = model.Description;
                specialistToEdit.CategoryId = model.CategoryId;
                specialistToEdit.CityId = model.CityId;
                specialistToEdit.ImageUrl = model.ImageUrl;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<AddSpecialistFormModel> GetSpecialistFormByIdAsync(int id)
        {
            var specialist = await repository.AllReadOnly<Specialist>()
                .Where(s => s.Id == id)
                .Select(s => new AddSpecialistFormModel()
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    CategoryId = s.CategoryId,
                    CityId = s.CityId,
                    Description = s.Description,
                    ImageUrl = s.ImageUrl,
                    PhoneNumber = s.PhoneNumber
                })
                .FirstAsync();

            return specialist;
        }
    }
}
