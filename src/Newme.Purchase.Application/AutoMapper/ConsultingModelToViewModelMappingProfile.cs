using AutoMapper;
using Newme.Purchase.Infrastructure.Consulting.ConsultingModels;
using Newmw.Purchase.Application.ViewModels;

namespace Newme.Purchase.Application.AutoMapper
{
    public class ConsultingToViewModelMappingProfile : Profile
    {
        public ConsultingToViewModelMappingProfile()
        {
            CreateMap<PurchaseConsultingModel, ReadPurchaseViewModel>();
            CreateMap<PurchaseItemConsultingModel, ReadPurchaseItemViewModel>();
            CreateMap<BuyerConsultingModel, ReadBuyerViewModel>();
            CreateMap<AddressConsultingModel, ReadAddressViewModel>();
        }
    }
}
