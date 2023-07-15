using FluentValidation;
using Newme.Purchase.Application.Commands.CreatePurchase;

namespace Newme.Purchase.Application.Validations
{
    public class CreatePurchaseCommandValidation : AbstractValidator<CreatePurchaseCommand>
    {
        protected void ValidateBuyer()
        {
            RuleFor(c => c.Buyer)
                .NotNull();

            RuleFor(c => c.Buyer.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidatePrice()
        {
            RuleFor(c => c.Price)
                .NotEmpty()
                .Must(x => x > 0)
                .WithMessage("The price is invalid, must be bigger than 0.");
        }

        protected void ValidateItems()
        {
            RuleFor(c => c.PurchaseItems)
                .Must(x => x.Count > 0)
                .WithMessage("There are no items informed to buy.");
        }
    }
}
