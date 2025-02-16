using Microsoft.Extensions.Logging;
using Moq;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllTaxNumbers;
using Visiotech.VineyardManagementService.Domain.Models;
using Visiotech.VineyardManagementService.Domain.Repositories;
using Visiotech.VineyardManagementService.Domain.ValueObjects;

namespace Visiotech.VineyardManagementService.Application.UnitTests.UseCases.Managers
{
    public class ListAllManagerTaxNumberUseCaseShould
    {
        private readonly Mock<ILogger<ListAllManagerTaxNumberUseCase>> _loggerMock;
        private readonly Mock<IManagerRepository> _managerRepositoryMock;
        private readonly Mock<IListAllManagerTaxNumbersOutputPort> _outputPort;
        private readonly ListAllManagerTaxNumberUseCase _listAllManagerTaxNumberUseCase;

        public ListAllManagerTaxNumberUseCaseShould()
        {
            _loggerMock = new Mock<ILogger<ListAllManagerTaxNumberUseCase>>();
            _managerRepositoryMock = new Mock<IManagerRepository>();
            _outputPort = new Mock<IListAllManagerTaxNumbersOutputPort>();

            _listAllManagerTaxNumberUseCase = new ListAllManagerTaxNumberUseCase(
                _loggerMock.Object,
                _managerRepositoryMock.Object,
                _outputPort.Object);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Execute_ShouldExecuteUseCase(bool sorted)
        {
            // Arrange
            var input = new ListAllManagerTaxNumbersInput(sorted);

            var managerTaxNumbers = new List<ManagerTaxNumberInfo> { 
                new(new TaxNumber("101"), "Manager 1"), 
                new(new TaxNumber("202"), "Manager 2"), 
                new(new TaxNumber("303"), "Manager 3")
            };

            _managerRepositoryMock
                .Setup(r => r.GetAllManagerTaxNumbersAsync(sorted))
                .ReturnsAsync(managerTaxNumbers);

            // Act
            await _listAllManagerTaxNumberUseCase.Execute(input);

            // Assert
            _managerRepositoryMock.Verify(m => m.GetAllManagerTaxNumbersAsync(sorted), Times.Once);
        }
    }
}
