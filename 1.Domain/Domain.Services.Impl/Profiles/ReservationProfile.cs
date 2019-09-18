using AutoMapper;
using Domain.Model;
using Domain.Services.Contracts.Reservation;
using System;
using System.Collections.Generic;
using System.Text;


namespace Domain.Services.Impl.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {

            CreateMap<Reservation, ReadedReservationContract>().ForMember(x => x.Recruiter, opt => opt.MapFrom(r => r.Recruiter.Id));
            CreateMap<CreateReservationContract, Reservation>().ForMember(x => x.Recruiter, opt => opt.Ignore());
            CreateMap<Reservation, CreatedReservationContract>();
            CreateMap<UpdateReservationContract, Reservation>().ForMember(x => x.Recruiter, opt => opt.Ignore());
        }
    }
}
