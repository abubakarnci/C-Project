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
    public class ClientsController : ApiController
    {
        private AirlineContext db = new AirlineContext();

        // GET: api/Clients
        public IQueryable<ClientDTO> GetClients()
        {

            var clients = from a in db.Clients
                          select new ClientDTO()
                          {

                              Id = a.Id,
                              LName = a.LName,
                              FName = a.FName,
                              EnrolmentDate = a.EnrolmentDate,
                              Flights = a.Flights.Select(b => new FlightDTO()

                              {
                                  Id = b.Id,
                                  Code = b.Code,
                                  DestPlace = b.DestPlace,
                                  FlightDate = b.FlightDate
                              }

                               ).ToList()


                          };

            return clients;
        }

        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> GetClient(int id)
        {
            Client a = await db.Clients.FindAsync(id);
            if (a == null)
            {
                return NotFound();
            }

            ClientDTO client = new ClientDTO
            {

                Id = a.Id,
                LName = a.LName,
                FName = a.FName,
                EnrolmentDate = a.EnrolmentDate,
                Flights = a.Flights.Select(b => new FlightDTO()

                {
                    Id = b.Id,
                    Code = b.Code,
                    DestPlace = b.DestPlace,
                    FlightDate = b.FlightDate
                }

                               ).ToList()

            };

            return Ok(client);



        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.Id)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(client);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = client.Id }, client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public async Task<IHttpActionResult> DeleteClient(int id)
        {
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Clients.Remove(client);
            await db.SaveChangesAsync();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Clients.Count(e => e.Id == id) > 0;
        }
    }
}