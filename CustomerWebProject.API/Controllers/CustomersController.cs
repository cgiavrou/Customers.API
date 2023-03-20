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

        [HttpGet]
        [Route("[controller]/{customerId:guid}")]
        public async Task<IActionResult> GetCustomer([FromRoute] Guid customerId)
        {
            //Fetch Customer details
            var customer = await customerRepository.GetCustomer(customerId);

            //Return
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Customer>(customer));
        }

        [HttpPut]
        [Route("[controller]/{customerId:guid}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] Guid customerId, [FromBody] UpdateCustomerRequest request)
        {
            if (await customerRepository.Exists(customerId))
            {
                var updatedCustomer = await customerRepository.UpdateCustomer(customerId, mapper.Map<DataModels.Customer>(request));

                return Ok(mapper.Map<Customer>(updatedCustomer));

            }

            return NotFound();
        }

        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddCustomer([FromRoute] AddCustomerRequest request)
        {
            var customer = await customerRepository.AddCustomer(mapper.Map<DataModels.Customer>(request));

            return CreatedAtAction(nameof(GetCustomer), new { customerId = customer.Id }, mapper.Map<Customer>(customer));
        }

        [HttpDelete]
        [Route("[controller]/{customerId:guid}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] Guid customerId)
        {
            if (await customerRepository.Exists(customerId))
            {
                var customer = await customerRepository.DeleteCustomer(customerId);

                return Ok(mapper.Map<Customer>(customer));
            }

            return NotFound();
        }
    }
}
