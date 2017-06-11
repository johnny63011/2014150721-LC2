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
    public class RetirosController : Controller
    {
        private CajeroAutomaticoDBContext db = new CajeroAutomaticoDBContext();



        private readonly IUnityOfWork _UnityOfWork;

        public RetirosController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;

        }

        public RetirosController()
        {

        }


        // GET: Retiros
        public ActionResult Index()
        {
            var retiros = db.Retiros.Include(r => r.Atm).Include(r => r.DispensadorEfectivo);
            return View(retiros.ToList());
        }

        // GET: Retiros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retiro retiro = db.Retiros.Find(id);
            if (retiro == null)
            {
                return HttpNotFound();
            }
            return View(retiro);
        }

        // GET: Retiros/Create
        public ActionResult Create()
        {
            ViewBag.atmId = new SelectList(db.Atm, "atmId", "desAtm");
            ViewBag.dispensadorEfectivoId = new SelectList(db.DispensadorEfectivos, "dispensadorEfectivoId", "ubicacion");
            return View();
        }

        // POST: Retiros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "retiroId,fechaRetiro,montoRetiro,atmId,dispensadorEfectivoId")] Retiro retiro)
        {
            if (ModelState.IsValid)
            {
                db.Retiros.Add(retiro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.atmId = new SelectList(db.Atm, "atmId", "desAtm", retiro.atmId);
            ViewBag.dispensadorEfectivoId = new SelectList(db.DispensadorEfectivos, "dispensadorEfectivoId", "ubicacion", retiro.dispensadorEfectivoId);
            return View(retiro);
        }

        // GET: Retiros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retiro retiro = db.Retiros.Find(id);
            if (retiro == null)
            {
                return HttpNotFound();
            }
            ViewBag.atmId = new SelectList(db.Atm, "atmId", "desAtm", retiro.atmId);
            ViewBag.dispensadorEfectivoId = new SelectList(db.DispensadorEfectivos, "dispensadorEfectivoId", "ubicacion", retiro.dispensadorEfectivoId);
            return View(retiro);
        }

        // POST: Retiros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "retiroId,fechaRetiro,montoRetiro,atmId,dispensadorEfectivoId")] Retiro retiro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(retiro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.atmId = new SelectList(db.Atm, "atmId", "desAtm", retiro.atmId);
            ViewBag.dispensadorEfectivoId = new SelectList(db.DispensadorEfectivos, "dispensadorEfectivoId", "ubicacion", retiro.dispensadorEfectivoId);
            return View(retiro);
        }

        // GET: Retiros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Retiro retiro = db.Retiros.Find(id);
            if (retiro == null)
            {
                return HttpNotFound();
            }
            return View(retiro);
        }

        // POST: Retiros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Retiro retiro = db.Retiros.Find(id);
            db.Retiros.Remove(retiro);
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
