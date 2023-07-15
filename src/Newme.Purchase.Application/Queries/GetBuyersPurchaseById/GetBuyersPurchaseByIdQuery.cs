using MediatR;
using Newmw.Purchase.Application.ViewModels;

namespace Newme.Purchase.Application.Queries.GetBuyersPurchaseById
{
    public class GetBuyersPurchaseByIdQuery: IRequest<ReadPurchaseViewModel>
    {
        public GetBuyersPurchaseByIdQuery(Guid purchaseId)
        {
            PurchaseId = purchaseId;
        }

        public Guid PurchaseId { get; private set; }

    }
}