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


        public async Task HireSpecialistByIdAsync(int specialistId, string userId)
        {
            var specialist = await repository.AllReadOnly<Specialist>()
                .FirstOrDefaultAsync(s => s.Id == specialistId);

            var client = await repository.AllReadOnly<Client>()
                .FirstOrDefaultAsync(c => c.UserId == userId);


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


    }
}
