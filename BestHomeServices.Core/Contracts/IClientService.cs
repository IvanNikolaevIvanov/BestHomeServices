using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BestHomeServices.Core.Contracts
{
    public interface IClientService
    {
        Task AddClientAsync(string userId, string name, string address, string city, string phoneNumber);
        Task<bool> ClientExistsAsync(string id);
    }
}
