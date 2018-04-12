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
using VehicleDealerApp.Models;

namespace VehicleDealerApp.Controllers
{
    public class FactoriesController : ApiController
    {
        private VehicleDealerDBEntities db = new VehicleDealerDBEntities();

        /* --------------------------------------------- */
        #region LOAD
        // GET: api/Factories
        public IQueryable<Factory> GetFactories()
        {
            return db.Factories;
        }
        #endregion

        /* --------------------------------------------- */
        #region GET
        // GET: api/Factories/5
        [ResponseType(typeof(Factory))]
        public IHttpActionResult GetFactory(int id)
        {
            List<Factory> factory = (from d in db.Factories
                                     where d.FactoryId == id
                                     select d).ToList();

            return Ok(factory);
        }
        #endregion

        /* --------------------------------------------- */
        #region PUT
        // PUT: api/Factories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFactory(int id, Factory factory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != factory.FactoryId)
            {
                return BadRequest();
            }

            db.Entry(factory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactoryExists(id))
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
        #endregion

        /* --------------------------------------------- */
        #region POST
        // POST: api/Factories
        [ResponseType(typeof(Factory))]
        public IHttpActionResult PostFactory(Factory factory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Factory facto = new Factory();
            facto.FactoryName = factory.FactoryName;
            facto.FactoryLocation = factory.FactoryLocation;

            db.Factories.Add(facto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = factory.FactoryId }, factory);
        }
        #endregion

        /* --------------------------------------------- */
        #region DELETE
        // DELETE: api/Factories/5
        [ResponseType(typeof(Factory))]
        public IHttpActionResult DeleteFactory(int id)
        {
            Factory factory = db.Factories.Find(id);

            if (factory == null)
            {
                return NotFound();
            }

            db.Factories.Remove(factory);
            db.SaveChanges();

            return Ok(factory);
        }
        #endregion

        /* --------------------------------------------- */
        #region DISPOSE
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        /* --------------------------------------------- */
        #region FACTORY EXISTS
        private bool FactoryExists(int id)
        {
            return db.Factories.Count(e => e.FactoryId == id) > 0;
        }
        #endregion
    }
}