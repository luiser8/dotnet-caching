using dotnetcaching.Entities;
using dotnetcaching.Repository;
using dotnetcaching.Services;
using Moq;
using Xunit;

public class UsersServiceTest
{
    [Fact]
    public async Task SelectPolicyUsersAllService()
    {
        // Arrange: organizar, preparar
        var existingUsers = new List<UsersRolPolicy>
            {
                new UsersRolPolicy {
                dataUser = { },
                dataUserRol = { },
                policyUser = new List<PolicyUser>{   } }
            };
        // Act: Invocar
        var usersRepository = new Mock<IUsersRepository>();
        usersRepository
            .Setup(repo => repo.SelectPolicyUsersAllRepository())
            .ReturnsAsync(existingUsers);

        // Assert: Verificación
        var service = new UsersService(usersRepository.Object);
        var response = await service.SelectPolicyUsersAllService();

        Assert.NotNull(response);
    }

    [Fact]
    public async Task SelectPolicyUserByIdService()
    {
        // Arrange: organizar, preparar
        int userId = 1;
        var existingUsers = new UsersRolPolicy
        {
            dataUser = {  },
            dataUserRol = {  },
            policyUser = new List<PolicyUser>{  }
        };
        // Act: Invocar
        var usersRepository = new Mock<IUsersRepository>();
        usersRepository
            .Setup(repo => repo.SelectPolicyUserByIdRepository(userId))
            .ReturnsAsync(existingUsers);

        // Assert: Verificación
        var service = new UsersService(usersRepository.Object);
        var response = await service.SelectPolicyUserByIdService(userId);

        Assert.NotNull(response);
    }

    [Fact]
    public async Task InsertUserService()
    {
        // Arrange: organizar, preparar
        var mockLocal = new UserDto
        {
            email = "XXXXXXXXXXXXX",
            password = "XXXXXXXXXXXXX",
            firstName = "firstName",
            lastName = "XXXXXXXX",
            idRol = 1,
        };
        // Act: Invocar
        var usersRepository = new Mock<IUsersRepository>();
        usersRepository
            .Setup(repo => repo.InsertUserRepository(mockLocal));

        // Assert: Verificación
        var service = new UsersService(usersRepository.Object);
        var response = await service.InsertUserService(mockLocal);

        Assert.NotNull(response);
    }
}