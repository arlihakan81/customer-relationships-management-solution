using AutoMapper;
using CRM.Application.Dtos.Contact;
using CRM.Application.Dtos.Company;
using CRM.Application.Dtos.Lead;
using CRM.Application.Dtos.Label;
using CRM.Application.Dtos.LeadSource;
using CRM.Domain.Entities;
using CRM.Application.Dtos.LeadLabel;
using CRM.Application.Dtos.Product;
using CRM.Application.Dtos.Pipeline;
using CRM.Application.Dtos.Stage;
using CRM.Application.Dtos.Deal;
using CRM.Application.Dtos.DealLineItem;

namespace CRM.Application.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<Company, CompanyDetailDto>();
            CreateMap<CreateCompanyDto, Company>();

            CreateMap<Contact, ContactDto>().ForMember(des => des.ContactId, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.Company, opt => opt.MapFrom(src => src.Company));
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

            CreateMap<DealLineItemDto, DealLineItem>()
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Price));

            CreateMap<CreateDealLineItemDto, DealLineItem>();

        }


    }
}
