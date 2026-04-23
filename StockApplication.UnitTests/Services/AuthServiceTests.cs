using Microsoft.AspNetCore.Identity;
using Moq;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs;
using StockApplicationApi.Services.AuthService;
using StockApplicationApi.Services.Token;

namespace StockApplication.UnitTests.Services
{
    public class AuthServiceTests
    {
        private readonly Mock<UserManager<AppUser>> _userManagerMock;
        private readonly Mock<RoleManager<IdentityRole>> _roleManagerMock;
        private readonly Mock<ITokenService> _tokenServiceMock;
        private readonly AuthService _sut;
        public AuthServiceTests()
        {
            _userManagerMock = new Mock<UserManager<AppUser>>(
                Mock.Of<IUserStore<AppUser>>(), null, null, null, null, null, null, null, null);
            _roleManagerMock = new Mock<RoleManager<IdentityRole>>(
                Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null);
            _tokenServiceMock = new Mock<ITokenService>();
            _sut = new AuthService(_userManagerMock.Object, _roleManagerMock.Object, _tokenServiceMock.Object);
        }
        [Fact]
        public async Task Register_ShouldThrowConflictException_WhenEmailAlreadyExists()
        {
            var dto = new RegisterDTO
            {
                UserName = "testuser",
                Email = "existing@example.com",
                Password = "Test@1234"
            };
            //When email already exists, UserManager.FindByEmailAsync should return a user
            _userManagerMock.Setup(um => um.FindByEmailAsync(dto.Email))
                .ReturnsAsync(new AppUser { Email = dto.Email });
            var ex = await Assert.ThrowsAsync<ConflictException>(
                () => _sut.Register(dto)
            );

            Assert.Equal("Email already exists.", ex.Message);
        }
        [Fact]
        public async Task Register_ShouldThrowOperationFailedException_WhenUserCreationFails()
        {
            var dto = new RegisterDTO
            {
                UserName = "testuser",
                Email = "test@example.com",
                Password = "weakpassword"
            };

            _userManagerMock.Setup(um => um.CreateAsync(It.IsAny<AppUser>(), dto.Password))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Operation failed" }));

            var ex = await Assert.ThrowsAsync<OperationFailedException>(
                () => _sut.Register(dto)
            );

            Assert.Equal("Operation failed", ex.Message);
        }
        [Fact]
        public async Task Register_ShouldAssignCustomerRole_AfterSuccessfulCreation()
        {

        }
    }
}