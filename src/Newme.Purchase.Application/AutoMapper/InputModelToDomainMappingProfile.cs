using AutoMapper;
using Newme.Purchase.Domain.Models.Entities;
using Newme.Purchase.Domain.Models.ValueObjects;
using Newmw.Purchase.Application.InputModels;

namespace Newme.Purchase.Application.AutoMapper
{
    public class InputModelToDomainMappingProfile : Profile
    {
        public InputModelToDomainMappingProfile()
        {
            CreateMap<CreateBuyerInputModel, Buyer>()
                .ConstructUsing(x => new Buyer(x.Id, x.Name, x.Surname, x.Username, x.Email));

            CreateMap<CreateAddressInputModel, Address>()
                .ConstructUsing( x => new Address(x.ZipCode, x.Street, x.Number, x.Complement, x.Neighborhood, x.City, x.UF));

            CreateMap<InputProductInputModel, Product>()
                .ConstructUsing(x => new Product(x.Id, x.Name, x.Description,
                        new Category(x.Category),
                        new Color(x.Color),
                        new Size(x.Size)));

            CreateMap<CreatePurchaseItemInputModel, PurchaseItem>()
                .ConstructUsing(x => new PurchaseItem(
                    x.Id, x.PurchaseId, x.Product.Id, x.UnitPrice, x.Quantity));
        }
    }
}