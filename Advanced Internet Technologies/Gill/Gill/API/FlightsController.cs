using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Gill.Models;

namespace Gill.API
{
    public class FlightsController : ApiController
    {
        private AirlineContext db = new AirlineContext();

        // GET: api/Flights
        public IQueryable<FlightDTO> GetFlights()
        {
            var flights = from b in db.Flights
                          select new FlightDTO()
                          {

                              Id = b.Id,
                              Code = b.Code,
                              DestPlace = b.DestPlace,
                              FlightDate = b.FlightDate,
                              Clients = b.Clients.Select(a => new ClientDTO()

                              {
                                  Id = a.Id,
                                  LName = a.LName,
                                  FName = a.FName,
                                  EnrolmentDate = a.EnrolmentDate
                              }

                               ).ToList(),


                               Staffs = b.Staffs.Select(a => new StaffDTO()

                               {
                                   Id = a.Id,
                                   LName = a.LName,
                                   FName = a.FName,
                                   EmployedDate = a.EmployedDate
                               }

                               ).ToList()



                          };
            return flights;
        }

        // GET: api/Flights/5
        [ResponseType(typeof(Flight))]
        public async Task<IHttpActionResult> GetFlight(int id)
        {
            Flight b = await db.Flights.FindAsync(id);
            if (b == null)
            {
                return NotFound();
            }

            FlightDTO flight = new FlightDTO
            {

                Id = b.Id,
                Code = b.Code,
                DestPlace = b.DestPlace,
                FlightDate = b.FlightDate,
                Clients = b.Clients.Select(a => new ClientDTO()

                {
                    Id = a.Id,
                    LName = a.LName,
                    FName = a.FName,
                    EnrolmentDate = a.EnrolmentDate
                }

                               ).ToList(),


                Staffs = b.Staffs.Select(a => new StaffDTO()

                {
                    Id = a.Id,
                    LName = a.LName,
                    FName = a.FName,
                    EmployedDate = a.EmployedDate
                }

                               ).ToList()


            };
            return Ok(flight);
        }

        // PUT: api/Flights/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFlight(int id, Flight flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flight.Id)
            {
                return BadRequest();
            }

            db.Entry(flight).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Flights
        [ResponseType(typeof(Flight))]
        public async Task<IHttpActionResult> PostFlight(Flight flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Flights.Add(flight);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = flight.Id }, flight);
        }

        // DELETE: api/Flights/5
        [ResponseType(typeof(Flight))]
        public async Task<IHttpActionResult> DeleteFlight(int id)
        {
            Flight flight = await db.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            db.Flights.Remove(flight);
            await db.SaveChangesAsync();

            return Ok(flight);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlightExists(int id)
        {
            return db.Flights.Count(e => e.Id == id) > 0;
        }
    }
}