using CustomerWebProject.API.DataModels;
using Microsoft.EntityFrameworkCore;

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
            return await context.Customer.Include(nameof(PhoneNumber)).Include(nameof(ContactMode)).ToListAsync();
        }
    }
}
