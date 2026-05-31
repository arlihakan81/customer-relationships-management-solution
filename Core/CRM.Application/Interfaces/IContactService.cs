using CRM.Application.Dtos.Contact;

namespace CRM.Application.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDto>?> GetAllContactsAsync();
        Task<ContactDto?> GetContactByIdAsync(Guid contactId);
        Task<IEnumerable<ContactDto>?> GetContactsByCustomerIdAsync(Guid customerId);
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task UpdateContactAsync(Guid contactId, UpdateContactDto updateContactDto);
        Task DeleteContactAsync(Guid contactId);
    }
}
