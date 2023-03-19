using AutoMapper;
using CustomerWebProject.API.DomainModels;
using CustomerWebProject.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebProject.API.Controllers
{
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public CustomersController(ICustomerRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllCustomers()
        {
            
            var customers = await customerRepository.GetCustomers();
            
            return Ok(mapper.Map<List<Customer>>(customers));
        }
    }
}
