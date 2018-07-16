using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {

            AirportContext context = ServiceProviderServiceExtensions.GetRequiredService<AirportContext>(app.ApplicationServices);

            context.Database.EnsureDeleted();
            if (!context.Database.EnsureCreated()) return;

            context.Tickets.AddRange(
                new Ticket()
                {
                    Price = 111M,
                    FlightForeignKey = 1,
                },
                new Ticket()
                {
                    //Id = 2,
                    Price = 200M,
                    FlightForeignKey = 2,
                },
                new Ticket()
                {
                    //Id = 3,
                    Price = 300M,
                    FlightForeignKey = 3,
                }
            );

            context.PlaneTypes.AddRange(
                    new PlaneType()
                    {
                        //Id = 1,
                        Model = "AN",
                        Seats = 100,
                        Payload = 3000
                    },
                    new PlaneType()
                    {
                        //Id = 2,
                        Model = "AN",
                        Seats = 200,
                        Payload = 5000
                    },
                    new PlaneType()
                    {
                        //Id = 3,
                        Model = "AN",
                        Seats = 300,
                        Payload = 10000
                    }
                );



            context.Planes.AddRange(
                new Plane()
                {
                    //Id = 1,
                    Name = "Plane1",
                    Type = 1,
                    TimeUsed = "100000"
                },
                new Plane()
                {
                    //Id = 2,
                    Name = "Plane2",
                    Type = 2,
                    TimeUsed = "20000"
                },
                new Plane()
                {
                    //Id = 3,
                    Name = "Plane3",
                    Type = 3,
                    TimeUsed = "30000"
                }
            );




            context.Pilots.AddRange(
                new Pilot()
                {
                    //Id = 1,
                    Name = "John",
                    Surname = "Smith",
                    BirthDay = "1982/05/23",
                    Experience = 20000,
                },
                new Pilot()
                {
                    //Id = 2,
                    Name = "Scott",
                    Surname = "Jonson",
                    BirthDay = "1992/12/03",
                    Experience = 500,
                },
                new Pilot()
                {
                    //Id = 3,
                    Name = "Pall",
                    Surname = "Green",
                    BirthDay = "1989/07/13",
                    Experience = 7000,
                }
            );


            context.Flightattendants.AddRange(
                new Flightattendant()
                {
                    //Id = 1,
                    Name = "Mary",
                    Surname = "Smith",
                    BirthDay = "1999/05/21",
                    CrewForeignKey = 1
                },
                new Flightattendant()
                {
                    //Id = 2,
                    Name = "Jane",
                    Surname = "Jonson",
                    BirthDay = "1998/15/03",
                    CrewForeignKey = 1
                },
                new Flightattendant()
                {
                    //Id = 3,
                    Name = "Liza",
                    Surname = "Green",
                    BirthDay = "1999/08/01",
                    CrewForeignKey = 3

                },
            new Flightattendant()
            {
                //Id = 3,
                Name = "Liza",
                Surname = "Tomas",
                BirthDay = "1997/07/01",
                CrewForeignKey = 2

            }
            );

            context.Flights.AddRange(
                new Flight()
                {
                    //Id = 1,
                    Number = "QW543200",
                    Departure = "Kyiv",
                    Destination = "Lviv",
                    DeparturingTime = "2018-12-14 10:13:20",
                    ArrivingTime = "2018-12-14 10:43:20",
                    Tickets = new List<Ticket>(),
                },
                new Flight()
                {
                    //Id = 3,
                    Number = "PY987500",
                    Departure = "Kyiv",
                    Destination = "Barcelona",
                    DeparturingTime = "2018-12-15 15:13:20",
                    ArrivingTime = "2018-12-15 17:43:20",
                    Tickets = new List<Ticket>(),

                },
                new Flight()
                {
                    //Id = 3,
                    Number = "KJ457000",
                    Departure = "Kyiv",
                    Destination = "Toronto",
                    DeparturingTime = "2018-10-15 05:13:20",
                    ArrivingTime = "2018-10-15 23:43:20",
                    Tickets = new List<Ticket>(),

                }
            );

            context.Crews.AddRange(
                new Crew()
                {
                    //Id = 1,
                    Pilot = 1,
                    FlightAttendantsList = new List<Flightattendant>(),
                },
                new Crew()
                {
                    //Id = 1,
                    Pilot = 2,
                    FlightAttendantsList = new List<Flightattendant>(),
                },
                new Crew()
                {
                    //Id = 1,
                    Pilot = 3,
                    FlightAttendantsList = new List<Flightattendant>(),
                }
            );

            context.Departures.AddRange(
                new Departure()
                {
                    //Id = 1,
                    Flight = 1,
                    Crew = 1,
                    DepartingTime = "2018-12-14 10:33:20",
                    Plane = 1,

                },
                new Departure()
                {
                    //Id = 1,
                    Flight = 2,
                    Crew = 2,
                    DepartingTime = "2018-12-15 15:23:20",
                    Plane = 2,

                },
                new Departure()
                {
                    //Id = 1,
                    Flight = 3,
                    Crew = 3,
                    DepartingTime = "2018-10-15 05:18:20",
                    Plane = 3,

                }
            );

            context.SaveChanges();
        }
    }
}

