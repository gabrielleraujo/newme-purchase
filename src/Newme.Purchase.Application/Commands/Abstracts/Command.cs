using FluentValidation.Results;

namespace Newme.Purchase.Application.Commands;

public abstract class Command
{
    protected Command()
    {
        ValidationResult = new ValidationResult();
    }

    public ValidationResult ValidationResult { get; protected set; }

    public virtual bool IsValid()
    {
        return true;
    }
}