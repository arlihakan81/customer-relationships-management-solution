using CRM.Application.Dtos.Customer;
using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersController(ICustomerService customerService, IContactService contactService) : ControllerBase
    {
        private readonly ICustomerService _customerService = customerService;
        private readonly IContactService _contactService = contactService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpGet("{id}/contacts")]
        public async Task<IActionResult> GetContacts(Guid id)
        {
            var contacts = await _contactService.GetContactsByCustomerIdAsync(id);
            return Ok(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerDto request)
        {
            await _customerService.CreateAsync(request);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateCustomerDto request)
        {
            await _customerService.UpdateAsync(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _customerService.DeleteAsync(id);
            return NoContent();
        }













    }
}
