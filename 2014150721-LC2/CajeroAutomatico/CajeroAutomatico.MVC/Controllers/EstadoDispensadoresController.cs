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
    public class EstadoDispensadoresController : Controller
    {
        private CajeroAutomaticoDBContext db = new CajeroAutomaticoDBContext();



        private readonly IUnityOfWork _UnityOfWork;

        public EstadoDispensadoresController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;

        }

        public EstadoDispensadoresController()
        {

        }



        // GET: EstadoDispensadores
        public ActionResult Index()
        {
            return View(db.EstadoDispensadores.ToList());
        }

        // GET: EstadoDispensadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoDispensador estadoDispensador = db.EstadoDispensadores.Find(id);
            if (estadoDispensador == null)
            {
                return HttpNotFound();
            }
            return View(estadoDispensador);
        }

        // GET: EstadoDispensadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoDispensadores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "estadoDispensadorId,desEstDispensador")] EstadoDispensador estadoDispensador)
        {
            if (ModelState.IsValid)
            {
                db.EstadoDispensadores.Add(estadoDispensador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoDispensador);
        }

        // GET: EstadoDispensadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoDispensador estadoDispensador = db.EstadoDispensadores.Find(id);
            if (estadoDispensador == null)
            {
                return HttpNotFound();
            }
            return View(estadoDispensador);
        }

        // POST: EstadoDispensadores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "estadoDispensadorId,desEstDispensador")] EstadoDispensador estadoDispensador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoDispensador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoDispensador);
        }

        // GET: EstadoDispensadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoDispensador estadoDispensador = db.EstadoDispensadores.Find(id);
            if (estadoDispensador == null)
            {
                return HttpNotFound();
            }
            return View(estadoDispensador);
        }

        // POST: EstadoDispensadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoDispensador estadoDispensador = db.EstadoDispensadores.Find(id);
            db.EstadoDispensadores.Remove(estadoDispensador);
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
