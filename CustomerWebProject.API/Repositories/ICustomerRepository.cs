using CustomerWebProject.API.DataModels;

namespace CustomerWebProject.API.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomers();

        Task<Customer> GetCustomer(Guid customerId);
    }
}
