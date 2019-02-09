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
    public class Sucursal_CentroSaludController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Sucursal_CentroSalud
        public async Task<ActionResult> Index()
        {
            var sucursal_CentrosSalud = db.Sucursal_CentrosSalud.Include(s => s.idCentroS);
            return View(await sucursal_CentrosSalud.ToListAsync());
        }

        // GET: Sucursal_CentroSalud/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal_CentrosSalud sucursal_CentrosSalud = await db.Sucursal_CentrosSalud.FindAsync(id);
            if (sucursal_CentrosSalud == null)
            {
                return HttpNotFound();
            }
            return View(sucursal_CentrosSalud);
        }

        // GET: Sucursal_CentroSalud/Create
        public ActionResult Create()
        {
            ViewBag.idCentroSalud = new SelectList(db.CentroSalud, "idCentroSalud", "nombre_CentroSalud");
            return View();
        }

        // POST: Sucursal_CentroSalud/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idSucursalCentroSalud,calle,numero,telefono,latitud,longitud,idCentroSalud")] Sucursal_CentrosSalud sucursal_CentrosSalud)
        {
            if (ModelState.IsValid)
            {
                db.Sucursal_CentrosSalud.Add(sucursal_CentrosSalud);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idCentroSalud = new SelectList(db.CentroSalud, "idCentroSalud", "nombre_CentroSalud", sucursal_CentrosSalud.idCentroSalud);
            return View(sucursal_CentrosSalud);
        }

        // GET: Sucursal_CentroSalud/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal_CentrosSalud sucursal_CentrosSalud = await db.Sucursal_CentrosSalud.FindAsync(id);
            if (sucursal_CentrosSalud == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCentroSalud = new SelectList(db.CentroSalud, "idCentroSalud", "nombre_CentroSalud", sucursal_CentrosSalud.idCentroSalud);
            return View(sucursal_CentrosSalud);
        }

        // POST: Sucursal_CentroSalud/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idSucursalCentroSalud,calle,numero,telefono,latitud,longitud,idCentroSalud")] Sucursal_CentrosSalud sucursal_CentrosSalud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursal_CentrosSalud).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idCentroSalud = new SelectList(db.CentroSalud, "idCentroSalud", "nombre_CentroSalud", sucursal_CentrosSalud.idCentroSalud);
            return View(sucursal_CentrosSalud);
        }

        // GET: Sucursal_CentroSalud/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal_CentrosSalud sucursal_CentrosSalud = await db.Sucursal_CentrosSalud.FindAsync(id);
            if (sucursal_CentrosSalud == null)
            {
                return HttpNotFound();
            }
            return View(sucursal_CentrosSalud);
        }

        // POST: Sucursal_CentroSalud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Sucursal_CentrosSalud sucursal_CentrosSalud = await db.Sucursal_CentrosSalud.FindAsync(id);
            db.Sucursal_CentrosSalud.Remove(sucursal_CentrosSalud);
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
