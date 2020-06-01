using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gill.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string DestPlace { get; set; }
        public DateTime FlightDate { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
    }
}