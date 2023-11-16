using Xunit;
using Moq;
using dotnetcaching.Entities;
using dotnetcaching.Repository;

public class UsersRepositoryTest
{
    private readonly Mock<IUsersRepository> _mockRepo;

    public UsersRepositoryTest()
    {
        _mockRepo = new Mock<IUsersRepository>();
    }

    [Fact]
    public async Task SelectPolicyUsersAllRepository_ReturnsListOfUsersRolPolicy()
    {
        // Arrange
        var users = new List<UsersRolPolicy>
                {
                    new UsersRolPolicy { /* inicializa con datos de prueba */ },
                    new UsersRolPolicy { /* inicializa con datos de prueba */ }
                };
        _mockRepo.Setup(repo => repo.SelectPolicyUsersAllRepository()).ReturnsAsync(users);

        // Act
        var result = await _mockRepo.Object.SelectPolicyUsersAllRepository();

        // Assert
        Assert.Equal(users, result);
    }

    [Fact]
    public async Task SelectPolicyUsersByIdRepository_ReturnsOfUsersRolPolicy()
    {
        // Arrange
        int userId = 1;
        var users = new UsersRolPolicy
                { };
        _mockRepo.Setup(repo => repo.SelectPolicyUserByIdRepository(userId)).ReturnsAsync(users);

        // Act
        var result = await _mockRepo.Object.SelectPolicyUserByIdRepository(userId);

        // Assert
        Assert.Equal(users, result);
    }

    [Fact]
    public async Task InsertPolicyUsersRepository_ReturnsIdUser()
    {
        // Arrange
        var usersDto = new UserDto {};
        _mockRepo.Setup(repo => repo.InsertUserRepository(usersDto)).ReturnsAsync(1);

        // Act
        var result = await _mockRepo.Object.InsertUserRepository(usersDto);

        // Assert
        Assert.Equal(1, result);
    }
}
