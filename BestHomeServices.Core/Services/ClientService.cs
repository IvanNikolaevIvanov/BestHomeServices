using BestHomeServices.Core.Contracts;
using BestHomeServices.Core.Models.City;
using BestHomeServices.Core.Models.Client;
using BestHomeServices.Core.Models.Specialist;
using BestHomeServices.Infrastructure.Data.Common;
using BestHomeServices.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace BestHomeServices.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository repository;
        private readonly ICityService cityService;

        public ClientService(
            IRepository _repository,
            ICityService _cityService)
        {
            repository = _repository;
            cityService = _cityService;
        }

        public async Task AddClientAsync(string userId, string name, string address, string city, string phoneNumber)
        {
            var currentCity = await repository.AllReadOnly<City>()
                .FirstAsync(c => c.Name == city);

            await repository.AddAsync(new Client()
            {
                UserId = userId,
                Name = name,
                Address = address,
                PhoneNumber = phoneNumber,
                CityId = currentCity.Id
            });

            await repository.SaveChangesAsync();
        }

        public async Task<bool> ClientExistsAsync(string id)
        {
            return await repository.AllReadOnly<Client>()
                .AnyAsync(c => c.UserId == id);
        }

        public async Task EditInfoAsync(string userId, ClientInfoForm model)
        {
            Client client = await repository.All<Client>()
                .FirstAsync(client => client.UserId == userId);

            var clientCity = await repository.AllReadOnly<City>()
                .Where(c => c.Name == model.ClientCity)
                .FirstOrDefaultAsync();

            if (clientCity == null)
            {
                throw new ArgumentException("Service is not provided in this city");
            }

            client.Name = model.ClientName;
            client.Address = model.ClientAddress;
            client.CityId = clientCity.Id;
            client.PhoneNumber = model.ClientPhoneNumber;
            
            await repository.SaveChangesAsync();
        }

        public async Task<ClientsServiceModel> GetClientByUserId(string id)
        {
            var client = await repository.AllReadOnly<Client>()
               .FirstAsync(c => c.UserId == id);
            var model = new ClientsServiceModel()
            {
                Address = client.Address,
                CityId = client.CityId,
                Name = client.Name,
                PhoneNumber = client.PhoneNumber
            };

            return model;
        }

        public async Task<Client> GetClientEntityByUserIdAsync(string id)
        {
            return await repository.All<Client>()
                .FirstAsync(c => c.UserId == id);
        }

        public async Task<ShowClientInfoModel> GetClientInfoByUserId(string id)
        {
            var model = new ShowClientInfoModel();

            var client = await repository.AllReadOnly<Client>()
                .FirstAsync(c => c.UserId == id);

            model.ClientInfo = new ClientsServiceModel()
            {
                Name = client.Name,
                Address = client.Address,
                PhoneNumber = client.PhoneNumber,
                CityId = client.CityId,
                UserId = client.UserId
            };

            var clientSpecialists = await repository.AllReadOnly<Specialist>()
                .Where(s => s.Projects.Any(p => p.ClientId == client.Id))
                .Select(s => new SpecialistViewModel()
                {
                    Id = s.Id,
                    IsBusy = s.IsBusy,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Description = s.Description,
                    ImageUrl = s.ImageUrl,
                    PhoneNumber = s.PhoneNumber
                })
                .ToListAsync();

            model.ClientSpecialists = clientSpecialists;

            return model;
        }

        public async Task RemoveSpecialistFromClient(string userId, int specialistId)
        {
            var client = await repository.All<Client>()
               .FirstAsync(c => c.UserId == userId);

            var projectToDelete = await repository.AllReadOnly<Project>()
                .FirstOrDefaultAsync(p => p.ClientId == client.Id && p.SpecialistId == specialistId);

            if (projectToDelete != null)
            {
                await repository.DeleteAsync<Project>(projectToDelete);
            }

            var specialist = await repository.GetByIdAsync<Specialist>(specialistId);

            if (specialist != null)
            {
                specialist.IsBusy = false;
            }

            await repository.SaveChangesAsync();
        }
    }
}
