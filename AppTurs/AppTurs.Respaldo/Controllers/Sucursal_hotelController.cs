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
    public class Sucursal_hotelController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Sucursal_hotel
        public async Task<ActionResult> Index()
        {
            var sucursal_hotel = db.Sucursal_hotel.Include(s => s.idH);
            return View(await sucursal_hotel.ToListAsync());
        }

        // GET: Sucursal_hotel/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal_hotel sucursal_hotel = await db.Sucursal_hotel.FindAsync(id);
            if (sucursal_hotel == null)
            {
                return HttpNotFound();
            }
            return View(sucursal_hotel);
        }

        // GET: Sucursal_hotel/Create
        public ActionResult Create()
        {
            ViewBag.idHotel = new SelectList(db.Hotel, "idHotel", "nombre_hotel");
            return View();
        }

        // POST: Sucursal_hotel/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idSucursalHotel,calle,numero,telefono,latitud,longitud,idHotel")] Sucursal_hotel sucursal_hotel)
        {
            if (ModelState.IsValid)
            {
                db.Sucursal_hotel.Add(sucursal_hotel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idHotel = new SelectList(db.Hotel, "idHotel", "nombre_hotel", sucursal_hotel.idHotel);
            return View(sucursal_hotel);
        }

        // GET: Sucursal_hotel/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal_hotel sucursal_hotel = await db.Sucursal_hotel.FindAsync(id);
            if (sucursal_hotel == null)
            {
                return HttpNotFound();
            }
            ViewBag.idHotel = new SelectList(db.Hotel, "idHotel", "nombre_hotel", sucursal_hotel.idHotel);
            return View(sucursal_hotel);
        }

        // POST: Sucursal_hotel/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idSucursalHotel,calle,numero,telefono,latitud,longitud,idHotel")] Sucursal_hotel sucursal_hotel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursal_hotel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idHotel = new SelectList(db.Hotel, "idHotel", "nombre_hotel", sucursal_hotel.idHotel);
            return View(sucursal_hotel);
        }

        // GET: Sucursal_hotel/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal_hotel sucursal_hotel = await db.Sucursal_hotel.FindAsync(id);
            if (sucursal_hotel == null)
            {
                return HttpNotFound();
            }
            return View(sucursal_hotel);
        }

        // POST: Sucursal_hotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Sucursal_hotel sucursal_hotel = await db.Sucursal_hotel.FindAsync(id);
            db.Sucursal_hotel.Remove(sucursal_hotel);
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
