using CustomerWebProject.API.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace CustomerWebProject.API.Repositories
{
    public class SqlCustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext context;

        public SqlCustomerRepository(CustomerContext context)
        {
            this.context = context;
        }
        
        public async Task<List<Customer>> GetCustomers()
        {
            return await context.Customer.Include(nameof(PhoneNumber)).ToListAsync();
        }

        public async Task<Customer> GetCustomer(Guid customerId)
        {
            return await context.Customer
                .Include(nameof(PhoneNumber))
                .FirstOrDefaultAsync(x => x.Id == customerId);
        }

        public async Task<bool> Exists(Guid customerId)
        {
            return await context.Customer.AnyAsync(x => x.Id == customerId);
        }

        public async Task<Customer> DeleteCustomer(Guid customerId)
        {
            var customer = await GetCustomer(customerId);

            if (customer != null)
            {
                context.Customer.Remove(customer);
                await context.SaveChangesAsync();
                return customer;
            }

            return null;
        }

        public async Task<Customer> AddCustomer(Customer request)
        {
            var customer = await context.Customer.AddAsync(request);

            await context.SaveChangesAsync();

            return customer.Entity;
        }

        public async Task<Customer> UpdateCustomer(Guid customerId, Customer request)
        {
            var existingCustomer = await GetCustomer(customerId);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = request.FirstName;
                existingCustomer.LastName = request.LastName;
                existingCustomer.Email = request.Email;
                existingCustomer.HomeAddress = request.HomeAddress;
                existingCustomer.PhoneNumber.Mobile = request.PhoneNumber.Mobile;
                existingCustomer.PhoneNumber.HomePhone = request.PhoneNumber.HomePhone;
                existingCustomer.PhoneNumber.WorkPhone = request.PhoneNumber.WorkPhone;

                await context.SaveChangesAsync();
                return existingCustomer;
            }
            return null;
        }
    }
}
