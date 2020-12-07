using Microsoft.EntityFrameworkCore;
using OptoCoderSampleApi.Data.DbContexts;
using OptoCoderSampleApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptoCoderSampleApi.Repository.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersInfo();
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
                var query = _context.Users
                            .Include(a => a.Employees)
                            .Include(a => a.Customers);
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
