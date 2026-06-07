using AutoMapper;
using CRM.Application.Dtos.Contact;
using CRM.Application.Dtos.Customer;
using CRM.Application.Dtos.Lead;
using CRM.Application.Dtos.Label;
using CRM.Application.Dtos.LeadSource;
using CRM.Domain.Entities;
using CRM.Application.Dtos.LeadLabel;

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
                .ForMember(des => des.CreatedDate, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(des => des.Source, opt => opt.MapFrom(src => src.Source))
                .ForMember(des => des.Labels, opt => opt.MapFrom(src => src.Labels));
            CreateMap<CreateLeadDto, Lead>();

            CreateMap<LeadSource, LeadSourceDto>().ForMember(des => des.LeadSourceId, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.CreatedDate, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(des => des.ModifiedDate, opt => opt.MapFrom(src => src.ModifiedAt));
            CreateMap<CreateLeadSourceDto, LeadSource>();

            CreateMap<Label, LabelDto>().ForMember(des => des.LabelId, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.CreatedDate, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(des => des.ModifiedDate, opt => opt.MapFrom(src => src.ModifiedAt));
            CreateMap<CreateLabelDto, Label>();

            CreateMap<LeadLabelDto, LeadLabel>();

        }


    }
}
