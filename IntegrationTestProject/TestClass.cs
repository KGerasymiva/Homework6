using System;
using System.IO;
using System.Linq;
using AutoMapper.Configuration;
using BL.Service;
using DTO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using PL;
using Xunit;

namespace IntegrationTestProject
{


    public class TestClass
    {
        TestServer _server;
        public static ServiceTicket serviceTicket;

        public TestClass()
        {
            _server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<TestStartup>().UseDefaultServiceProvider(options =>
                    options.ValidateScopes = false));
        }



        [Fact]
        public void Test1Create()
        {

            // Arrange
            var ticketPL = new TicketPL() { FlightForeignKey = 3, Price = 50 };

            // Act
            serviceTicket.PostTicket(ticketPL);

            var num = serviceTicket.GetFlightsFromDS().FirstOrDefault(f => f.Id == ticketPL.FlightForeignKey).Number;
            var ticketDto = serviceTicket.GetTickets().OrderByDescending(t => t.Id).First();
            // Assert

            Assert.Equal(num, ticketDto.FlightNumber);
            Assert.Equal(ticketPL.Price, ticketDto.Price);
        }


        [Fact]
        public void Test2Update()
        {
            // Arrange
            var ticketPL = new TicketPL() { Id = 2, FlightForeignKey = 1, Price = 500 };
            // Act
            serviceTicket.PutTicket(ticketPL);
            var num = serviceTicket.GetFlightsFromDS().FirstOrDefault(f => f.Id == ticketPL.FlightForeignKey).Number;
            var ticketDto = serviceTicket.GetTickets().FirstOrDefault(t => t.Id == ticketPL.Id);
            
            // Assert
            Assert.Equal(ticketPL.Id, ticketDto.Id);
            Assert.Equal(num, ticketDto.FlightNumber);
            Assert.Equal(ticketPL.Price, ticketDto.Price);
        }

        [Fact]
        public void Test3Delete()
        {
            //Arrange
            var id = 3;
            //Act
            serviceTicket.DeleteTicket(id);
            var ticketDto = serviceTicket.GetTickets().FirstOrDefault(t => t.Id == id);

            // Assert
            Assert.Equal(ticketDto, null);

        }
    }


}