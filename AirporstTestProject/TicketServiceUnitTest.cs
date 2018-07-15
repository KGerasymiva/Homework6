using System;
using System.Collections.Generic;
using System.Linq;
using BL.Service;
using DAL;
using DAL.Models;
using DAL.UnitOfWork;
using DTO;
using Moq;
using Xunit;

namespace AirporstTestProject
{
    public class TicketServiceUnitTest
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<AirportContext> contextMock;
        private ServiceTicket serviceTicket;

        public TicketServiceUnitTest()
        {
            uowMock = new Mock<IUnitOfWork>();
            contextMock = new Mock<AirportContext>();
            serviceTicket = new ServiceTicket();
        }
        [Fact]
        public void Test1()
        {
            // Arrange
            var tickets = new List<Ticket>
            {
                new Ticket()
                {
                    Id=1,
                    Price = 100M,
                    FlightForeignKey = 1,
                },
                new Ticket()
                {
                    Id = 2,
                    Price = 200M,
                    FlightForeignKey = 2,
                },
                new Ticket()
                {
                    Id = 3,
                    Price = 300M,
                    FlightForeignKey = 3,
                }
            };

            var flights = new List<Flight>
            {
                new Flight()
                {
                    Id = 1,
                    Number = "QW543200",
                    Departure = "Kyiv",
                    Destination = "Lviv",
                    DeparturingTime = "2018-12-14 10:13:20",
                    ArrivingTime = "2018-12-14 10:43:20",
                    Tickets = new List<Ticket>(),
                },
                new Flight()
                {
                    Id = 3,
                    Number = "PY987500",
                    Departure = "Kyiv",
                    Destination = "Barcelona",
                    DeparturingTime = "2018-12-15 15:13:20",
                    ArrivingTime = "2018-12-15 17:43:20",
                    Tickets = new List<Ticket>(),

                },
                new Flight()
                {
                    Id = 3,
                    Number = "KJ457000",
                    Departure = "Kyiv",
                    Destination = "Toronto",
                    DeparturingTime = "2018-10-15 05:13:20",
                    ArrivingTime = "2018-10-15 23:43:20",
                    Tickets = new List<Ticket>(),

                }
            };

            // Act
            var result = serviceTicket.Tickets(tickets,flights);

           
            // Assert
            Assert.Equal(3, result.Count());
        }
    }
}

