using AutoMapper;
using CRM.Application.Dtos.Contact;
using CRM.Application.Interfaces;
using CRM.Application.Repositories;

namespace CRM.Infrastructure.Services
{
    public class ContactService(IContactRepository contactRepository, IMapper mapper) : IContactService
    {
        private readonly IContactRepository _contactRepository = contactRepository;
        private readonly IMapper _mapper = mapper;

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            await _contactRepository.AddAsync(_mapper.Map<Domain.Entities.Contact>(createContactDto));
        }

        public async Task DeleteContactAsync(Guid contactId)
        {
            await _contactRepository.DeleteAsync(contactId);
        }

        public async Task<IEnumerable<ContactDto>?> GetAllContactsAsync()
        {
            var contacts = await _contactRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ContactDto>>(contacts);
        }

        public async Task<ContactDto?> GetContactByIdAsync(Guid contactId)
        {
            var contact = await _contactRepository.GetByIdAsync(contactId);
            return _mapper.Map<ContactDto>(contact);
        }

        public async Task<IEnumerable<ContactDto>?> GetContactsByCustomerIdAsync(Guid customerId)
        {
            var contacts = await _contactRepository.GetAllAsync(c => c.CustomerId == customerId);
            return _mapper.Map<IEnumerable<ContactDto>>(contacts);
        }

        public async Task UpdateContactAsync(Guid contactId, UpdateContactDto updateContactDto)
        {
            var contact = await _contactRepository.GetByIdAsync(contactId);
            await _contactRepository.UpdateAsync(_mapper.Map(updateContactDto, contact)!);
        }
    }
}
