using System;
using System.Threading.Tasks;
using BLL.Services.ClientService.Implementations;
using Data.Contracts;
using Domain.Entities;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BLLTests
{
    [TestFixture]
    public class CreateClientServiceTest
    {
        [Test]
        public async Task CreateClientSuccess()
        {
            // Arrange
            var client = new Client();
            var returnClient = new Client();
            var clientDataAccessMock = new Mock<IClientDataAccess>();

            clientDataAccessMock
                .Setup(dataAccess => dataAccess.CreateClient(client))
                .ReturnsAsync(returnClient);
            
            var createClientService = new CreateClientService(clientDataAccessMock.Object);
            
            // Act
            var action = await createClientService.CreateClient(client);
            
            // Assert
            action.Should().Be(returnClient);
            clientDataAccessMock.Verify();
        }
        
        [Test]
        public async Task CreateClientArgumentNullFailure()
        {
            // Arrange
            var clientDataAccessMock = new Mock<IClientDataAccess>();

            clientDataAccessMock
                .Setup(dataAccess => dataAccess.CreateClient(null))
                .ThrowsAsync(new ArgumentNullException());
            
            var createClientService = new CreateClientService(clientDataAccessMock.Object);
            
            // Act
            var action = new Func<Task>(() => createClientService.CreateClient(null));
            
            // Assert
            await action.Should().ThrowAsync<ArgumentNullException>("Null params");
        }
    }
}