using OptoCoderSampleApi.Data.Entities;
using OptoCoderSampleApi.Repository.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptoCoderSampleApi.Service.Users
{
    public interface IUserService
    {
        Task<List<User>> GetUsersInfo();
        Task<User> RetrieveUserInfo(int userId);
        Task<User> Authenticate(string userName, string password);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<User>> GetUsersInfo()
        {
            try
            {
                var res = _repository.GetUsersInfo();
                return await res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<User> RetrieveUserInfo(int userId)
        {
            try
            {
                var res = _repository.RetrieveUserInfo(userId);
                return await res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<User> Authenticate(string userName, string password)
        {
            try
            {
                var response = _repository.Authenticate(userName, password);
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
        }
    }
}
