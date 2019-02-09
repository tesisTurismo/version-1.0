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
    public class Sucursal_EntretencionNocturnaController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Sucursal_EntretencionNocturna
        public IQueryable<Sucursal_EntretencionNocturna> GetSucursal_EntretencionNocturna()
        {
            return db.Sucursal_EntretencionNocturna;
        }

        // GET: api/Sucursal_EntretencionNocturna/5
        [ResponseType(typeof(Sucursal_EntretencionNocturna))]
        public async Task<IHttpActionResult> GetSucursal_EntretencionNocturna(int id)
        {
            Sucursal_EntretencionNocturna sucursal_EntretencionNocturna = await db.Sucursal_EntretencionNocturna.FindAsync(id);
            if (sucursal_EntretencionNocturna == null)
            {
                return NotFound();
            }

            return Ok(sucursal_EntretencionNocturna);
        }

        // PUT: api/Sucursal_EntretencionNocturna/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSucursal_EntretencionNocturna(int id, Sucursal_EntretencionNocturna sucursal_EntretencionNocturna)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sucursal_EntretencionNocturna.idSucursalEntretencionNoct)
            {
                return BadRequest();
            }

            db.Entry(sucursal_EntretencionNocturna).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sucursal_EntretencionNocturnaExists(id))
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

        // POST: api/Sucursal_EntretencionNocturna
        [ResponseType(typeof(Sucursal_EntretencionNocturna))]
        public async Task<IHttpActionResult> PostSucursal_EntretencionNocturna(Sucursal_EntretencionNocturna sucursal_EntretencionNocturna)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sucursal_EntretencionNocturna.Add(sucursal_EntretencionNocturna);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sucursal_EntretencionNocturna.idSucursalEntretencionNoct }, sucursal_EntretencionNocturna);
        }

        // DELETE: api/Sucursal_EntretencionNocturna/5
        [ResponseType(typeof(Sucursal_EntretencionNocturna))]
        public async Task<IHttpActionResult> DeleteSucursal_EntretencionNocturna(int id)
        {
            Sucursal_EntretencionNocturna sucursal_EntretencionNocturna = await db.Sucursal_EntretencionNocturna.FindAsync(id);
            if (sucursal_EntretencionNocturna == null)
            {
                return NotFound();
            }

            db.Sucursal_EntretencionNocturna.Remove(sucursal_EntretencionNocturna);
            await db.SaveChangesAsync();

            return Ok(sucursal_EntretencionNocturna);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sucursal_EntretencionNocturnaExists(int id)
        {
            return db.Sucursal_EntretencionNocturna.Count(e => e.idSucursalEntretencionNoct == id) > 0;
        }
    }
}