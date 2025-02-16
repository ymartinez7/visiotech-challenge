namespace Visiotech.VineyardManagementService.Api.IntegrationTests.Infrastructure
{
    public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
    {
        protected readonly HttpClient HttpClient;

        protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
        {
            HttpClient = factory.CreateClient();
        }
    }
}
