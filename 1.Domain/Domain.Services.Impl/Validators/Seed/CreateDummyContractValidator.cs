using Domain.Services.Contracts.Seed;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Impl.Validators.Seed
{
    public class CreateDummyContractValidator: AbstractValidator<CreateDummyContract>
    {
        public CreateDummyContractValidator()
        {
            RuleFor(_ => _.TestValue).NotEmpty();
        }
    }
}
