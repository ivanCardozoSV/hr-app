using Domain.Services.Contracts.DeclineReason;
using FluentValidation;

namespace Domain.Services.Impl.Validators.DeclineReason
{
    public class UpdateDeclineReasonContractValidator : AbstractValidator<UpdateDeclineReasonContract>
    {
        public UpdateDeclineReasonContractValidator()
        {
            RuleFor(_ => _.Name).NotEmpty();
            RuleFor(_ => _.Description).NotEmpty();
        }
    }
}
