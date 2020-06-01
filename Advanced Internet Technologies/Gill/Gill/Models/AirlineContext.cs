using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Gill.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Gill.Models
{
    public class AirlineContext: DbContext
    {

        public AirlineContext() : base("AirlineContext") { 
        
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Flight> Flights { get; set; }
       
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Airline> Airline { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}