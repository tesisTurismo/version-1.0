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
    public class RestaurantesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Restaurantes
        public IQueryable<Restaurante> GetRestaurantes()
        {
            return db.Restaurantes;
        }

        // GET: api/Restaurantes/5
        [ResponseType(typeof(Restaurante))]
        public async Task<IHttpActionResult> GetRestaurante(int id)
        {
            Restaurante restaurante = await db.Restaurantes.FindAsync(id);
            if (restaurante == null)
            {
                return NotFound();
            }

            return Ok(restaurante);
        }

        // PUT: api/Restaurantes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRestaurante(int id, Restaurante restaurante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurante.idrestaurante)
            {
                return BadRequest();
            }

            db.Entry(restaurante).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestauranteExists(id))
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

        // POST: api/Restaurantes
        [ResponseType(typeof(Restaurante))]
        public async Task<IHttpActionResult> PostRestaurante(Restaurante restaurante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Restaurantes.Add(restaurante);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = restaurante.idrestaurante }, restaurante);
        }

        // DELETE: api/Restaurantes/5
        [ResponseType(typeof(Restaurante))]
        public async Task<IHttpActionResult> DeleteRestaurante(int id)
        {
            Restaurante restaurante = await db.Restaurantes.FindAsync(id);
            if (restaurante == null)
            {
                return NotFound();
            }

            db.Restaurantes.Remove(restaurante);
            await db.SaveChangesAsync();

            return Ok(restaurante);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestauranteExists(int id)
        {
            return db.Restaurantes.Count(e => e.idrestaurante == id) > 0;
        }
    }
}