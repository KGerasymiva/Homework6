using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BL.Infrastructure;
using DAL;
using DAL.Models;
using DAL.UnitOfWork;
using DTO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BL.Service
{
    public class ServiceTicket : IServiceTicket
    {

        private IUnitOfWork UOW { get; set; }
        private IMapper mapper;

        public ServiceTicket(IUnitOfWork uow, IMapper mapper)
        {
            UOW = uow;
            this.mapper = mapper;
        }

        public ServiceTicket(IUnitOfWork uow)
        {
            UOW = uow;
        }

        public ServiceTicket()
        {
            
        }

        private IEnumerable<Ticket> GetTicketsFromDS()
        {
            return UOW.Set<Ticket>().Get();
        }

        private IEnumerable<Flight> GetFlightsFromDS()
        {
            return UOW.Set<Flight>().Get();
        }

        public IEnumerable<TicketDTO> GetTickets()
        {
            var tickets = GetTicketsFromDS();
            var flights = GetFlightsFromDS();
            var res = Tickets(tickets, flights);

            return mapper.Map<IEnumerable<TicketDTO>>(res);
        }

        public List<Ticket> Tickets(IEnumerable<Ticket> tickets, IEnumerable<Flight> flights)
        {
            var res = tickets
                .Join(flights,
                    t => t.FlightForeignKey,
                    f => f.Id,
                    (t, f) => new Ticket() { Id = t.Id, Flight = f, Price = t.Price }).ToList();
            return res;
        }

        public TicketDTO GetTicket(int? id)
        {
            if (id == null)
                throw new ValidationException($"There is no ticket with id {id}", "");

            var ticket = GetTicketsFromDS().FirstOrDefault(x => x.Id == id.Value);

            if (ticket == null)
                throw new ValidationException("Ticket not found", "");

            var res = new Ticket { Id = ticket.Id, Flight = ticket.Flight, Price = ticket.Price };

            return mapper.Map<TicketDTO>(res);
        }

        public void PostTicket(int flightId, decimal price)
        {
            UOW.Set<Ticket>().Create(
            new Ticket()
            {
                Price = price,
                FlightForeignKey = flightId
            });

            UOW.SaveChages();
        }

        public void PutTicket(int id, int flightId, decimal price)
        {
            UOW
                .Set<Ticket>()
                .Update(new Ticket()
                {
                    Id = id,
                    Price = price,
                    FlightForeignKey = flightId
                });

            UOW.SaveChages();
        }

        public void DeleteTicket(int id)
        {
            UOW.Set<Ticket>().Delete(id);
            UOW.SaveChages();
        }


        //public decimal GetPrice(int? id)
        //{
        //    if (id == null)
        //        throw new ValidationException($"There is no ticket", "");

        //    var ticket = UOW.Set<Ticket>().Get().FirstOrDefault(x => x.Id == id.Value);

        //    if (ticket == null)
        //        throw new ValidationException("Ticket not found", "");

        //    return ticket.Price;
        //}

        //public string GetFlightNumber(int? id)
        //{
        //    if (id == null)
        //        throw new ValidationException($"There is no ticket with id {id}", "");

        //    var ticket = UOW.Set<Ticket>().Get().FirstOrDefault(x => x.Id == id.Value);

        //    if (ticket == null)
        //        throw new ValidationException("Ticket not found", "");

        //    return ticket.Flight;
        //}


    }
}
