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
    public class CentroSaludsController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: CentroSaluds
        public async Task<ActionResult> Index()
        {
            return View(await db.CentroSalud.ToListAsync());
        }

        // GET: CentroSaluds/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroSalud centroSalud = await db.CentroSalud.FindAsync(id);
            if (centroSalud == null)
            {
                return HttpNotFound();
            }
            return View(centroSalud);
        }

        // GET: CentroSaluds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CentroSaluds/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idCentroSalud,foto,nombre_CentroSalud,descripcion_CentroSalud,sitio_web")] CentroSalud centroSalud)
        {
            if (ModelState.IsValid)
            {
                db.CentroSalud.Add(centroSalud);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(centroSalud);
        }

        // GET: CentroSaluds/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroSalud centroSalud = await db.CentroSalud.FindAsync(id);
            if (centroSalud == null)
            {
                return HttpNotFound();
            }
            return View(centroSalud);
        }

        // POST: CentroSaluds/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idCentroSalud,foto,nombre_CentroSalud,descripcion_CentroSalud,sitio_web")] CentroSalud centroSalud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(centroSalud).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(centroSalud);
        }

        // GET: CentroSaluds/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CentroSalud centroSalud = await db.CentroSalud.FindAsync(id);
            if (centroSalud == null)
            {
                return HttpNotFound();
            }
            return View(centroSalud);
        }

        // POST: CentroSaluds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CentroSalud centroSalud = await db.CentroSalud.FindAsync(id);
            db.CentroSalud.Remove(centroSalud);
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
