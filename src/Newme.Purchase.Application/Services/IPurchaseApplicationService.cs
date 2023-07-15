using FluentValidation.Results;
using Newmw.Purchase.Application.InputModels;
using Newmw.Purchase.Application.ViewModels;

namespace Newme.Purchase.Application.Services
{
    public interface IPurchaseApplicationService
    {
        Task<IEnumerable<ReadPurchaseViewModel>> GetAll(Guid buyerId);
        Task<ReadPurchaseViewModel> GetById(Guid purchaseId);
        Task<double> CalculateDiscount(CreatePurchaseInputModel inputModel);
        Task<ValidationResult> Register(CreatePurchaseInputModel inputModel);
    }
}
