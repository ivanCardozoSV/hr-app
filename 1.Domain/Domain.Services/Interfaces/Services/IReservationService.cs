using Domain.Services.Contracts.Reservation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services.Interfaces.Services
{
    public interface IReservationService
    {
        CreatedReservationContract Create(CreateReservationContract contract);
        ReadedReservationContract Read(int id);
        void Update(UpdateReservationContract contract);
        void Delete(int id);
        IEnumerable<ReadedReservationContract> List();
    }
}
