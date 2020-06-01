using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gill.Models
{
    public class AirlineDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }

        public List<FlightDTO> Flights { get; set; }

    }
}