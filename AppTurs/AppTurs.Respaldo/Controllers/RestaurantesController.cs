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
using AppTurs.Respaldo.Herlpers;

namespace AppTurs.Respaldo.Controllers
{
    public class RestaurantesController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Restaurantes
        public async Task<ActionResult> Index()
        {
            return View(await db.Restaurantes.OrderBy(r  =>r.nombre_rest).ToListAsync());
        }

        // GET: Restaurantes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurante restaurante = await db.Restaurantes.FindAsync(id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }
            return View(restaurante);
        }

        // GET: Restaurantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create( RestauranteView viewRest)
        {
            if (ModelState.IsValid)
            {
                var pic = string.Empty;
                var folder = "~/Content/ImagenesRest";
                if (viewRest.fotoFile!=null)
                {
                    pic = FilesHelper.UploadPhoto(viewRest.fotoFile,folder);
                    pic = $"{folder}/{pic}";
                }

                var restaurante = this.ToRestaurante(viewRest,pic);


                db.Restaurantes.Add(restaurante);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(viewRest);
        }

        private Restaurante ToRestaurante(RestauranteView viewRest, string pic)
        {
            return new Restaurante
            {
                foto= pic,
                nombre_rest=viewRest.nombre_rest,
                descripcion_rest=viewRest.descripcion_rest,
                sitio_web=viewRest.sitio_web
            };
        }

        // GET: Restaurantes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurante restaurante = await db.Restaurantes.FindAsync(id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }
            var view = this.ToView(restaurante);
            return View(view);
        }

        private RestauranteView ToView(Restaurante restaurante)
        {
            return new RestauranteView
            {
                idrestaurante = restaurante.idrestaurante,
                foto = restaurante.foto,
                nombre_rest = restaurante.nombre_rest,
                descripcion_rest = restaurante.descripcion_rest,
                sitio_web = restaurante.sitio_web
            };
        }

        // POST: Restaurantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Restaurante restaurante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurante).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(restaurante);
        }

        // GET: Restaurantes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurante restaurante = await db.Restaurantes.FindAsync(id);
            if (restaurante == null)
            {
                return HttpNotFound();
            }
            return View(restaurante);
        }

        // POST: Restaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Restaurante restaurante = await db.Restaurantes.FindAsync(id);
            db.Restaurantes.Remove(restaurante);
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
