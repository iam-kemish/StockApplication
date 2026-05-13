using Microsoft.AspNetCore.Identity;
using StockApplicationApi.Models;

namespace StockApplicationApi.Seeders
{
    public  class IdentitySeeder
    {
        private readonly IConfiguration _config;
        private readonly IServiceProvider _service;
        private readonly ILogger<IdentitySeeder> _logger;

        public IdentitySeeder(IConfiguration configuration, IServiceProvider serviceProvider, ILogger<IdentitySeeder> logger)
        {
            _config = configuration;
            _service = serviceProvider;
            _logger = logger;
        }
        public  async Task SeedAdminAsync()
        {
            var userManager = _service.GetRequiredService<UserManager<AppUser>>();
            var roleManager = _service.GetRequiredService<RoleManager<IdentityRole>>();
            var roleName = "Admin";

            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
                _logger.LogInformation("Admin role created successfully.");
            }
 
            var adminEmail = _config["Admin:Email"];
            var username = _config["Admin:Username"]; 
            var password = _config["Admin:Password"];
            var existingAdmin = await userManager.FindByEmailAsync(adminEmail);

            if (existingAdmin == null)
            {
                var admin = new AppUser
                {
                    UserName = username,
                    Email = adminEmail
                };

              var createUser = await userManager.CreateAsync(admin, password!);
                if(createUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, roleName);
                    _logger.LogInformation("Admin user created successfully.");
                } 
            }
        }
    }
}
