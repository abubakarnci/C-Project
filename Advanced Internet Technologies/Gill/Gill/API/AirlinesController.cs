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
    public class AirlinesController : ApiController
    {
        private AirlineContext db = new AirlineContext();

        // GET: api/Airlines
        public IQueryable<AirlineDTO> GetAirline()
        {
            var airlines = from a in db.Airline
                           select new AirlineDTO()
                           {

                               Id = a.Id,
                               Name = a.Name,
                               Origin = a.Origin,
                               Flights = a.Flights.Select(b => new FlightDTO()

                               { Id=b.Id,
                                   Code=b.Code,
                                   DestPlace=b.DestPlace,
                                   FlightDate=b.FlightDate
                               }

                               ).ToList()
                           };

            return airlines;
        }

        // GET: api/Airlines/5
        [ResponseType(typeof(AirlineDTO))]
        public async Task<IHttpActionResult> GetAirline(int id)
        {



            Airline a = await db.Airline.FindAsync(id);
            if (a == null)
            {
                return NotFound();
            }

            AirlineDTO airline = new AirlineDTO
            {

                Id = a.Id,
                Name = a.Name,
                Origin = a.Origin,
                Flights = a.Flights.Select(b => new FlightDTO()

                {
                    Id = b.Id,
                    Code = b.Code,
                    DestPlace = b.DestPlace,
                    FlightDate = b.FlightDate
                }

                               ).ToList()


            };

            return Ok(airline);
            
        }

        // PUT: api/Airlines/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAirline(int id, Airline airline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != airline.Id)
            {
                return BadRequest();
            }

            db.Entry(airline).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirlineExists(id))
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

        // POST: api/Airlines
        [ResponseType(typeof(Airline))]
        public async Task<IHttpActionResult> PostAirline(Airline airline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Airline.Add(airline);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = airline.Id }, airline);
        }

        // DELETE: api/Airlines/5
        [ResponseType(typeof(Airline))]
        public async Task<IHttpActionResult> DeleteAirline(int id)
        {
            Airline airline = await db.Airline.FindAsync(id);
            if (airline == null)
            {
                return NotFound();
            }

            db.Airline.Remove(airline);
            await db.SaveChangesAsync();

            return Ok(airline);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AirlineExists(int id)
        {
            return db.Airline.Count(e => e.Id == id) > 0;
        }
    }
}