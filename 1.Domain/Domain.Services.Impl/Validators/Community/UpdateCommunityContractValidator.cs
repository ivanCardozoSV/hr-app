using Domain.Services.Contracts.Community;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Impl.Validators.Community
{
    public class UpdateCommunityContractValidator : AbstractValidator<UpdateCommunityContract>
    {
        public UpdateCommunityContractValidator()
        {
            RuleFor(_ => _.Name).NotEmpty();
            RuleFor(_ => _.Description).NotEmpty();
        }
    }
}