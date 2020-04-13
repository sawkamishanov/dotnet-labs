using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Services.ClientService.Repositories;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    // postman tests
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private ICreateClientService CreateClientService { get; }
        private IGetClientService GetClientService { get; }
        private IMapper Mapper { get; }

        public ClientController(ICreateClientService createClientService, IGetClientService getClientService, IMapper mapper)
        {
            CreateClientService = createClientService;
            GetClientService = getClientService;
            Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task Put(ClientDTO client)
        {
            await CreateClientService.CreateClient(Mapper.Map<Client>(client));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ClientDTO> Get(int id)
        {
            var result = await GetClientService.GetClient(new EntityModel(id));

            return Mapper.Map<ClientDTO>(result);
        }
        
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ClientDTO>> Get()
        {
            var result = await GetClientService.GetClient();

            return Mapper.Map<IEnumerable<ClientDTO>>(result);
        }
    }
}