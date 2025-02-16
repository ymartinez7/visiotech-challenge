using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.MsSql;
using Visiotech.VineyardManagementService.Infrastructure.Data.Context;

namespace Visiotech.VineyardManagementService.Api.IntegrationTests.Infrastructure
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly MsSqlContainer _dbContainer = new MsSqlBuilder()
           .WithImage("mcr.microsoft.com/mssql/server:latest")
           .WithEnvironment("ACCEPT_EULA", "Y")
           .WithEnvironment("MSSQL_SA_PASSWORD ", "Password123!")
           .WithPortBinding(1433, 1434)
           .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                string connectionString = $"{_dbContainer.GetConnectionString()};Pooling=False";

                services.AddDbContextPool<AppDbContext>(options =>
                    options
                        .UseSqlServer(connectionString));
            });
        }

        public async Task InitializeAsync()
        {
            await _dbContainer.StartAsync();
        }

        public new async Task DisposeAsync()
        {
            await _dbContainer.StopAsync();
        }
    }
}
