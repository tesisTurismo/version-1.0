using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppTurs.Comun.Models;
using AppTurs.Respaldo.Models;

namespace AppTurs.Respaldo.Controllers
{
    public class Lugar_TuristicoController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Lugar_Turistico
        public async Task<ActionResult> Index()
        {
            return View(await db.Lugar_Turistico.ToListAsync());
        }

        // GET: Lugar_Turistico/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lugar_Turistico lugar_Turistico = await db.Lugar_Turistico.FindAsync(id);
            if (lugar_Turistico == null)
            {
                return HttpNotFound();
            }
            return View(lugar_Turistico);
        }

        // GET: Lugar_Turistico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lugar_Turistico/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idLugarTuristico,foto,nombre_LugarTuristico,descripcion_LugarTuristico,sitio_web,latitud,longitud")] Lugar_Turistico lugar_Turistico)
        {
            if (ModelState.IsValid)
            {
                db.Lugar_Turistico.Add(lugar_Turistico);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(lugar_Turistico);
        }

        // GET: Lugar_Turistico/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lugar_Turistico lugar_Turistico = await db.Lugar_Turistico.FindAsync(id);
            if (lugar_Turistico == null)
            {
                return HttpNotFound();
            }
            return View(lugar_Turistico);
        }

        // POST: Lugar_Turistico/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idLugarTuristico,foto,nombre_LugarTuristico,descripcion_LugarTuristico,sitio_web,latitud,longitud")] Lugar_Turistico lugar_Turistico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lugar_Turistico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(lugar_Turistico);
        }

        // GET: Lugar_Turistico/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lugar_Turistico lugar_Turistico = await db.Lugar_Turistico.FindAsync(id);
            if (lugar_Turistico == null)
            {
                return HttpNotFound();
            }
            return View(lugar_Turistico);
        }

        // POST: Lugar_Turistico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Lugar_Turistico lugar_Turistico = await db.Lugar_Turistico.FindAsync(id);
            db.Lugar_Turistico.Remove(lugar_Turistico);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
