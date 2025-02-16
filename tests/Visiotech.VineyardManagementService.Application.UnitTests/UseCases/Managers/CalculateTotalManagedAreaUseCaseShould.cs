using Microsoft.Extensions.Logging;
using Moq;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.CalculateTotalManagementAreaByManager;
using Visiotech.VineyardManagementService.Domain.Repositories;

namespace Visiotech.VineyardManagementService.Application.UnitTests.UseCases.Managers
{
    public class CalculateTotalManagedAreaUseCaseShould
    {
        private readonly Mock<ILogger<CalculateTotalManagedAreaUseCase>> _loggerMock;
        private readonly Mock<IManagerRepository> _managerRepositoryMock;
        private readonly Mock<ICalculateTotalManagedAreaOutputPort> _outputPort;
        private readonly CalculateTotalManagedAreaUseCase _calculateTotalManagedAreaUseCase;

        public CalculateTotalManagedAreaUseCaseShould()
        {
            _loggerMock = new Mock<ILogger<CalculateTotalManagedAreaUseCase>>();
            _managerRepositoryMock = new Mock<IManagerRepository>();
            _outputPort = new Mock<ICalculateTotalManagedAreaOutputPort>();

            _calculateTotalManagedAreaUseCase = new CalculateTotalManagedAreaUseCase(
                _loggerMock.Object,
                _managerRepositoryMock.Object,
                _outputPort.Object);
        }

        [Fact]
        public async Task Execute_ShouldExecuteUseCase()
        {
            // Arrange
            var input = new CalculateTotalManagedAreaInput();
            var managementAreasByManagers = new Dictionary<string, int>
                            {
                                { "Manager A", 150 },
                                { "Manager B", 200 },
                                { "Manager C", 250 }
                            };

            _managerRepositoryMock
                .Setup(r => r.GetTotalManagementAreaByManagerAsync())
                .ReturnsAsync(managementAreasByManagers);

            // Act
            await _calculateTotalManagedAreaUseCase.Execute(input);

            // Assert
            _managerRepositoryMock.Verify(m => m.GetTotalManagementAreaByManagerAsync(), Times.Once);
        }
    }
}
