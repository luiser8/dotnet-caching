using dotnetcaching.Entities;

namespace dotnetcaching.Repository
{
    public interface IUsersRepository
    {
        Task<List<UsersRolPolicy>> SelectPolicyUsersAllRepository();
        Task<UsersRolPolicy> SelectPolicyUserByIdRepository(int IdUser);
        Task<int> InsertUserRepository(UserDto userDto);
    }
}