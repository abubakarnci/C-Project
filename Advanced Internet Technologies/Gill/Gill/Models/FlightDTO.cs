using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gill.Models
{
    public class FlightDTO
    {

        public int Id { get; set; }
        public int Code { get; set; }
        public string DestPlace { get; set; }
        public DateTime FlightDate { get; set; }

        public List<ClientDTO> Clients { get; set; }
        public List<StaffDTO> Staffs { get; set; }
    }
}