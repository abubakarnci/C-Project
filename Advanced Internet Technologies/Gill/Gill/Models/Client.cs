using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gill.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string LName { get; set; }
        public string FName { get; set; }
        public DateTime EnrolmentDate { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}