using Microsoft.Extensions.Logging;
using Moq;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllIds;
using Visiotech.VineyardManagementService.Domain.Models;
using Visiotech.VineyardManagementService.Domain.Repositories;

namespace Visiotech.VineyardManagementService.Application.UnitTests.UseCases.Managers
{
    public class ListAllManagerIdsUseCaseShould
    {
        private readonly Mock<ILogger<ListAllManagerIdsUseCase>> _loggerMock;
        private readonly Mock<IManagerRepository> _managerRepositoryMock;
        private readonly Mock<IListAllManagerIdsOutputPort> _outputPort;
        private readonly ListAllManagerIdsUseCase _listAllManagerIdsUseCase;

        public ListAllManagerIdsUseCaseShould()
        {
            _loggerMock = new Mock<ILogger<ListAllManagerIdsUseCase>>();
            _managerRepositoryMock = new Mock<IManagerRepository>();
            _outputPort = new Mock<IListAllManagerIdsOutputPort>();

            _listAllManagerIdsUseCase = new ListAllManagerIdsUseCase(
                _loggerMock.Object,
                _managerRepositoryMock.Object,
                _outputPort.Object);
        }

        [Fact]
        public async Task Execute_ShouldExecuteUseCase()
        {
            // Arrange
            var input = new ListAllManagerIdsInput();
            var managerIds = new List<ManagerIdInfo> {
                new(101, "Manager 1"),
                new(202, "Manager 2"), 
                new(303, "Manager 3") 
            };

            _managerRepositoryMock
                .Setup(r => r.GetAllManagerIdsAsync())
                .ReturnsAsync(managerIds);

            // Atc
            await _listAllManagerIdsUseCase.Execute(input);

            // Assert
            _managerRepositoryMock.Verify(m => m.GetAllManagerIdsAsync(), Times.Once);
        }
    }
}
