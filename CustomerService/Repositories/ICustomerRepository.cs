using CustomerService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerService.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll();

        Task<Customer> GetCustomerById(int customerID);

        void AddCustomer(Customer customer);

        void Update(Customer customer);

        void DeleteCustomer(int customerId);

        void SaveChanges();
    }
}
