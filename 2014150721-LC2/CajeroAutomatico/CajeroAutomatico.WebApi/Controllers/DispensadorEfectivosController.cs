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
    public class DispensadorEfectivosController : ApiController
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




        // GET: api/DispensadorEfectivos
        public IQueryable<DispensadorEfectivo> GetDispensadorEfectivos()
        {
            return db.DispensadorEfectivos;
        }

        // GET: api/DispensadorEfectivos/5
        [ResponseType(typeof(DispensadorEfectivo))]
        public IHttpActionResult GetDispensadorEfectivo(int id)
        {
            DispensadorEfectivo dispensadorEfectivo = db.DispensadorEfectivos.Find(id);
            if (dispensadorEfectivo == null)
            {
                return NotFound();
            }

            return Ok(dispensadorEfectivo);
        }

        // PUT: api/DispensadorEfectivos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDispensadorEfectivo(int id, DispensadorEfectivo dispensadorEfectivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dispensadorEfectivo.dispensadorEfectivoId)
            {
                return BadRequest();
            }

            db.Entry(dispensadorEfectivo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DispensadorEfectivoExists(id))
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

        // POST: api/DispensadorEfectivos
        [ResponseType(typeof(DispensadorEfectivo))]
        public IHttpActionResult PostDispensadorEfectivo(DispensadorEfectivo dispensadorEfectivo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DispensadorEfectivos.Add(dispensadorEfectivo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dispensadorEfectivo.dispensadorEfectivoId }, dispensadorEfectivo);
        }

        // DELETE: api/DispensadorEfectivos/5
        [ResponseType(typeof(DispensadorEfectivo))]
        public IHttpActionResult DeleteDispensadorEfectivo(int id)
        {
            DispensadorEfectivo dispensadorEfectivo = db.DispensadorEfectivos.Find(id);
            if (dispensadorEfectivo == null)
            {
                return NotFound();
            }

            db.DispensadorEfectivos.Remove(dispensadorEfectivo);
            db.SaveChanges();

            return Ok(dispensadorEfectivo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DispensadorEfectivoExists(int id)
        {
            return db.DispensadorEfectivos.Count(e => e.dispensadorEfectivoId == id) > 0;
        }
    }
}