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
        public async Task Register_ShouldNotCreateRole_WhenCustomerRoleAlreadyExists()
        {
            var dto = new RegisterDTO
            {
                UserName = "testuser",
                Email = "test@example.com",
                Password = "Test@1234"
            };
            _userManagerMock
                          .Setup(x => x.FindByEmailAsync(dto.Email))
                          .ReturnsAsync((AppUser)null);

            _userManagerMock
                .Setup(x => x.CreateAsync(It.IsAny<AppUser>(), dto.Password))
                .ReturnsAsync(IdentityResult.Success);

            _roleManagerMock
                .Setup(x => x.RoleExistsAsync("Customer"))
                .ReturnsAsync(true);
            _userManagerMock
               .Setup(x => x.AddToRoleAsync(It.IsAny<AppUser>(), "Customer"))
               .ReturnsAsync(IdentityResult.Success);

            // Act
            await _sut.Register(dto);
            _roleManagerMock.Verify(
               x => x.CreateAsync(It.IsAny<IdentityRole>()),
               Times.Never
               );
        }
        [Fact]
        public async Task Register_ShouldAssignCustomerRole_AfterSuccessfulCreation()
        {
            var dto = new RegisterDTO
            {
                UserName = "testuser",
                Email = "test@example.com",
                Password = "Test@1234"
            };
            _userManagerMock
                          .Setup(x => x.FindByEmailAsync(dto.Email))
                          .ReturnsAsync((AppUser)null);

            _userManagerMock
                .Setup(x => x.CreateAsync(It.IsAny<AppUser>(), dto.Password))
                .ReturnsAsync(IdentityResult.Success);

            _roleManagerMock
                .Setup(x => x.RoleExistsAsync("Customer"))
                .ReturnsAsync(false);
            _userManagerMock
               .Setup(x => x.AddToRoleAsync(It.IsAny<AppUser>(), "Customer"))
               .ReturnsAsync(IdentityResult.Success);

            // Act
            await _sut.Register(dto);
            _roleManagerMock.Verify(
               x => x.CreateAsync(It.IsAny<IdentityRole>()),
               Times.Once
               );

        }
        [Fact]
        public async Task Login_ShouldThrowNotFoundException_WhenUserNotFound()
        {
            var dto = new LoginDTO
            {
                Email = "kem@gmail.com",
                Password = "Test@1234"
            };
            var user = new AppUser { Email = dto.Email, UserName = "User" };
            _userManagerMock.Setup(um => um.FindByEmailAsync(dto.Email))
                .ReturnsAsync((AppUser)null);
            var ex = await Assert.ThrowsAsync<NotFoundException>(() => _sut.Login(dto));
            Assert.Equal("Invalid credentials this username might be wrong or empty", ex.Message);
        }
        [Fact]
        public async Task Login_ShouldThrowUnAuthorizedException_WhenPasswordIsIncorrect()
        {
            var dto = new LoginDTO
            {
                Email = "kem@gmail.com",
                Password = "Test@1234"
            };
            var user = new AppUser { Email = dto.Email, UserName = "User" };
            _userManagerMock.Setup(um => um.FindByEmailAsync(dto.Email))
                .ReturnsAsync(user);
            _userManagerMock.Setup(um => um.CheckPasswordAsync(user, dto.Password))
                .ReturnsAsync(false);
            var ex = await Assert.ThrowsAsync<UnAuthorizedException>(() => _sut.Login(dto));
            Assert.Equal("Invalid credentials this password might be wrong or empty", ex.Message);
        }
        [Fact]
        public async Task Login_ShouldReturnAuthResponseDTO_WhenCredentialsAreValid()
        {
            var dto = new LoginDTO
            {
                Email = "kem@gmail.com",
                Password = "Test@1234"
            };
            var user = new AppUser { Email = dto.Email, UserName = "User" };
            _userManagerMock.Setup(u => u.FindByEmailAsync(dto.Email)).ReturnsAsync(user);
                        _userManagerMock.Setup(u => u.CheckPasswordAsync(user, dto.Password)).ReturnsAsync(true);
            _tokenServiceMock.Setup(t => t.CreateAccessToken(user)).ReturnsAsync("token");

            var result = await _sut.Login(dto);

            Assert.Equal(user.UserName, result.UserName);
            Assert.Equal(user.Email, result.Email);
            Assert.Equal("token", result.Token);
        }
    }
}
    