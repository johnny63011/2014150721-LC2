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
    public class EstadoDispensadoresController : ApiController
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




        // GET: api/EstadoDispensadores
        public IQueryable<EstadoDispensador> GetEstadoDispensadores()
        {
            return db.EstadoDispensadores;
        }

        // GET: api/EstadoDispensadores/5
        [ResponseType(typeof(EstadoDispensador))]
        public IHttpActionResult GetEstadoDispensador(int id)
        {
            EstadoDispensador estadoDispensador = db.EstadoDispensadores.Find(id);
            if (estadoDispensador == null)
            {
                return NotFound();
            }

            return Ok(estadoDispensador);
        }

        // PUT: api/EstadoDispensadores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstadoDispensador(int id, EstadoDispensador estadoDispensador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estadoDispensador.estadoDispensadorId)
            {
                return BadRequest();
            }

            db.Entry(estadoDispensador).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoDispensadorExists(id))
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

        // POST: api/EstadoDispensadores
        [ResponseType(typeof(EstadoDispensador))]
        public IHttpActionResult PostEstadoDispensador(EstadoDispensador estadoDispensador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EstadoDispensadores.Add(estadoDispensador);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = estadoDispensador.estadoDispensadorId }, estadoDispensador);
        }

        // DELETE: api/EstadoDispensadores/5
        [ResponseType(typeof(EstadoDispensador))]
        public IHttpActionResult DeleteEstadoDispensador(int id)
        {
            EstadoDispensador estadoDispensador = db.EstadoDispensadores.Find(id);
            if (estadoDispensador == null)
            {
                return NotFound();
            }

            db.EstadoDispensadores.Remove(estadoDispensador);
            db.SaveChanges();

            return Ok(estadoDispensador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstadoDispensadorExists(int id)
        {
            return db.EstadoDispensadores.Count(e => e.estadoDispensadorId == id) > 0;
        }
    }
}