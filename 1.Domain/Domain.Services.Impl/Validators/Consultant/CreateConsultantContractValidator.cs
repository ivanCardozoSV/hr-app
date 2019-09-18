using Domain.Services.Contracts.Consultant;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Impl.Validators.Consultant
{
    public class CreateConsultantContractValidator : AbstractValidator<CreateConsultantContract>
    {
        public CreateConsultantContractValidator()
        {
            RuleFor(_ => _.Name).NotEmpty();
            RuleFor(_ => _.LastName).NotEmpty();
            RuleFor(_ => _.EmailAddress).NotEmpty();
        }
    }
}
