using AutoMapper;
using Identity.API.Models;
using IdentityServer4.EntityFramework.Entities;

namespace Identity.API.Mappers
{
    public class ClientMapperProfile : Profile
    {
        public ClientMapperProfile()
        {
            CreateMap<Client, ClientViewModel>(MemberList.Destination)
                .ReverseMap();

        }
    }
}