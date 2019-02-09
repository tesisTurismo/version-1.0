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
    public class Sucursal_CentrosSaludController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Sucursal_CentrosSalud
        public IQueryable<Sucursal_CentrosSalud> GetSucursal_CentrosSalud()
        {
            return db.Sucursal_CentrosSalud;
        }

        // GET: api/Sucursal_CentrosSalud/5
        [ResponseType(typeof(Sucursal_CentrosSalud))]
        public async Task<IHttpActionResult> GetSucursal_CentrosSalud(int id)
        {
            Sucursal_CentrosSalud sucursal_CentrosSalud = await db.Sucursal_CentrosSalud.FindAsync(id);
            if (sucursal_CentrosSalud == null)
            {
                return NotFound();
            }

            return Ok(sucursal_CentrosSalud);
        }

        // PUT: api/Sucursal_CentrosSalud/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSucursal_CentrosSalud(int id, Sucursal_CentrosSalud sucursal_CentrosSalud)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sucursal_CentrosSalud.idSucursalCentroSalud)
            {
                return BadRequest();
            }

            db.Entry(sucursal_CentrosSalud).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sucursal_CentrosSaludExists(id))
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

        // POST: api/Sucursal_CentrosSalud
        [ResponseType(typeof(Sucursal_CentrosSalud))]
        public async Task<IHttpActionResult> PostSucursal_CentrosSalud(Sucursal_CentrosSalud sucursal_CentrosSalud)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sucursal_CentrosSalud.Add(sucursal_CentrosSalud);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sucursal_CentrosSalud.idSucursalCentroSalud }, sucursal_CentrosSalud);
        }

        // DELETE: api/Sucursal_CentrosSalud/5
        [ResponseType(typeof(Sucursal_CentrosSalud))]
        public async Task<IHttpActionResult> DeleteSucursal_CentrosSalud(int id)
        {
            Sucursal_CentrosSalud sucursal_CentrosSalud = await db.Sucursal_CentrosSalud.FindAsync(id);
            if (sucursal_CentrosSalud == null)
            {
                return NotFound();
            }

            db.Sucursal_CentrosSalud.Remove(sucursal_CentrosSalud);
            await db.SaveChangesAsync();

            return Ok(sucursal_CentrosSalud);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sucursal_CentrosSaludExists(int id)
        {
            return db.Sucursal_CentrosSalud.Count(e => e.idSucursalCentroSalud == id) > 0;
        }
    }
}