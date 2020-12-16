using Microsoft.EntityFrameworkCore;
using OptoCoderSampleApi.Data.DbContexts;
using OptoCoderSampleApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptoCoderSampleApi.Repository.Employee
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomerList();
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Customer>> GetCustomerList()
        {
            try
            {
                var getData = await _context.Customers.ToListAsync();
                return getData;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
