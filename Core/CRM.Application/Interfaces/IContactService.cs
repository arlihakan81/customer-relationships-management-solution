using CRM.Application.Dtos.Contact;

namespace CRM.Application.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDto>?> GetAllContactsAsync(int page = 1, int limit = 100, string? filter = null);
        Task<ContactDto?> GetContactByIdAsync(Guid contactId);
        Task<IEnumerable<ContactDto>?> GetContactsByCustomerIdAsync(Guid customerId, int page = 1, int limit = 100);
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(Guid contactId, UpdateContactDto updateContactDto);
        Task DeleteContactAsync(Guid contactId);
    }
}
