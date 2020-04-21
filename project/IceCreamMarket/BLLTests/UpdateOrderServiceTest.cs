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
    public class UpdateOrderServiceTest
    {
        [Test]
        public async Task UpdateOrderSuccess()
        {
            // Arrange
            var order = new Order();
            var orderDataAccessMock = new Mock<IOrderDataAccess>();

            orderDataAccessMock
                .Setup(dataAccess => dataAccess.UpdateOrder(order))
                .ReturnsAsync(true);
            
            var getOrderService = new UpdateOrderService(orderDataAccessMock.Object);
            
            // Act
            var action = await getOrderService.UpdateOrder(order);
            
            // Assert
            Assert.IsTrue(action);
            orderDataAccessMock.Verify();
        }
        
        [Test]
        public async Task UpdateOrderFailure()
        {
            // Arrange
            var order = new Order();
            var orderDataAccessMock = new Mock<IOrderDataAccess>();

            orderDataAccessMock
                .Setup(dataAccess => dataAccess.UpdateOrder(order))
                .ReturnsAsync(false);
            
            var getOrderService = new UpdateOrderService(orderDataAccessMock.Object);
            
            // Act
            var action = await getOrderService.UpdateOrder(order);
            
            // Assert
            Assert.IsFalse(action);
            orderDataAccessMock.Verify();
        }
        
        [Test]
        public async Task UpdateOrderArgumentNullFailure()
        {
            // Arrange
            var discountService = new DiscountService();
            var orderDataAccessMock = new Mock<IOrderDataAccess>();

            orderDataAccessMock
                .Setup(dataAccess => dataAccess.UpdateOrder(null))
                .ThrowsAsync(new ArgumentNullException());
            
            var getOrderService = new UpdateOrderService(orderDataAccessMock.Object);
            
            // Act
            var action = new Func<Task>(() => getOrderService.UpdateOrder(null));
            
            // Assert
            await action.Should().ThrowAsync<ArgumentNullException>("Null params");
            orderDataAccessMock.Verify();
        }
        
        [Test]
        public async Task DeleteOrderSuccess()
        {
            // Arrange
            var orderIdentityMock = new Mock<IOrderIdentity>();
            var orderDataAccessMock = new Mock<IOrderDataAccess>();

            orderDataAccessMock
                .Setup(dataAccess => dataAccess.DeleteOrder(orderIdentityMock.Object))
                .ReturnsAsync(true);
            
            var getOrderService = new UpdateOrderService(orderDataAccessMock.Object);
            
            // Act
            var action = await getOrderService.DeleteOrder(orderIdentityMock.Object);
            
            // Assert
            Assert.IsTrue(action);
            orderDataAccessMock.Verify();
        }
        
        [Test]
        public async Task DeleteOrderFailure()
        {
            // Arrange
            var orderIdentityMock = new Mock<IOrderIdentity>();
            var orderDataAccessMock = new Mock<IOrderDataAccess>();

            orderDataAccessMock
                .Setup(dataAccess => dataAccess.DeleteOrder(orderIdentityMock.Object))
                .ReturnsAsync(false);
            
            var getOrderService = new UpdateOrderService(orderDataAccessMock.Object);
            
            // Act
            var action = await getOrderService.DeleteOrder(orderIdentityMock.Object);
            
            // Assert
            Assert.IsFalse(action);
            orderDataAccessMock.Verify();
        }
        
        [Test]
        public async Task DeleteOrderArgumentNullFailure()
        {
            // Arrange
            var orderDataAccessMock = new Mock<IOrderDataAccess>();

            orderDataAccessMock
                .Setup(dataAccess => dataAccess.DeleteOrder(null))
                .ThrowsAsync(new ArgumentNullException());
            
            var getOrderService = new UpdateOrderService(orderDataAccessMock.Object);
            
            // Act
            var action = new Func<Task>(() => getOrderService.DeleteOrder(null));
            
            // Assert
            await action.Should().ThrowAsync<ArgumentNullException>("Null params");
            orderDataAccessMock.Verify();
        }
        
    }
}