using AutoMapper;
using CRM.Application.Dtos.Contact;
using CRM.Application.Dtos.Customer;
using CRM.Application.Dtos.Lead;
using CRM.Domain.Entities;

namespace CRM.Application.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Customer, CustomerDto>().ForMember(des => des.CustomerId, opt => opt.MapFrom(src => src.Id));
            CreateMap<CreateCustomerDto, Customer>();

            CreateMap<Contact, ContactDto>().ForMember(des => des.ContactId, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.Customer, opt => opt.MapFrom(src => src.Customer));
            CreateMap<CreateContactDto, Contact>();

            CreateMap<Lead, LeadDto>().ForMember(des => des.LeadId, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.CreatedDate, opt => opt.MapFrom(src => src.CreatedAt));
            CreateMap<CreateLeadDto, Lead>();
        }


    }
}
