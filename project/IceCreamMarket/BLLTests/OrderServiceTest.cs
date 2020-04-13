using System;
using System.Threading.Tasks;
using BLL.Services.OrderService.Implementations;
using BLL.Services.OrderService.Repositories;
using Data.Repositories;
using Domain;
using Domain.Entities;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BLLTests
{
    [TestFixture]
    public class OrderServiceTest
    {
        [Test]
        public async Task GetSuccess()
        {
            // Arrange
            var orderIdentityMock = new Mock<IEntityIdentity>();
            var order = new Order();
            var discountService = new Mock<IDiscountService>();
            var orderDataAccessMock = new Mock<IRepository<Order>>();

            orderDataAccessMock
                .Setup(repository => repository.Get(orderIdentityMock.Object))
                .ReturnsAsync(order);
            
            var getOrderService = new OrderService(orderDataAccessMock.Object, discountService.Object);
            
            // Act
            var action = await getOrderService.GetOrder(orderIdentityMock.Object);
            
            // Assert
            action.Should().Be(order);
            orderDataAccessMock.Verify();
        }

        [Test]
        public async Task GetFailure()
        {
            // Arrange
            var orderIdentityMock = new Mock<IEntityIdentity>();
            var orderDataAccessMock = new Mock<IRepository<Order>>();
            var discountService = new Mock<IDiscountService>();

            orderDataAccessMock
                .Setup(repository => repository.Get(orderIdentityMock.Object))
                .ReturnsAsync((Order) null);

            var getOrderService = new OrderService(orderDataAccessMock.Object, discountService.Object);
            
            // Act
            var action = new Func<Task>(() => getOrderService.GetOrder(orderIdentityMock.Object));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>("Not found by id");
        }
    }
}