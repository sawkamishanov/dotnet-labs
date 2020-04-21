using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Services.ClientService.Implementations;
using Data.Contracts;
using Domain.Contracts;
using Domain.Entities;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BLLTests
{
    [TestFixture]
    public class GetClientServiceTest
    {
        [Test]
        public async Task GetClientSuccess()
        {
            // Arrange
            var clientIdentityMock = new Mock<IClientIdentity>();
            var client = new Client();
            var clientDataAccessMock = new Mock<IClientDataAccess>();

            clientDataAccessMock
                .Setup(dataAccess => dataAccess.Get(clientIdentityMock.Object))
                .ReturnsAsync(client);
            
            var getClientService = new GetClientService(clientDataAccessMock.Object);
            
            // Act
            var action = await getClientService.GetClient(clientIdentityMock.Object);
            
            // Assert
            action.Should().Be(client);
            clientDataAccessMock.Verify();
        }

        [Test]
        public async Task GetClientInvalidOperationFailure()
        {
            // Arrange
            var clientIdentityMock = new Mock<IClientIdentity>();
            var clientDataAccessMock = new Mock<IClientDataAccess>();

            clientDataAccessMock
                .Setup(dataAccess => dataAccess.Get(clientIdentityMock.Object))
                .ReturnsAsync((Client) null);

            var getClientService = new GetClientService(clientDataAccessMock.Object);

            // Act
            var action = new Func<Task>(() => getClientService.GetClient(clientIdentityMock.Object));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>("Not found by id");
        }
        
        [Test]
        public async Task GetClientArgumentNullFailure()
        {
            // Arrange
            var clientDataAccessMock = new Mock<IClientDataAccess>();

            clientDataAccessMock
                .Setup(dataAccess => dataAccess.Get(null))
                .ThrowsAsync(new ArgumentNullException());
            
            var getClientService = new GetClientService(clientDataAccessMock.Object);
            
            // Act
            var action = new Func<Task>(() => getClientService.GetClient(null));
            
            // Assert
            await action.Should().ThrowAsync<ArgumentNullException>("Null params");
        }
    }
}