using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Testcontainers.PostgreSql;
using Testcontainers.Redis;

namespace StockApplicationApi.IntegrationTests.Infrastructure;

public class CustomWebApplicationFactory
    : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgres = new PostgreSqlBuilder()
        .WithImage("postgres:16-alpine")
        .Build();

    private readonly RedisContainer _redis = new RedisBuilder()
        .WithImage("redis:7-alpine")
        .Build();

    // xUnit calls this BEFORE the tests: start containers
    public async Task InitializeAsync()
    {
        await _postgres.StartAsync();
        await _redis.StartAsync();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing");

        // Use the SAME config keys your app reads. Check your appsettings / .env names!
        builder.UseSetting("ConnectionStrings:DefaultConnection", _postgres.GetConnectionString());
        builder.UseSetting("ConnectionStrings:RedisConnection", _redis.GetConnectionString());
        builder.UseSetting("JWT_SIGNING_KEY", "test-signing-key-at-least-32-characters-long!!");
        builder.UseSetting("ADMIN_EMAIL", "admin@stockapp.com");
        builder.UseSetting("ADMIN_USERNAME", "admin");
        builder.UseSetting("ADMIN_PASSWORD", "Admin123!Test");
    }

    
    public new async Task DisposeAsync()
    {
        await _postgres.DisposeAsync();
        await _redis.DisposeAsync();
    }
}