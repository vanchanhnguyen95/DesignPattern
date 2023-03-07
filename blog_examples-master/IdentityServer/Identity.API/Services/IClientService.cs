using Identity.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.API.Services
{
    public interface IClientService
    {

        Task<List<ClientViewModel>> GetClientsAsync(string search, int page = 1, int pageSize = 10);
    }
}
