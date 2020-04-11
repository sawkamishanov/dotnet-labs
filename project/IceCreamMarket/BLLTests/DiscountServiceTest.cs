using System;
using BLL.Services.OrderService.Implementations;
using BLL.Services.OrderService.Repositories;
using Domain.Entities;
using Moq;
using NUnit.Framework;

namespace BLLTests
{
    [TestFixture]
    public class DiscountServiceTest
    {

        private Order createOrder(decimal price)
        {
            return new Order() {Price = price};
        }
        
        [Test]
        public void SmallDiscountsTest()
        {
            // Arrange
            var discountServiceMock = new Mock<IDiscountService>();
            var orderMock = new Mock<Order>();
            var discountService = new DiscountService();

            orderMock
                .Setup(order => order.Count).Returns<int>(value => 7);

            discountServiceMock
                .Setup(discount => discount.GetDiscount(createOrder(It.IsAny<decimal>())))
                .Returns<decimal>(discount => discount);
            // Act
            
            
            // Assert
        }

        [Test]
        public void FailureDiscountTest()
        {
            // Arrange
            var discountServiceMock = new Mock<IDiscountService>();
            var orderMock = new Mock<Order>();

            orderMock
                .Setup(order => order.Price).Returns(It.Is<decimal>(v => v == 0));
            
            discountServiceMock
                .Setup(discount => discount.GetDiscount(orderMock.Object))
                .Throws<ArgumentOutOfRangeException>();
            
            var discountService = new DiscountService();
            
            // Act Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => discountService.GetDiscount(createOrder(0m)));
        }
    }  
}