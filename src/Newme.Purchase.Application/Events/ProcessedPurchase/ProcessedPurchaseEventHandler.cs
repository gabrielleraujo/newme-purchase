using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Newme.Purchase.Infrastructure.Consulting.ConsultingModels;
using Newme.Purchase.Infrastructure.Consulting.Repositories;
using Newme.Purchase.Domain.Extensions;

namespace Newme.Purchase.Application.Events.ProcessedPurchase
{
    public class ProcessedPurchaseOrderEventHandler : INotificationHandler<ProcessedPurchaseEvent>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ProcessedPurchaseOrderEventHandler> _logger;
        private readonly IPurchaseQueryRepository _purchaseQueryRepository;

        public ProcessedPurchaseOrderEventHandler(
            IMapper mapper,
            ILogger<ProcessedPurchaseOrderEventHandler> logger,
            IPurchaseQueryRepository purchaseQueryRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _purchaseQueryRepository = purchaseQueryRepository;
        }

        public async Task Handle(ProcessedPurchaseEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Received Event {event} - id: {id} at: {date}, data {data}.", 
                notification.Id, nameof(CreatedPurchaseOrderEvent), DateTime.Now, notification.ToString());

            var consultingModel = _mapper.Map<PurchaseConsultingModel>(notification.PurchaseOrder);

            _logger.LogInformation("Event id: {id} start running eventual consistence at {date}, saved data on consulting db, data {data}.", 
                notification.Id, DateTime.Now, consultingModel.ToString());

            await _purchaseQueryRepository.UpdateAsync(
                notification.PurchaseOrder.Id, notification.PurchaseOrder.State.GetEnumDescription(), x => x.State);

            _logger.LogInformation("Event id: {id} sending email for buyer id: {buyerId} at: {date}.", 
                notification.Id, notification.PurchaseOrder.BuyerId, DateTime.Now);
        }
    }
}