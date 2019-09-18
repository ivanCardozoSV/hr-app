using Domain.Services.Contracts.Reservation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Impl.Validators.Reservation
{
    public class UpdateReservationContractValidator : AbstractValidator<UpdateReservationContract>
    {
        public UpdateReservationContractValidator()
        {
            RuleFor(_ => _.SinceReservation).NotNull();
            RuleFor(_ => _.UntilReservation).NotNull();
            // RuleFor(_ => _.Room).NotNull();
            RuleFor(_ => _.RoomId).NotNull();
            RuleFor(_ => _.Description).NotEmpty();
        }
    }
}