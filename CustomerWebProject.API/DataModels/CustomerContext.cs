using Microsoft.EntityFrameworkCore;

namespace CustomerWebProject.API.DataModels
{
    public class CustomerContext: DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options): base(options)
        {
            
        }
        public DbSet<Customer> Customer { get; set;}

        public DbSet<PhoneNumber> PhoneNumber { get; set;}

        public DbSet<ContactMode> ContactMode { get; set;}

    }
}
