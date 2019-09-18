using Domain.Services.Contracts.Role;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Impl.Validators.Role
{
    public class CreateRoleContractValidator : AbstractValidator<CreateRoleContract>
    {
        public CreateRoleContractValidator()
        {
            RuleFor(_ => _.Name).NotEmpty();
            RuleFor(_ => _.isActive).NotEmpty();
        }
    }
}
