using IdentityServer4.EntityFramework.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.API.Repositories
{
    public interface IClientRepository
    {

        Task<List<Client>> GetClientsAsync(string search = "", int page = 1, int pageSize = 10);
    }
}
