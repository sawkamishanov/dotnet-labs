using AutoMapper;
using Data.DataSources;
using Domain.Entities;

namespace BLL
{
    public class MapperInit: Profile
    {
        public MapperInit()
        {
            CreateMap<Client, ClientDataSource>();
            CreateMap<ClientDataSource, Client>();
            CreateMap<Order, OrderDataSource>();
            CreateMap<OrderDataSource, Order>();
        }
    }
}