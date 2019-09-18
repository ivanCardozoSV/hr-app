using Domain.Services.Contracts.Candidate;
using Domain.Services.Contracts.Skill;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Impl.Validators.Skill
{
    public class CreateSkillContractValidator : AbstractValidator<CreateSkillContract>
    {
        public CreateSkillContractValidator()
        {
            RuleFor(_ => _.Name).NotEmpty();
            RuleFor(_ => _.Type).NotEmpty();
        }
    }
}
