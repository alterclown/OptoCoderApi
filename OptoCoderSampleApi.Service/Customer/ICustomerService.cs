using OptoCoderSampleApi.Repository.Employee;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OptoCoderSampleApi.Service.Customer
{
    public interface ICustomerService
    {
        Task<List<OptoCoderSampleApi.Data.Entities.Customer>> GetCustomerList();
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Data.Entities.Customer>> GetCustomerList()
        {
            try
            {
                var res = await _repository.GetCustomerList();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
