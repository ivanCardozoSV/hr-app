using Domain.Services.Contracts.Stage;
using FluentValidation;

namespace Domain.Services.Impl.Validators.Stage
{
    public class UpdateStageContractValidator : AbstractValidator<UpdateStageContract>
    {
        public UpdateStageContractValidator()
        {
            //RuleFor(_ => _.DNI).NotEmpty();
        }

    }
}
