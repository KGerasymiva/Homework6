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

        void PostTicket(TicketPL ticket);
        void DeleteTicket(int id);
        void PutTicket(TicketPL ticket);
        
        
        //decimal GetPrice(int? id);
        //string GetFlightNumber(int? id);

    }
}
