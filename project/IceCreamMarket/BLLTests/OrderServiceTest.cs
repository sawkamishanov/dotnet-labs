using System;
using System.Threading.Tasks;
using BLL.Services.OrderService.Contracts;
using BLL.Services.OrderService.Implementations;
using Data.Contracts;
using Domain.Contracts;
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
            var orderIdentityMock = new Mock<IOrderIdentity>();
            var order = new Order();
            var discountService = new Mock<IDiscountService>();
            var orderDataAccessMock = new Mock<IOrderDataAccess>();

            orderDataAccessMock
                .Setup(dataAccess => dataAccess.Get(orderIdentityMock.Object))
                .ReturnsAsync(order);
            
            var getOrderService = new OrderService(orderDataAccessMock.Object, discountService.Object);
            
            // Act
            var action = await getOrderService.GetOrder(orderIdentityMock.Object);
            
            // Assert
            action.Should().Be(order);
            orderDataAccessMock.Verify();
        }

        [Test]
        public async Task GetInvalidOperationFailure()
        {
            // Arrange
            var orderIdentityMock = new Mock<IOrderIdentity>();
            var orderDataAccessMock = new Mock<IOrderDataAccess>();
            var discountService = new DiscountService();

            orderDataAccessMock
                .Setup(dataAccess => dataAccess.Get(orderIdentityMock.Object))
                .ReturnsAsync((Order) null);

            var getOrderService = new OrderService(orderDataAccessMock.Object, discountService);

            // Act
            var action = new Func<Task>(() => getOrderService.GetOrder(orderIdentityMock.Object));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>("Not found by id");
        }
        
        [Test]
        public async Task GetArgumentNullFailure()
        {
            // Arrange
            var discountService = new DiscountService();
            var orderDataAccessMock = new Mock<IOrderDataAccess>();

            orderDataAccessMock
                .Setup(dataAccess => dataAccess.Get(null))
                .ThrowsAsync(new ArgumentNullException());
            
            var getOrderService = new OrderService(orderDataAccessMock.Object, discountService);
            
            // Act
            var action = new Func<Task>(() => getOrderService.GetOrder(null));
            
            // Assert
            await action.Should().ThrowAsync<ArgumentNullException>("Null params");
        }
        
        [Test]
        public async Task MakeOrderSuccess()
        {
            // Arrange
            var order = new Order();
            var returnOrder = new Order();
            var discountService = new Mock<DiscountService>();
            var orderDataAccessMock = new Mock<IOrderDataAccess>();

            orderDataAccessMock
                .Setup(dataAccess => dataAccess.CreateOrder(order))
                .ReturnsAsync(returnOrder);
            
            var makeOrderService = new OrderService(orderDataAccessMock.Object, discountService.Object);
            
            // Act
            var action = await makeOrderService.MakeOrder(order);
            
            // Assert
            action.Should().Be(returnOrder);
            orderDataAccessMock.Verify();
        }

        [Test]
        public async Task MakeOrderArgumentNullFailure()
        {
            // Arrange
            var discountService = new DiscountService();
            var orderDataAccessMock = new Mock<IOrderDataAccess>();

            orderDataAccessMock
                .Setup(dataAccess => dataAccess.CreateOrder(null))
                .ThrowsAsync(new ArgumentNullException());
            
            var makeOrderService = new OrderService(orderDataAccessMock.Object, discountService);
            
            // Act
            var action = new Func<Task>(() => makeOrderService.MakeOrder(null));
            
            // Assert
            await action.Should().ThrowAsync<ArgumentNullException>("Null params");
        }
    }
}