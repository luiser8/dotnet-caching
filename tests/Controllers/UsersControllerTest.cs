using dotnetcaching.Controllers;
using dotnetcaching.Entities;
using dotnetcaching.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class UsersControllerTest
{
    private static UsersController SetupMockUsersController(List<UsersRolPolicy> usersRolPolicies)
    {
        var mockService = new Mock<IUsersService>();

        mockService.Setup((x) => x.SelectPolicyUsersAllService())
            .ReturnsAsync(() => usersRolPolicies);

        return new UsersController(mockService.Object);
    }

    private static UsersController SetupMockUsersPostController()
    {
        var mockService = new Mock<IUsersService>();

        return new UsersController(mockService.Object);
    }

    private static UsersController SetupMockUsersByIdController(UsersRolPolicy usersRolPolicies, int userId)
    {
        var mockService = new Mock<IUsersService>();

        mockService.Setup((x) => x.SelectPolicyUserByIdService(userId))
            .ReturnsAsync(() => usersRolPolicies);

        return new UsersController(mockService.Object);
    }

    [Fact]
    public async Task GetUserAll()
    {
        // Arrange: organizar, preparar
        var mockLocal = new List<UsersRolPolicy>
        {
            new UsersRolPolicy {
            dataUser = { },
            dataUserRol = { },
            policyUser = new List<PolicyUser>{   } }
        };
        var mock = SetupMockUsersController(mockLocal);

        // Act: Invocar
        var current = await mock.GetUserAll();

        // Assert: Verificación
        var objectResult = current.Result as ObjectResult;
        var listResult = objectResult?.Value as List<UsersRolPolicy>;

        Assert.NotNull(listResult);
        Assert.Equal(StatusCodes.Status200OK, objectResult?.StatusCode);
        Assert.True(listResult.Count == 1);
    }

    [Fact]
    public async Task GetUserById()
    {
        // Arrange: organizar, preparar
        int userId = 1;
        var mockLocal = new UsersRolPolicy
        {
            dataUser = {  },
            dataUserRol = {  },
            policyUser = new List<PolicyUser>{  }
        };
        var mock = SetupMockUsersByIdController(mockLocal, userId);

        // Act: Invocar
        var current = await mock.GetUserById(userId);

        // Assert: Verificación
        var objectResult = current.Result as ObjectResult;
        var listResult = objectResult?.Value as List<UsersRolPolicy>;

        Assert.Null(listResult);
        Assert.Equal(StatusCodes.Status200OK, objectResult?.StatusCode);
    }

    [Fact]
    public async Task CreateUsers()
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
        var mock = SetupMockUsersPostController();

        // Act: Invocar
        var current = await mock.PostUser(mockLocal);

        // Assert: Verificación
        var objectResult = current.Result as ObjectResult;
        var listResult = objectResult?.Value as List<UsersRolPolicy>;

        Assert.Null(listResult);
        Assert.Equal(StatusCodes.Status200OK, objectResult?.StatusCode);
    }
}