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

        public Task<HireSpecialistFormModel> HireSpecialistByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
