using Domain.Services.Contracts.Room;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Impl.Validators.Room
{
    public class UpdateRoomContractValidator : AbstractValidator<UpdateRoomContract>
    {
        public UpdateRoomContractValidator()
        {
            RuleFor(_ => _.Id).NotEmpty();
            RuleFor(_ => _.Name).NotEmpty();
            RuleFor(_ => _.Description).NotEmpty();
        }
    }
}
