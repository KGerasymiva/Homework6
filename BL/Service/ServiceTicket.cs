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
        public virtual IEnumerable<Ticket> GetTicketsFromDS()
        {
            return UOW.Set<Ticket>().Get();
        }

        public virtual IEnumerable<Flight> GetFlightsFromDS()
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

            var ticket = GetTickets().FirstOrDefault(x => x.Id == id.Value);

            if (ticket == null)
                throw new ValidationException("Ticket not found", "");

            return ticket;
        }

        public Ticket MapTicket(TicketPL ticket, IMapper mapper)
        {
            return mapper.Map<Ticket>(ticket);
        }

        public void PostTicket(TicketPL ticket)
        {
            if (ticket == null || ticket.FlightForeignKey == 0 || ticket.Price == 0 || ticket.Id != 0)
            {
                throw new ValidationException($"Incorrect input values", "");
            }

            var fl = GetFlightsFromDS();

            if (fl.FirstOrDefault(f => f.Id == ticket.FlightForeignKey) == null)
            {
                throw new ValidationException($"There is no Flight with id {ticket.FlightForeignKey}", "");
            }

            UOW.Set<Ticket>().Create(MapTicket(ticket, mapper));
            UOW.SaveChages();
        }

        public void PutTicket(TicketPL ticket)
        {
            if (ticket == null || ticket.Id == 0 || ticket.FlightForeignKey == 0 || ticket.Price == 0)
            {
                throw new ValidationException($"Incorrect input values", "");
            }

            if (GetTicketsFromDS().FirstOrDefault(t => t.Id == ticket.Id) == null)
            {
                throw new ValidationException($"There is no ticket with id {ticket.Id}", "");
            }
            UOW.Set<Ticket>().Update(MapTicket(ticket, mapper));
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
