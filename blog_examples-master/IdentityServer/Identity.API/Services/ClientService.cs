using Identity.API.Mappers;
using Identity.API.Models;
using Identity.API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.API.Services
{
    public class ClientService : IClientService
    {
        protected readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<ClientViewModel>> GetClientsAsync(string search, int page = 1, int pageSize = 10)
        {
            var result = await _clientRepository.GetClientsAsync(search, page, pageSize);

            return result.ToModel();
        }
    }
}
