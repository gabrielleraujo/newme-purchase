using Microsoft.AspNetCore.Mvc;
using Newme.Purchase.Application.Services;
using Newmw.Purchase.Application.InputModels;

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
        public async Task<IActionResult> Add(CreatePurchaseInputModel purchaseInputModel)
        {
            var result = await _purchaseApplicationService.Register(purchaseInputModel);
            return NoContent();
        }
        
        [HttpPost("discount")]
        public async Task<IActionResult> CalculateDiscount(CreatePurchaseInputModel purchaseInputModel)
        {
            var result = await _purchaseApplicationService.CalculateDiscount(purchaseInputModel);
            return Ok(result);
        }

        [HttpGet("get-all/buyer/{buyerId:Guid}")]
        public async Task<IActionResult> GetAll(Guid buyerId)
        {
            var result = await _purchaseApplicationService.GetAll(buyerId);
            return Ok(result);
        }

        [HttpGet("{purchaseId:Guid}")]
        public async Task<IActionResult> GetById(Guid purchaseId)
        {
            var result = await _purchaseApplicationService.GetById(purchaseId);
            return Ok(result);
        }
    }
}
