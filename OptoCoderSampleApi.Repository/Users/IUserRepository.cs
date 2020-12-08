using Microsoft.EntityFrameworkCore;
using OptoCoderSampleApi.Data.DbContexts;
using OptoCoderSampleApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OptoCoderSampleApi.Repository.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersInfo();
        IEnumerable<User> RetrieveUserInfo();
    }

    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetUsersInfo()
        {
            try
            {
                var res = await _context.Users
                           .Include(a => a.Company)
                           .ToListAsync();
                return res;
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
                var _query = _context.Users
               .Include(a => a.Company);
                return _query;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
