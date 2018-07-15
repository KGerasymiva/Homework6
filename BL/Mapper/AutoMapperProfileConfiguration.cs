using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DAL.Models;
using DTO;

namespace BL.Mapper
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
            : this("MyProfile")
        {
        }
        protected AutoMapperProfileConfiguration(string profileName)
            : base(profileName)
        {
            CreateMap<PlaneTypeDTO, PlaneType>();
            CreateMap<PlaneType, PlaneTypeDTO>();
            CreateMap<PlaneDTO, Plane>();
            CreateMap<Plane, PlaneDTO>();
            CreateMap<FlightDTO, Flight>();
            CreateMap<Flight, FlightDTO>();
            CreateMap<FlightattendantDTO, Flightattendant>();
            CreateMap<Flightattendant, FlightattendantDTO>();
            CreateMap<CrewDTO, Crew>();
            CreateMap<Crew, CrewDTO>();
            CreateMap<PilotDTO, Pilot>();
            CreateMap<Pilot, PilotDTO>();
            CreateMap<TicketDTO, Ticket>();
            CreateMap<Ticket, TicketDTO>();
            CreateMap<DepartureDTO, Departure>();
            CreateMap<Departure, DepartureDTO>();
        }
    }
}
