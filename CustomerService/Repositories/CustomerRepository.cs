using CustomerService.Data;
using CustomerService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Repositories
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private CustomerDbContext _context;

        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = _context.Customers.Find(customerId);
            _context.Customers.Remove(customer);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.Include(c => c.Adress).ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int customerID)
        {
            return await _context.Customers.Include(c => c.Adress).SingleOrDefaultAsync(x => x.Id == customerID);
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }

        #region Dispose
        
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
