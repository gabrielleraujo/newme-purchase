using System.Net.Mime;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Newme.Purchase.Infrastructure.Consulting.ConsultingModels;
using Newme.Purchase.Infrastructure.Consulting.Repositories;

namespace Newme.Purchase.Application.Events
{
    public class CreatedPurchaseOrderEventHandler : INotificationHandler<CreatedPurchaseOrderEvent>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CreatedPurchaseOrderEventHandler> _logger;
        private readonly IPurchaseQueryRepository _purchaseQueryRepository;

        public CreatedPurchaseOrderEventHandler(
            IMapper mapper,
            ILogger<CreatedPurchaseOrderEventHandler> logger,
            IPurchaseQueryRepository purchaseQueryRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _purchaseQueryRepository = purchaseQueryRepository;
        }

        public async Task Handle(CreatedPurchaseOrderEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Received Event {event} - id: {id} at: {date}, data {data}.", 
                notification.Id, nameof(CreatedPurchaseOrderEvent), DateTime.Now, notification.ToString());

            var consultingModel = _mapper.Map<PurchaseConsultingModel>(notification.PurchaseOrder);

            _logger.LogInformation("Event id: {id} start running eventual consistence at {date}, saved data on consulting db, data {data}.", 
                notification.Id, DateTime.Now, consultingModel.ToString());

            await _purchaseQueryRepository.AddAsync(consultingModel).ConfigureAwait(false);

            _logger.LogInformation("Event id: {id} sending email for buyer id: {buyerId} at: {date}.", 
                notification.Id, notification.PurchaseOrder.BuyerId, DateTime.Now);
        }
    }
}
