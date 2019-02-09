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
    public class Sucursal_RestauranteController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Sucursal_Restaurante
        public IQueryable<Sucursal_Restaurante> GetSucursal_Restaurante()
        {
            return db.Sucursal_Restaurante;
        }

        // GET: api/Sucursal_Restaurante/5
        [ResponseType(typeof(Sucursal_Restaurante))]
        public async Task<IHttpActionResult> GetSucursal_Restaurante(int id)
        {
            Sucursal_Restaurante sucursal_Restaurante = await db.Sucursal_Restaurante.FindAsync(id);
            if (sucursal_Restaurante == null)
            {
                return NotFound();
            }

            return Ok(sucursal_Restaurante);
        }

        // PUT: api/Sucursal_Restaurante/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSucursal_Restaurante(int id, Sucursal_Restaurante sucursal_Restaurante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sucursal_Restaurante.idSucursalRest)
            {
                return BadRequest();
            }

            db.Entry(sucursal_Restaurante).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sucursal_RestauranteExists(id))
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

        // POST: api/Sucursal_Restaurante
        [ResponseType(typeof(Sucursal_Restaurante))]
        public async Task<IHttpActionResult> PostSucursal_Restaurante(Sucursal_Restaurante sucursal_Restaurante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sucursal_Restaurante.Add(sucursal_Restaurante);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sucursal_Restaurante.idSucursalRest }, sucursal_Restaurante);
        }

        // DELETE: api/Sucursal_Restaurante/5
        [ResponseType(typeof(Sucursal_Restaurante))]
        public async Task<IHttpActionResult> DeleteSucursal_Restaurante(int id)
        {
            Sucursal_Restaurante sucursal_Restaurante = await db.Sucursal_Restaurante.FindAsync(id);
            if (sucursal_Restaurante == null)
            {
                return NotFound();
            }

            db.Sucursal_Restaurante.Remove(sucursal_Restaurante);
            await db.SaveChangesAsync();

            return Ok(sucursal_Restaurante);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sucursal_RestauranteExists(int id)
        {
            return db.Sucursal_Restaurante.Count(e => e.idSucursalRest == id) > 0;
        }
    }
}