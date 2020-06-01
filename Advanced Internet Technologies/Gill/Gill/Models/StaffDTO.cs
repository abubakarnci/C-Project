using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gill.Models
{
    public class StaffDTO
    {
        public int Id { get; set; }
        public string LName { get; set; }
        public string FName { get; set; }
        public DateTime EmployedDate { get; set; }

        public List<FlightDTO> Flights { get; set; }

    }
}