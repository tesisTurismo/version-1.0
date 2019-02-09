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
    public class Sucursal_EntretencionNocturnaController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Sucursal_EntretencionNocturna
        public async Task<ActionResult> Index()
        {
            var sucursal_EntretencionNocturna = db.Sucursal_EntretencionNocturna.Include(s => s.idEntretNoc);
            return View(await sucursal_EntretencionNocturna.ToListAsync());
        }

        // GET: Sucursal_EntretencionNocturna/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal_EntretencionNocturna sucursal_EntretencionNocturna = await db.Sucursal_EntretencionNocturna.FindAsync(id);
            if (sucursal_EntretencionNocturna == null)
            {
                return HttpNotFound();
            }
            return View(sucursal_EntretencionNocturna);
        }

        // GET: Sucursal_EntretencionNocturna/Create
        public ActionResult Create()
        {
            ViewBag.idEntretencionNoct = new SelectList(db.EntretencionNocturna, "idEntretencionNoct", "nombre_EntretencionNoct");
            return View();
        }

        // POST: Sucursal_EntretencionNocturna/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idSucursalEntretencionNoct,calle,numero,telefono,latitud,longitud,idEntretencionNoct")] Sucursal_EntretencionNocturna sucursal_EntretencionNocturna)
        {
            if (ModelState.IsValid)
            {
                db.Sucursal_EntretencionNocturna.Add(sucursal_EntretencionNocturna);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idEntretencionNoct = new SelectList(db.EntretencionNocturna, "idEntretencionNoct", "nombre_EntretencionNoct", sucursal_EntretencionNocturna.idEntretencionNoct);
            return View(sucursal_EntretencionNocturna);
        }

        // GET: Sucursal_EntretencionNocturna/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal_EntretencionNocturna sucursal_EntretencionNocturna = await db.Sucursal_EntretencionNocturna.FindAsync(id);
            if (sucursal_EntretencionNocturna == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEntretencionNoct = new SelectList(db.EntretencionNocturna, "idEntretencionNoct", "nombre_EntretencionNoct", sucursal_EntretencionNocturna.idEntretencionNoct);
            return View(sucursal_EntretencionNocturna);
        }

        // POST: Sucursal_EntretencionNocturna/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idSucursalEntretencionNoct,calle,numero,telefono,latitud,longitud,idEntretencionNoct")] Sucursal_EntretencionNocturna sucursal_EntretencionNocturna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursal_EntretencionNocturna).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idEntretencionNoct = new SelectList(db.EntretencionNocturna, "idEntretencionNoct", "nombre_EntretencionNoct", sucursal_EntretencionNocturna.idEntretencionNoct);
            return View(sucursal_EntretencionNocturna);
        }

        // GET: Sucursal_EntretencionNocturna/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal_EntretencionNocturna sucursal_EntretencionNocturna = await db.Sucursal_EntretencionNocturna.FindAsync(id);
            if (sucursal_EntretencionNocturna == null)
            {
                return HttpNotFound();
            }
            return View(sucursal_EntretencionNocturna);
        }

        // POST: Sucursal_EntretencionNocturna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Sucursal_EntretencionNocturna sucursal_EntretencionNocturna = await db.Sucursal_EntretencionNocturna.FindAsync(id);
            db.Sucursal_EntretencionNocturna.Remove(sucursal_EntretencionNocturna);
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
