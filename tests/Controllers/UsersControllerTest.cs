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
    [Fact]
    public async Task GetUserAll()
    {
        // Arrange
        var mockLocal = new List<UsersRolPolicy>
        {
            new UsersRolPolicy {
            dataUser = { },
            dataUserRol = { },
            policyUser = new List<PolicyUser>{   } }
        };
        var mock = SetupMockUsersController(mockLocal);
        // Act
        var current = await mock.GetUserAll();

        // Assert
        var objectResult = current.Result as ObjectResult;
        var listResult = objectResult?.Value as List<UsersRolPolicy>;

        Assert.NotNull(listResult);
        Assert.Equal(StatusCodes.Status200OK, objectResult?.StatusCode);
        Assert.True(listResult.Count == 1);
    }
}