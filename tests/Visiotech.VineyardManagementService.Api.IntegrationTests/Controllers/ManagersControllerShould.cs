using FluentAssertions;
using System.Net;
using System.Text;
using System.Text.Json;
using Visiotech.VineyardManagementService.Api.Handlers.Managers.CalculateTotalManagementAreaByManager;
using Visiotech.VineyardManagementService.Api.IntegrationTests.Infrastructure;

namespace Visiotech.VineyardManagementService.Api.IntegrationTests.Controllers
{
    public class ManagersControllerShould(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
    {
        [Fact]
        public async Task ListAllManagersIds_ShouldReturnAnIdsListOfManagers()
        {
            // Act
            HttpResponseMessage response = await HttpClient.GetAsync("managers/ids");

            // Assert
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<int>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().NotBeNull().And.HaveCount(3);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task ListAllManagerTaxNumbers_ShouldReturnATaxNumberListOfManagers(bool sorted)
        {
            // Act
            HttpResponseMessage response = await HttpClient.GetAsync($"managers/taxnumbers?sorted={sorted}");

            // Assert
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<string>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().NotBeNull().And.HaveCount(3);
        }

        [Fact]
        public async Task CalculateTotalManagementAreaByManager_ShouldReturnATotalAreaManagementByEachManager()
        {
            // Arrange
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(new CalculateTotalManagementAreaByManagerRequest()),
                Encoding.UTF8,
                "application/json"
            );

            // Act
            HttpResponseMessage response = await HttpClient.PostAsync("managers/totalarea", jsonContent);

            // Assert
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Dictionary<string, int>>(jsonString);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().NotBeNull().And.HaveCount(3);
        }
    }
}
