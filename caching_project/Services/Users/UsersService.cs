using System.Collections.Generic;
using dotnetcaching.Entities;
using dotnetcaching.Repository;

namespace dotnetcaching.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<List<UsersRolPolicy>> SelectPolicyUsersAllService()
        {
            try
            {
                return await _usersRepository.SelectPolicyUsersAllRepository();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<UsersRolPolicy> SelectPolicyUserByIdService(int idUser)
        {
            try
            {
                return await _usersRepository.SelectPolicyUserByIdRepository(idUser);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<int> InsertUserService(UserDto userDto)
        {
            try
            {
                return await _usersRepository.InsertUserRepository(userDto);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}