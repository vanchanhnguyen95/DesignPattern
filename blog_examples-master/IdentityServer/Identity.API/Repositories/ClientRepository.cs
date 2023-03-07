using Identity.API.Extensions;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Identity.API.Repositories
{
    public class ClientRepository<TDbContext> : IClientRepository 
        where TDbContext : DbContext, IConfigurationDbContext
    {
        protected readonly TDbContext _dbContext;

        public ClientRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Client>> GetClientsAsync(string search = "", int page = 1, int pageSize = 10)
        {
            var clients = new List<Client>();

            Expression<Func<Client, bool>> searchCondition = x => x.ClientId.Contains(search) || x.ClientName.Contains(search);
            return await _dbContext.Clients.WhereIf(!string.IsNullOrEmpty(search), searchCondition).PageBy(x => x.Id, page, pageSize).ToListAsync();
        }
    }
}
