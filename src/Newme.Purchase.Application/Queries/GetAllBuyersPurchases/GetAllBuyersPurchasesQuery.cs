using MediatR;
using Newmw.Purchase.Application.ViewModels;

namespace Newme.Purchase.Application.Queries.GetAllBuyersPurchases
{
    public class GetAllBuyersPurchasesQuery: IRequest<IEnumerable<ReadPurchaseViewModel>>
    {
        public GetAllBuyersPurchasesQuery(Guid buyerId)
        {
            BuyerId = buyerId;
        }

        public Guid BuyerId { get; private set; }

    }
}