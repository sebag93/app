using System;
using System.Threading.Tasks;
using AutoMapper;
using Evento.Core.Domain;
using Evento.Core.Repositories;
using Evento.Infrastructure.DTO;
using Evento.Infrastructure.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace tests.Evento.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task register_async_should_invoke_add_async_on_user_repository()
        {
            //Arange
            var userRepositoryMock = new Mock<IUserRepository>();
            var jwtHandler = new Mock<IJwtHandler>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, jwtHandler.Object, mapperMock.Object);

            //Act
            await userService.RegisterAsync(Guid.NewGuid(), "test@test.com", "test", "secret");

            //Assert
            userRepositoryMock.Verify(x=> x.AddAsync(It.IsAny<User>()), Times.Once());
        }

        [Fact]
        public async Task when_invoking_get_async_it_should_invoke_get_async_on_user_repository()
        {
            //Arange
            var user = new User(Guid.NewGuid(), "user", "test", "test@test.com", "secret");
            var accountDTO = new AccountDTO
            {
                Id = user.Id,
                Name = user.Name,
                Role = user.Role,
                Email = user.Email
            };
            var userRepositoryMock = new Mock<IUserRepository>();
            var jwtHandler = new Mock<IJwtHandler>();
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<AccountDTO>(user)).Returns(accountDTO);
            var userService = new UserService(userRepositoryMock.Object, jwtHandler.Object, mapperMock.Object);
            userRepositoryMock.Setup(x => x.GetAsync(user.Id)).ReturnsAsync(user);

            //Act
            var existingAccountDTO = await userService.GetAccountAsync(user.Id);

            //Assert
            userRepositoryMock.Verify(x=> x.GetAsync(user.Id), Times.Once());
            accountDTO.Should().NotBeNull();
            accountDTO.Email.ShouldBeEquivalentTo(user.Email);
        }
    }
}