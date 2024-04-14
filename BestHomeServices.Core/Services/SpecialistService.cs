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

        public async Task<Specialist> GetSpecialistByIdAsync(int id)
        {
            return await repository.All<Specialist>()
                .FirstAsync(s => s.Id == id);
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
    }
}
