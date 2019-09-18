using Domain.Services.Contracts.Office;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Impl.Validators.Office
{
    public class CreateOfficeContractValidator : AbstractValidator<CreateOfficeContract>
    {
        public CreateOfficeContractValidator()
        {
            RuleFor(_ => _.Name).NotEmpty();
            RuleFor(_ => _.Description).NotEmpty();
        }
    }
}
