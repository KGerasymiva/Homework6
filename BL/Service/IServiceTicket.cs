using System;
using System.Collections.Generic;
using System.Text;
using BL;
using DTO;

namespace BL.Service
{
    public interface IServiceTicket
    {
        TicketDTO GetTicket(int? id);
        IEnumerable<TicketDTO> GetTickets();

        void PostTicket(int flightId, decimal price);
        void DeleteTicket(int id);
        void PutTicket(int id, int flightId, decimal price);
        
        
        //decimal GetPrice(int? id);
        //string GetFlightNumber(int? id);

    }
}
