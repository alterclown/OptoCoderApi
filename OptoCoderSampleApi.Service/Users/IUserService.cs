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
        IEnumerable<User> RetrieveUserInfo();
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

        public IEnumerable<User> RetrieveUserInfo()
        {
            try
            {
                var res = _repository.RetrieveUserInfo();
                return  res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
