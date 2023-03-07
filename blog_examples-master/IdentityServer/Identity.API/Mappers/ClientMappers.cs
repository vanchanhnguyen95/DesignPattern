using AutoMapper;
using Identity.API.Models;
using IdentityServer4.EntityFramework.Entities;
using System.Collections.Generic;

namespace Identity.API.Mappers
{
    public static class ClientMappers
    {
        static ClientMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClientMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static ClientViewModel ToModel(this Client client)
        {
            return Mapper.Map<ClientViewModel>(client);
        }

        public static List<ClientViewModel> ToModel(this List<Client> clients)
        {
            return Mapper.Map<List<ClientViewModel>>(clients);
        }

        public static Client ToEntity(this ClientViewModel client)
        {
            return Mapper.Map<Client>(client);
        }
    }
}