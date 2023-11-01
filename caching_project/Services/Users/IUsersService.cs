using dotnetcaching.Entities;

namespace dotnetcaching.Services
{
    public interface IUsersService
    {
        Task<List<UsersRolPolicy>> SelectPolicyUsersAllService();
        Task<UsersRolPolicy> SelectPolicyUserByIdService(int IdUser);
        Task<int> InsertUserService(UserDto userDto);
    }
}