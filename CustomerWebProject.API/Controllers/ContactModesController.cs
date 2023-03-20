using AutoMapper;
using CustomerWebProject.API.DomainModels;
using CustomerWebProject.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CustomerWebProject.API.Controllers
{
    [ApiController]
    public class ContactModesController : Controller
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public ContactModesController( ICustomerRepository customerRepository, IMapper mapper )
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetContactModes()
        {
            var contactModeList = await customerRepository.GetContactModes();

            if (contactModeList == null || !contactModeList.Any())
            {
                return NotFound();
            }

            return Ok(mapper.Map<List<ContactMode>>(contactModeList));
        }
    }
}
