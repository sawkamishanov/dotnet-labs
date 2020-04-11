using System;
using System.Threading.Tasks;
using BLL.Services.OrderService.Implementations;
using Data.Repositories;
using Domain;
using Domain.Entities;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BLLTests
{
    [TestFixture]
    public class GetOrderServiceTest
    {
        [Test]
        public async Task GetSuccess()
        {
            // Arrange
            var orderIdentityMock = new Mock<IEntityIdentity>();
            var order = new Order();
            var orderDataAccessMock = new Mock<IRepository<Order>>();

            orderDataAccessMock
                .Setup(repository => repository.Get(orderIdentityMock.Object))
                .ReturnsAsync(order);
            
            var getOrderService = new GetOrderService(orderDataAccessMock.Object);
            
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
            
            
            // Act
            // Assert
        }
    }
}