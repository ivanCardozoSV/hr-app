using Domain.Services.Contracts.DeclineReason;
using FluentValidation;

namespace Domain.Services.Impl.Validators.DeclineReason
{
    public class CreateDeclineReasonContractValidator : AbstractValidator<CreateDeclineReasonContract>
    {
        public CreateDeclineReasonContractValidator()
        {
            RuleFor(_ => _.Name).NotEmpty();
            RuleFor(_ => _.Description).NotEmpty();
        }
    }
}
