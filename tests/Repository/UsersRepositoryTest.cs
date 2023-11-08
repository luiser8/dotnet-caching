using System.Collections;
using System.Data;
using dotnetcaching.Entities;
using dotnetcaching.Repository;
using dotnetcaching.Utils;
using Moq;
using Xunit;

public class UsersRepositoryTest
{
    private Mock<CustomDataTable> _dbConMock;
    private DataTable _dt;
    private Hashtable _params;
    private UsersRepository _usersRepository;

    [Fact]
    public void Setup()
    {
        _dbConMock = new Mock<CustomDataTable>();
        _dt = new DataTable();
        _params = new Hashtable();
        _usersRepository = new UsersRepository();

        // Aquí puedes agregar la configuración de tus objetos simulados (_dbConMock)
    }
    private static async Task<UsersRepository> SetupMockUsersRepository(List<UsersRolPolicy> usersRolPolicies)
    {
        return new UsersRepository();
    }

    [Fact]
    public async Task SelectPolicyUsersAllRepository_ReturnsExpectedResult()
    {
        // Arrange
        var mockDbCon = new Mock<IDbConnection>();
        var mockDt = new DataTable();
        // Add rows to mockDt as needed
        IUsersRepository mockHolidayRepository = await SetupMockUsersRepository(new List<UsersRolPolicy> { });
        //mockDbCon.Setup(db => db.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>())).ReturnsAsync(mockDt);

        // Act
        var result = await SetupMockUsersRepository(new List<UsersRolPolicy> { });
        var users = result.SelectPolicyUsersAllRepository().Result;
        // Assert
        Assert.Equal(0, users.Count);
    }
}