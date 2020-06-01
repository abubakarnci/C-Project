namespace Gill.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using Gill.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<Gill.Models.AirlineContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Gill.Models.AirlineContext";
        }

        protected override void Seed(Gill.Models.AirlineContext context)
        {

            var flights = new List<Flight>
            {
                new Flight{Code=2242, DestPlace="UK", FlightDate=DateTime.Parse("2005-09-01") },
                new Flight{Code=2542, DestPlace="USA", FlightDate=DateTime.Parse("2006-09-01") },
                new Flight{Code=3242, DestPlace="Ireland", FlightDate=DateTime.Parse("2007-09-01") },

            };
            flights.ForEach(s => context.Flights.Add(s));
            context.SaveChanges();

            var staffs = new List<Staff>
            {
                new Staff{FName="Lisa", LName="Murphy", EmployedDate=DateTime.Parse("2008-02-01") },
                new Staff{FName="Sam", LName="Cogon", EmployedDate=DateTime.Parse("2009-03-01") },
                new Staff{FName="Paul", LName="Hays", EmployedDate=DateTime.Parse("2010-05-01") },

            };
            staffs.ForEach(s => context.Staffs.Add(s));
            context.SaveChanges();

            var clients = new List<Client>
            {
                new Client{FName="Jason", LName="Smyth", EnrolmentDate=DateTime.Parse("2018-02-01") },
                new Client{FName="Umer", LName="Iqbal", EnrolmentDate=DateTime.Parse("2019-03-01") },
                new Client{FName="Muhammad", LName="Abubakar", EnrolmentDate=DateTime.Parse("2019-05-01") },

            };
            clients.ForEach(s => context.Clients.Add(s));
            context.SaveChanges();

            var airlines = new List<Airline>
            {
                new Airline{Name="Gill's Airline", Origin="Ireland" },
                

            };
            airlines.ForEach(s => context.Airline.Add(s));
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
