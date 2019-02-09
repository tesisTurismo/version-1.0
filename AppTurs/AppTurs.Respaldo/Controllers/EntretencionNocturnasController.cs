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
    public class EntretencionNocturnasController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: EntretencionNocturnas
        public async Task<ActionResult> Index()
        {
            return View(await db.EntretencionNocturna.ToListAsync());
        }

        // GET: EntretencionNocturnas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntretencionNocturna entretencionNocturna = await db.EntretencionNocturna.FindAsync(id);
            if (entretencionNocturna == null)
            {
                return HttpNotFound();
            }
            return View(entretencionNocturna);
        }

        // GET: EntretencionNocturnas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntretencionNocturnas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idEntretencionNoct,foto,nombre_EntretencionNoct,descripcion_EntretencionNoct,sitio_web")] EntretencionNocturna entretencionNocturna)
        {
            if (ModelState.IsValid)
            {
                db.EntretencionNocturna.Add(entretencionNocturna);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(entretencionNocturna);
        }

        // GET: EntretencionNocturnas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntretencionNocturna entretencionNocturna = await db.EntretencionNocturna.FindAsync(id);
            if (entretencionNocturna == null)
            {
                return HttpNotFound();
            }
            return View(entretencionNocturna);
        }

        // POST: EntretencionNocturnas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idEntretencionNoct,foto,nombre_EntretencionNoct,descripcion_EntretencionNoct,sitio_web")] EntretencionNocturna entretencionNocturna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entretencionNocturna).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(entretencionNocturna);
        }

        // GET: EntretencionNocturnas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntretencionNocturna entretencionNocturna = await db.EntretencionNocturna.FindAsync(id);
            if (entretencionNocturna == null)
            {
                return HttpNotFound();
            }
            return View(entretencionNocturna);
        }

        // POST: EntretencionNocturnas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EntretencionNocturna entretencionNocturna = await db.EntretencionNocturna.FindAsync(id);
            db.EntretencionNocturna.Remove(entretencionNocturna);
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
