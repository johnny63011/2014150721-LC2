using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CajeroAutomatico.Entities.Entities;
using CajeroAutomatico.Persistencia;
using CajeroAutomatico.Entities.IRepositories;

namespace CajeroAutomatico.WebApi.Controllers
{
    public class ATMsController : ApiController
    {
        private CajeroAutomaticoDBContext db = new CajeroAutomaticoDBContext();




        private readonly IUnityOfWork _UnityOfWork;


        public ATMsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;

        }

        public ATMsController()
        {

        }






        // GET: api/ATMs
        public IQueryable<ATM> GetAtm()
        {
            return db.Atm;
        }

        // GET: api/ATMs/5
        [ResponseType(typeof(ATM))]
        public IHttpActionResult GetATM(int id)
        {
            ATM aTM = db.Atm.Find(id);
            if (aTM == null)
            {
                return NotFound();
            }

            return Ok(aTM);
        }

        // PUT: api/ATMs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutATM(int id, ATM aTM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aTM.atmId)
            {
                return BadRequest();
            }

            db.Entry(aTM).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ATMExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ATMs
        [ResponseType(typeof(ATM))]
        public IHttpActionResult PostATM(ATM aTM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Atm.Add(aTM);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aTM.atmId }, aTM);
        }

        // DELETE: api/ATMs/5
        [ResponseType(typeof(ATM))]
        public IHttpActionResult DeleteATM(int id)
        {
            ATM aTM = db.Atm.Find(id);
            if (aTM == null)
            {
                return NotFound();
            }

            db.Atm.Remove(aTM);
            db.SaveChanges();

            return Ok(aTM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ATMExists(int id)
        {
            return db.Atm.Count(e => e.atmId == id) > 0;
        }
    }
}