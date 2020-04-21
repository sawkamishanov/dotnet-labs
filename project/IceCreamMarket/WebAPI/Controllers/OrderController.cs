using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Services.OrderService.Implementations;
using BLL.Services.OrderService.Contracts;
using Domain;
using Domain.Entities;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    // postman test
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private IOrderService OrderService { get; }
        private IUpdateOrderService UpdateOrderService { get; }
        private IDiscountService DiscountService { get; }
        private IMapper Mapper { get; }
        private ILogger<OrderController> Logger { get; }

        public OrderController(
            IOrderService orderService,
            IUpdateOrderService updateOrderService,
            IDiscountService discountService,
            IMapper mapper,
            ILogger<OrderController> logger
        )
        {
            OrderService = orderService;
            UpdateOrderService = updateOrderService;
            DiscountService = discountService;
            Mapper = mapper;
            Logger = logger;
        }

        [HttpPut]
        [Route("")]
        public async Task Put(OrderDTO order)
        {
            Logger.LogTrace($"{nameof(Put)} called");
            await OrderService.MakeOrder(Mapper.Map<Order>(order));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<OrderDTO> Get(int id)
        {
            var result = await OrderService.GetOrder(new OrderIdentityModel(id));

            return Mapper.Map<OrderDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<OrderDTO>> Get()
        {
            var result = await OrderService.GetOrder();
            
            return Mapper.Map<IEnumerable<OrderDTO>>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task Patch(OrderDTO order)
        {
            await UpdateOrderService.UpdateOrder(Mapper.Map<Order>(order));
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task Delete(int id)
        {
            await UpdateOrderService.DeleteOrder(new OrderIdentityModel(id));
        }
    }
}