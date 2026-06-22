using CRM.Application.Dtos.Company;
using CRM.Application.Dtos.Contact;
using CRM.Application.Interfaces;
using CRM.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class CompaniesController(ICompanyService companyService, IContactService contactService) : ControllerBase
    {
        private readonly ICompanyService _companyService = companyService;
        private readonly IContactService _contactService = contactService;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int limit = 100, [FromQuery] string? filter = null)
        {
            var accounts = await _companyService.GetAllAsync(page,limit,filter);
            return accounts is null || !accounts.Any() ? Ok(BaseResponse<IEnumerable<CompanyDto>>.FailureResult(error: "No accounts found", null)) :  
                 Ok(BaseResponse<CompanyDto>.SuccessResult(accounts,page,limit));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var account = await _companyService.GetByIdAsync(id);
            return account is null ? Ok(BaseResponse<CompanyDetailDto>.FailureResult(error: "Account not found", null)) :
                    Ok(BaseResponse<CompanyDetailDto>.SuccessResult(account));
        }

        [HttpGet("{id}/contacts")]
        public async Task<IActionResult> GetContacts(Guid id, [FromQuery]int page = 1, [FromQuery]int limit = 100)
        {
            var contacts = await _contactService.GetContactsByCompanyIdAsync(id);
            return contacts is null || !contacts.Any() ? Ok(BaseResponse<ContactDto>.FailureResult(error: "No contacts found for this account", null)) :
                Ok(BaseResponse<ContactDto>.SuccessResult(contacts,page,limit));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCompanyDto request)
        {
            await _companyService.CreateAsync(request);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateAccountDto request)
        {
            await _companyService.UpdateAsync(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _companyService.DeleteAsync(id);
            return NoContent();
        }

    }
}
