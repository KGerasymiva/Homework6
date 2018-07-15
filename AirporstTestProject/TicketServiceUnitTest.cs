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
using NUnit.Framework;
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
        

        public TicketServiceUnitTest()
        {
            uowMock = new Mock<IUnitOfWork>();
            contextMock = new Mock<AirportContext>();
            serviceTicket = new ServiceTicket();

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
        //[Fact]
        //public void Test1()
        //{
        //    // Arrange
        //    var ticketsList = tickets as List<Ticket>;

        //    // Act
        //    serviceTicket.PostTicket(new TicketPL()
        //    {
        //        Price = ticketsList[0].Price,
        //        FlightForeignKey = ticketsList[0].FlightForeignKey
        //    });


        //    // Assert
        //    Assert.Equal(3, result.Count());
        //}

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

        [Fact]
        public void Test4()
        {
            //arrange
            var service = new ServiceTicket();
            //act
            Action act = () => service.PostTicket(new TicketPL()
            {

            });
            //assert
            Assert.Throws<BL.Infrastructure.ValidationException>(act);
        }

    }
}

