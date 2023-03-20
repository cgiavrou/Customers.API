using CustomerWebProject.API.DataModels;
using System.Reflection;

namespace CustomerWebProject.API.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomers();

        Task<Customer> GetCustomer(Guid customerId);

        Task<List<ContactMode>> GetContactModes();
        
        Task<bool> Exists(Guid customerId);
        
        Task<Customer> UpdateCustomer(Guid customerId, Customer request);

        Task<Customer> DeleteCustomer(Guid customerId);

        Task<Customer> AddCustomer(Customer customer);


    }
}
