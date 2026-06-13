using AutoMapper;
using CRM.Application.Dtos.Contact;
using CRM.Application.Dtos.Customer;
using CRM.Application.Dtos.Lead;
using CRM.Application.Dtos.Label;
using CRM.Application.Dtos.LeadSource;
using CRM.Domain.Entities;
using CRM.Application.Dtos.LeadLabel;
using CRM.Application.Dtos.Product;
using CRM.Application.Dtos.Pipeline;
using CRM.Application.Dtos.Stage;
using CRM.Application.Dtos.Deal;
using CRM.Application.Dtos.DealItem;

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

            CreateMap<Product, ProductDto>().ForMember(des => des.ProductId, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.CreatedDate, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(des => des.ModifiedDate, opt => opt.MapFrom(src => src.ModifiedAt));
            CreateMap<CreateProductDto, Product>();

            CreateMap<Pipeline, PipelineDto>().ForMember(des => des.PipelineId, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.CreatedDate, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(des => des.ModifiedDate, opt => opt.MapFrom(src => src.ModifiedAt));
            CreateMap<CreatePipelineDto, Pipeline>();

            CreateMap<Stage, StageDto>().ForMember(des => des.StageId, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.CreatedDate, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(des => des.ModifiedDate, opt => opt.MapFrom(src => src.ModifiedAt));
            CreateMap<CreateStageDto, Stage>();

            CreateMap<Deal, DealDto>().ForMember(des => des.DealId, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.CreatedDate, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(des => des.ModifiedDate, opt => opt.MapFrom(src => src.ModifiedAt));
            CreateMap<CreateDealDto, Deal>();

            CreateMap<DealItem, DealItemDto>().ForMember(des => des.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(des => des.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(des => des.Price, opt => opt.MapFrom(src => src.UnitPrice));

            CreateMap<DealItemDto, Product>();

        }


    }
}
