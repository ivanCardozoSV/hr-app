using Domain.Services.Contracts.Seed;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Impl.Validators.Seed
{
    public class UpdateDummyContractValidator: AbstractValidator<UpdateDummyContract>
    {
        public UpdateDummyContractValidator()
        {
            RuleFor(_ => _.TestValue).NotEmpty();
        }
    }
}
