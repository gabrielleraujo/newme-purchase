using AutoMapper;
using Newme.Purchase.Domain.Models.Entities;
using Newme.Purchase.Domain.Models.ValueObjects;
using Newme.Purchase.Application.Consulting.ConsultingModels;

namespace Newme.Purchase.Application.AutoMapper
{
    public class DomainToConsultingModelMappingProfile : Profile
    {
        public DomainToConsultingModelMappingProfile()
        {
            CreateMap<PurchaseOrder, PurchaseConsultingModel>();
            CreateMap<PurchaseItem, PurchaseItemConsultingModel>();
            CreateMap<Buyer, BuyerConsultingModel>();
            CreateMap<Address, AddressConsultingModel>();
            CreateMap<Product, ProductConsultingModel>();
        }
    }
}
