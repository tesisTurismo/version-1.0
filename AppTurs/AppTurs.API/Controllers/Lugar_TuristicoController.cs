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
    public class Lugar_TuristicoController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Lugar_Turistico
        public IQueryable<Lugar_Turistico> GetLugar_Turistico()
        {
            return db.Lugar_Turistico;
        }

        // GET: api/Lugar_Turistico/5
        [ResponseType(typeof(Lugar_Turistico))]
        public async Task<IHttpActionResult> GetLugar_Turistico(int id)
        {
            Lugar_Turistico lugar_Turistico = await db.Lugar_Turistico.FindAsync(id);
            if (lugar_Turistico == null)
            {
                return NotFound();
            }

            return Ok(lugar_Turistico);
        }

        // PUT: api/Lugar_Turistico/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLugar_Turistico(int id, Lugar_Turistico lugar_Turistico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lugar_Turistico.idLugarTuristico)
            {
                return BadRequest();
            }

            db.Entry(lugar_Turistico).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Lugar_TuristicoExists(id))
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

        // POST: api/Lugar_Turistico
        [ResponseType(typeof(Lugar_Turistico))]
        public async Task<IHttpActionResult> PostLugar_Turistico(Lugar_Turistico lugar_Turistico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lugar_Turistico.Add(lugar_Turistico);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = lugar_Turistico.idLugarTuristico }, lugar_Turistico);
        }

        // DELETE: api/Lugar_Turistico/5
        [ResponseType(typeof(Lugar_Turistico))]
        public async Task<IHttpActionResult> DeleteLugar_Turistico(int id)
        {
            Lugar_Turistico lugar_Turistico = await db.Lugar_Turistico.FindAsync(id);
            if (lugar_Turistico == null)
            {
                return NotFound();
            }

            db.Lugar_Turistico.Remove(lugar_Turistico);
            await db.SaveChangesAsync();

            return Ok(lugar_Turistico);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Lugar_TuristicoExists(int id)
        {
            return db.Lugar_Turistico.Count(e => e.idLugarTuristico == id) > 0;
        }
    }
}