using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AutoMapper;
using BL.Mapper;
using BL.Service;
using DAL;
using DAL.Models;
using DAL.UnitOfWork;
using DTO;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace AirporstTestProject
{
    public class TicketServiceUnitTest
    {
        private Mock<IUnitOfWork> uowMock;
        private Mock<AirportContext> contextMock;
        private ServiceTicket serviceTicket;
        private IEnumerable<Ticket> tickets;
        private IEnumerable<Flight> flights;
        private IMapper mapper;
        private Mock<ServiceTicket> serviceMock;


        public TicketServiceUnitTest()
        {
            uowMock = new Mock<IUnitOfWork>();
            contextMock = new Mock<AirportContext>();
            serviceTicket = new ServiceTicket();
            serviceMock = new Mock<ServiceTicket>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });

            mapper = config.CreateMapper();

            tickets = new List<Ticket>
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

            flights = new List<Flight>
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
        }


        [Fact]
        public void Test2()
        {
            // Arrange


            // Act
            var result = serviceTicket.Tickets(tickets, flights);


            // Assert
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void Test3()
        {
            // Arrange
            var ticketPL = new TicketPL() { FlightForeignKey = 3, Price = 50, Id = 1 };

            // Act
            var result = serviceTicket.MapTicket(ticketPL, mapper);

            // Assert
            Assert.Equal(ticketPL.Id, result.Id);
            Assert.Equal(ticketPL.Price, result.Price);
            Assert.Equal(ticketPL.FlightForeignKey, result.FlightForeignKey);
        }

        [Theory]
        [InlineData(0, 800, 0)]
        [InlineData(5, 400, 0)]
        [InlineData(2, 0, 0)]
        [InlineData(2, 500, 10)]
        public void Test4(int fk, decimal pr, int id)
        {
            //Arrange

            var ticket = new TicketPL { FlightForeignKey = fk, Price = pr };
            if (id != 0)
            {
                ticket.Id = id;
            }

            serviceMock.Setup(serv => serv.GetFlightsFromDS()).Returns(flights);

            //Act
            Action act = () => serviceMock.Object.PostTicket(ticket);

            //Assert
            Assert.Throws<BL.Infrastructure.ValidationException>(act);
        }

        [Fact]
        public void Test5() //null
        {
            //Arrange

            TicketPL ticket = null;

            //Act
            Action act = () => serviceMock.Object.PostTicket(ticket);

            //Assert
            Assert.Throws<BL.Infrastructure.ValidationException>(act);
        }

        [Fact]
        public void Test6() //null
        {
            //Arrange

            TicketPL ticket = null;

            //Act
            Action act = () => serviceMock.Object.PutTicket(ticket);

            //Assert
            Assert.Throws<BL.Infrastructure.ValidationException>(act);
        }


        [Theory]
        [InlineData(1, 800, 0)]
        [InlineData(3, 0, 2)]
        [InlineData(0, 402, 1)]
        [InlineData(10, 500, 2)]
        public void Test7(int fk, decimal pr, int id)  //Put
        {
            //Arrange

            var ticket = new TicketPL { FlightForeignKey = fk, Price = pr };
            if (id != 0)
            {
                ticket.Id = id;
            }

            serviceMock.Setup(serv => serv.GetFlightsFromDS()).Returns(flights);

            //Act
            Action act = () => serviceMock.Object.PutTicket(ticket);

            //Assert
            Assert.Throws<BL.Infrastructure.ValidationException>(act);
        }
    }
}

