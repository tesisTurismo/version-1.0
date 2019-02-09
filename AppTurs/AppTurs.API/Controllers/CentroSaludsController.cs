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
    public class CentroSaludsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/CentroSaluds
        public IQueryable<CentroSalud> GetCentroSaluds()
        {
            return db.CentroSalud;
        }

        // GET: api/CentroSaluds/5
        [ResponseType(typeof(CentroSalud))]
        public async Task<IHttpActionResult> GetCentroSalud(int id)
        {
            CentroSalud centroSalud = await db.CentroSalud.FindAsync(id);
            if (centroSalud == null)
            {
                return NotFound();
            }

            return Ok(centroSalud);
        }

        // PUT: api/CentroSaluds/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCentroSalud(int id, CentroSalud centroSalud)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != centroSalud.idCentroSalud)
            {
                return BadRequest();
            }

            db.Entry(centroSalud).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CentroSaludExists(id))
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

        // POST: api/CentroSaluds
        [ResponseType(typeof(CentroSalud))]
        public async Task<IHttpActionResult> PostCentroSalud(CentroSalud centroSalud)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CentroSalud.Add(centroSalud);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = centroSalud.idCentroSalud }, centroSalud);
        }

        // DELETE: api/CentroSaluds/5
        [ResponseType(typeof(CentroSalud))]
        public async Task<IHttpActionResult> DeleteCentroSalud(int id)
        {
            CentroSalud centroSalud = await db.CentroSalud.FindAsync(id);
            if (centroSalud == null)
            {
                return NotFound();
            }

            db.CentroSalud.Remove(centroSalud);
            await db.SaveChangesAsync();

            return Ok(centroSalud);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CentroSaludExists(int id)
        {
            return db.CentroSalud.Count(e => e.idCentroSalud == id) > 0;
        }
    }
}