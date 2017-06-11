using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CajeroAutomatico.Entities.Entities;
using CajeroAutomatico.Persistencia;
using CajeroAutomatico.Entities.IRepositories;

namespace CajeroAutomatico.MVC.Controllers
{
    public class DispensadorEfectivosController : Controller
    {
        private CajeroAutomaticoDBContext db = new CajeroAutomaticoDBContext();




        private readonly IUnityOfWork _UnityOfWork;



        public DispensadorEfectivosController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;

        }

        public DispensadorEfectivosController()
        {

        }





        // GET: DispensadorEfectivos
        public ActionResult Index()
        {
            var dispensadorEfectivos = db.DispensadorEfectivos.Include(d => d.EstadoDispensador);
            return View(dispensadorEfectivos.ToList());
        }

        // GET: DispensadorEfectivos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DispensadorEfectivo dispensadorEfectivo = db.DispensadorEfectivos.Find(id);
            if (dispensadorEfectivo == null)
            {
                return HttpNotFound();
            }
            return View(dispensadorEfectivo);
        }

        // GET: DispensadorEfectivos/Create
        public ActionResult Create()
        {
            ViewBag.estadoDispensadorId = new SelectList(db.EstadoDispensadores, "estadoDispensadorId", "desEstDispensador");
            return View();
        }

        // POST: DispensadorEfectivos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dispensadorEfectivoId,ubicacion,dineroTotal,estadoDispensadorId")] DispensadorEfectivo dispensadorEfectivo)
        {
            if (ModelState.IsValid)
            {
                db.DispensadorEfectivos.Add(dispensadorEfectivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.estadoDispensadorId = new SelectList(db.EstadoDispensadores, "estadoDispensadorId", "desEstDispensador", dispensadorEfectivo.estadoDispensadorId);
            return View(dispensadorEfectivo);
        }

        // GET: DispensadorEfectivos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DispensadorEfectivo dispensadorEfectivo = db.DispensadorEfectivos.Find(id);
            if (dispensadorEfectivo == null)
            {
                return HttpNotFound();
            }
            ViewBag.estadoDispensadorId = new SelectList(db.EstadoDispensadores, "estadoDispensadorId", "desEstDispensador", dispensadorEfectivo.estadoDispensadorId);
            return View(dispensadorEfectivo);
        }

        // POST: DispensadorEfectivos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dispensadorEfectivoId,ubicacion,dineroTotal,estadoDispensadorId")] DispensadorEfectivo dispensadorEfectivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dispensadorEfectivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.estadoDispensadorId = new SelectList(db.EstadoDispensadores, "estadoDispensadorId", "desEstDispensador", dispensadorEfectivo.estadoDispensadorId);
            return View(dispensadorEfectivo);
        }

        // GET: DispensadorEfectivos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DispensadorEfectivo dispensadorEfectivo = db.DispensadorEfectivos.Find(id);
            if (dispensadorEfectivo == null)
            {
                return HttpNotFound();
            }
            return View(dispensadorEfectivo);
        }

        // POST: DispensadorEfectivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DispensadorEfectivo dispensadorEfectivo = db.DispensadorEfectivos.Find(id);
            db.DispensadorEfectivos.Remove(dispensadorEfectivo);
            db.SaveChanges();
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
