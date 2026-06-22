using CRM.Application.Dtos.Contact;
using CRM.Application.Interfaces;
using CRM.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactsController(IContactService contactService) : ControllerBase
    {
        private readonly IContactService _contactService = contactService;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int limit = 100, [FromQuery] string? filter = null)
        {
            var contacts = await _contactService.GetAllContactsAsync(page,limit,filter);
            return contacts is null || !contacts.Any() ? Ok(BaseResponse<ContactDto>.FailureResult(error: "No contacts found", null)) :
                Ok(BaseResponse<ContactDto>.SuccessResult(contacts, page, limit));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var contact = await _contactService.GetContactByIdAsync(id);
            return contact is null ? Ok(BaseResponse<ContactDto>.FailureResult(error: "Contact not found", null)) :
                Ok(BaseResponse<ContactDto>.SuccessResult(contact));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateContactDto request)
        {
            await _contactService.CreateContactAsync(request);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateContactDto request)
        {
            await _contactService.UpdateContactAsync(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _contactService.DeleteContactAsync(id);
            return NoContent();
        }















    }
}
