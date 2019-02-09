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
    public class Sucursal_RestauranteController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Sucursal_Restaurante
        public async Task<ActionResult> Index()
        {
            var sucursal_Restaurante = db.Sucursal_Restaurante.Include(s => s.idRest);
            return View(await sucursal_Restaurante.ToListAsync());
        }

        // GET: Sucursal_Restaurante/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal_Restaurante sucursal_Restaurante = await db.Sucursal_Restaurante.FindAsync(id);
            if (sucursal_Restaurante == null)
            {
                return HttpNotFound();
            }
            return View(sucursal_Restaurante);
        }

        // GET: Sucursal_Restaurante/Create
        public ActionResult Create()
        {
            ViewBag.idrestaurante = new SelectList(db.Restaurantes, "idrestaurante", "nombre_rest");
            return View();
        }

        // POST: Sucursal_Restaurante/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idSucursalRest,calle,numero,telefono,latitud,longitud,idrestaurante")] Sucursal_Restaurante sucursal_Restaurante)
        {
            if (ModelState.IsValid)
            {
                db.Sucursal_Restaurante.Add(sucursal_Restaurante);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idrestaurante = new SelectList(db.Restaurantes, "idrestaurante", "nombre_rest", sucursal_Restaurante.idrestaurante);
            return View(sucursal_Restaurante);
        }

        // GET: Sucursal_Restaurante/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal_Restaurante sucursal_Restaurante = await db.Sucursal_Restaurante.FindAsync(id);
            if (sucursal_Restaurante == null)
            {
                return HttpNotFound();
            }
            ViewBag.idrestaurante = new SelectList(db.Restaurantes, "idrestaurante", "nombre_rest", sucursal_Restaurante.idrestaurante);
            return View(sucursal_Restaurante);
        }

        // POST: Sucursal_Restaurante/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idSucursalRest,calle,numero,telefono,latitud,longitud,idrestaurante")] Sucursal_Restaurante sucursal_Restaurante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursal_Restaurante).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idrestaurante = new SelectList(db.Restaurantes, "idrestaurante", "nombre_rest", sucursal_Restaurante.idrestaurante);
            return View(sucursal_Restaurante);
        }

        // GET: Sucursal_Restaurante/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal_Restaurante sucursal_Restaurante = await db.Sucursal_Restaurante.FindAsync(id);
            if (sucursal_Restaurante == null)
            {
                return HttpNotFound();
            }
            return View(sucursal_Restaurante);
        }

        // POST: Sucursal_Restaurante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Sucursal_Restaurante sucursal_Restaurante = await db.Sucursal_Restaurante.FindAsync(id);
            db.Sucursal_Restaurante.Remove(sucursal_Restaurante);
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
