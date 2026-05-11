using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using StockApplicationApi.Models;
using StockApplicationApi.Services.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace StockApplication.UnitTests.Services
{
    public class TokenServiceTests
    {
        private readonly Mock<UserManager<AppUser>> _userManagerMock;
        private readonly IConfiguration _config;
        private readonly TokenService _sut;
        public TokenServiceTests()
        {
            _userManagerMock = new Mock<UserManager<AppUser>>(
                Mock.Of<IUserStore<AppUser>>(), null, null, null, null, null, null, null, null);
            var inMemorySettings = new Dictionary<string, string>
        {
            { "JWT:SigningKey", "this-is-a-very-long-secret-key-for-testing-1234!" },
            { "JWT:Issuer", "Issuer" },
            { "JWT:Audience", "Audience" }
        };
            _config = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _sut = new TokenService(_config, _userManagerMock.Object);
        }
        [Fact]
        public async Task CreateAccessToken_ShouldIncludeRoles()
        {
            var user = new AppUser
            {
                Id = "user123",
                UserName = "kemish",
                Email = "kem@gmail.com"
            };

            _userManagerMock
                .Setup(x => x.GetRolesAsync(user))
                .ReturnsAsync(new List<string> { "Customer" });

            var token = await _sut.CreateAccessToken(user);

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            var roles = jwt.Claims.Where(c => c.Type == "role").ToList();

            Assert.Single(roles);
            Assert.Equal("Customer", roles.First().Value);
        }
        [Fact]

        public async Task CreateAccessToken_ShouldIncludeUserClaims()
        {
            var user = new AppUser
            {
                Id = "user123",
                UserName = "kemish",
                Email = "kem@gmail.com"
            };

            _userManagerMock
                .Setup(x => x.GetRolesAsync(user))
                .ReturnsAsync(new List<string>());

            var token = await _sut.CreateAccessToken(user);

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            Assert.Contains(jwt.Claims, c =>
                c.Type == JwtRegisteredClaimNames.Sub && c.Value == user.Id);

            Assert.Contains(jwt.Claims, c =>
                c.Type == JwtRegisteredClaimNames.UniqueName && c.Value == user.UserName);

            Assert.Contains(jwt.Claims, c =>
                c.Type == JwtRegisteredClaimNames.Email && c.Value == user.Email);
        }
       
    }
}