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
    public class EntretencionNocturnasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/EntretencionNocturnas
        public IQueryable<EntretencionNocturna> GetEntretencionNocturnas()
        {
            return db.EntretencionNocturna;
        }

        // GET: api/EntretencionNocturnas/5
        [ResponseType(typeof(EntretencionNocturna))]
        public async Task<IHttpActionResult> GetEntretencionNocturna(int id)
        {
            EntretencionNocturna entretencionNocturna = await db.EntretencionNocturna.FindAsync(id);
            if (entretencionNocturna == null)
            {
                return NotFound();
            }

            return Ok(entretencionNocturna);
        }

        // PUT: api/EntretencionNocturnas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEntretencionNocturna(int id, EntretencionNocturna entretencionNocturna)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entretencionNocturna.idEntretencionNoct)
            {
                return BadRequest();
            }

            db.Entry(entretencionNocturna).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntretencionNocturnaExists(id))
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

        // POST: api/EntretencionNocturnas
        [ResponseType(typeof(EntretencionNocturna))]
        public async Task<IHttpActionResult> PostEntretencionNocturna(EntretencionNocturna entretencionNocturna)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EntretencionNocturna.Add(entretencionNocturna);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = entretencionNocturna.idEntretencionNoct }, entretencionNocturna);
        }

        // DELETE: api/EntretencionNocturnas/5
        [ResponseType(typeof(EntretencionNocturna))]
        public async Task<IHttpActionResult> DeleteEntretencionNocturna(int id)
        {
            EntretencionNocturna entretencionNocturna = await db.EntretencionNocturna.FindAsync(id);
            if (entretencionNocturna == null)
            {
                return NotFound();
            }

            db.EntretencionNocturna.Remove(entretencionNocturna);
            await db.SaveChangesAsync();

            return Ok(entretencionNocturna);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntretencionNocturnaExists(int id)
        {
            return db.EntretencionNocturna.Count(e => e.idEntretencionNoct == id) > 0;
        }
    }
}