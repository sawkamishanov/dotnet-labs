using AutoMapper;
using Data.DataSources;
using Domain.Entities;
using WebAPI.DTO;

namespace WebAPI
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Client, ClientDataSource>();
            CreateMap<ClientDataSource, Client>();
            CreateMap<Client, ClientDTO>();
            CreateMap<ClientDTO, Client>();
            CreateMap<Order, OrderDataSource>();
            CreateMap<OrderDataSource, Order>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
        }
    }
}