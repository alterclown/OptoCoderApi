using Microsoft.EntityFrameworkCore;
using OptoCoderSampleApi.Data.DbContexts;
using OptoCoderSampleApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace OptoCoderSampleApi.Repository.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersInfo();
        IEnumerable<User> RetrieveUserInfo();
        Task<User> Authenticate(string userName, string password);
    }

    public class UserRepository : IUserRepository
    {
        private readonly AppSettings _appSettings;
        private readonly DataContext _context;

        public UserRepository(IOptions<AppSettings> appSettings, DataContext context)
        {
            _context = context;
            _appSettings = appSettings.Value;
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

        public async Task<User> Authenticate(string userName, string password)
        {
            try
            {
                var user =  _context.Users.SingleOrDefault(x => x.UserName == userName && x.Password == password);

                if (user == null)
                    return null;

                var tokenHandler = new JwtSecurityTokenHandler();

                var key = Encoding.ASCII.GetBytes(_appSettings.Key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {

                    new Claim(ClaimTypes.Name , user.UserId.ToString()),
                    new Claim(ClaimTypes.Role , user.IsAdmin.ToString())

                }),
                    Expires = DateTime.UtcNow.AddDays(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                user.Password = null;
                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
