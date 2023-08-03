using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newme.Purchase.Application.Services;
using Newmw.Purchase.Application.InputModels;
using Newmw.Purchase.Application.ViewModels;

namespace Newme.Purchase.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/purchase")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseApplicationService _purchaseApplicationService;

        public PurchaseController(IPurchaseApplicationService purchaseApplicationService)
        {
            _purchaseApplicationService = purchaseApplicationService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Add(CreatePurchaseInputModel purchaseInputModel)
        {
            var result = await _purchaseApplicationService.Register(purchaseInputModel);
            return NoContent();
        }
        
        [HttpPost("discount")]
        [ProducesResponseType(typeof(double), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CalculateDiscount(CreatePurchaseInputModel purchaseInputModel)
        {
            var result = await _purchaseApplicationService.CalculateDiscount(purchaseInputModel);
            return Ok(result);
        }

        [HttpGet("get-all/buyer/{buyerId:Guid}")]
        [ProducesResponseType(typeof(IEnumerable<ReadPurchaseViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll(Guid buyerId)
        {
            var result = await _purchaseApplicationService.GetAll(buyerId);
            return Ok(result);
        }

        [HttpGet("{purchaseId:Guid}")]
        [ProducesResponseType(typeof(ReadPurchaseViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetById(Guid purchaseId)
        {
            var result = await _purchaseApplicationService.GetById(purchaseId);
            return Ok(result);
        }
    }
}
