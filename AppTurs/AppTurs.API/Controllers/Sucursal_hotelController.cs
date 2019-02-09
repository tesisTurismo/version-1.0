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
using AppTurs.Comun.Models;
using AppTurs.Dominio.Models;

namespace AppTurs.API.Controllers
{
    public class Sucursal_hotelController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Sucursal_hotel
        public IQueryable<Sucursal_hotel> GetSucursal_hotel()
        {
            return db.Sucursal_hotel;
        }

        // GET: api/Sucursal_hotel/5
        [ResponseType(typeof(Sucursal_hotel))]
        public async Task<IHttpActionResult> GetSucursal_hotel(int id)
        {
            Sucursal_hotel sucursal_hotel = await db.Sucursal_hotel.FindAsync(id);
            if (sucursal_hotel == null)
            {
                return NotFound();
            }

            return Ok(sucursal_hotel);
        }

        // PUT: api/Sucursal_hotel/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSucursal_hotel(int id, Sucursal_hotel sucursal_hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sucursal_hotel.idSucursalHotel)
            {
                return BadRequest();
            }

            db.Entry(sucursal_hotel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sucursal_hotelExists(id))
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

        // POST: api/Sucursal_hotel
        [ResponseType(typeof(Sucursal_hotel))]
        public async Task<IHttpActionResult> PostSucursal_hotel(Sucursal_hotel sucursal_hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sucursal_hotel.Add(sucursal_hotel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sucursal_hotel.idSucursalHotel }, sucursal_hotel);
        }

        // DELETE: api/Sucursal_hotel/5
        [ResponseType(typeof(Sucursal_hotel))]
        public async Task<IHttpActionResult> DeleteSucursal_hotel(int id)
        {
            Sucursal_hotel sucursal_hotel = await db.Sucursal_hotel.FindAsync(id);
            if (sucursal_hotel == null)
            {
                return NotFound();
            }

            db.Sucursal_hotel.Remove(sucursal_hotel);
            await db.SaveChangesAsync();

            return Ok(sucursal_hotel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sucursal_hotelExists(int id)
        {
            return db.Sucursal_hotel.Count(e => e.idSucursalHotel == id) > 0;
        }
    }
}