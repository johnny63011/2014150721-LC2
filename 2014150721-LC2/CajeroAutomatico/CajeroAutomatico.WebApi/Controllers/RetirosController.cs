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
    public class RetirosController : ApiController
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





        // GET: api/Retiros
        public IQueryable<Retiro> GetRetiros()
        {
            return db.Retiros;
        }

        // GET: api/Retiros/5
        [ResponseType(typeof(Retiro))]
        public IHttpActionResult GetRetiro(int id)
        {
            Retiro retiro = db.Retiros.Find(id);
            if (retiro == null)
            {
                return NotFound();
            }

            return Ok(retiro);
        }

        // PUT: api/Retiros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRetiro(int id, Retiro retiro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != retiro.retiroId)
            {
                return BadRequest();
            }

            db.Entry(retiro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RetiroExists(id))
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

        // POST: api/Retiros
        [ResponseType(typeof(Retiro))]
        public IHttpActionResult PostRetiro(Retiro retiro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Retiros.Add(retiro);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = retiro.retiroId }, retiro);
        }

        // DELETE: api/Retiros/5
        [ResponseType(typeof(Retiro))]
        public IHttpActionResult DeleteRetiro(int id)
        {
            Retiro retiro = db.Retiros.Find(id);
            if (retiro == null)
            {
                return NotFound();
            }

            db.Retiros.Remove(retiro);
            db.SaveChanges();

            return Ok(retiro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RetiroExists(int id)
        {
            return db.Retiros.Count(e => e.retiroId == id) > 0;
        }
    }
}