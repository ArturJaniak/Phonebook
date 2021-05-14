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
using PhonebookTheOneApi.Models;

namespace PhonebookTheOneApi.Controllers
{
    public class OfficesController : ApiController
    {
        private Phonebook2Entities db = new Phonebook2Entities();

        // GET: api/Offices
        public IQueryable<Office> GetOffices()
        {
            return db.Offices;
        }

        // GET: api/Offices/5
        [ResponseType(typeof(Office))]
        public IHttpActionResult GetOffice(int id)
        {
            Office office = db.Offices.Find(id);
            if (office == null)
            {
                return NotFound();
            }

            return Ok(office);
        }

        // PUT: api/Offices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOffice(int id, Office office)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != office.OfficeID)
            {
                return BadRequest();
            }

            db.Entry(office).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeExists(id))
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

        // POST: api/Offices
        [ResponseType(typeof(Office))]
        public IHttpActionResult PostOffice(Office office)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Offices.Add(office);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = office.OfficeID }, office);
        }

        // DELETE: api/Offices/5
        [ResponseType(typeof(Office))]
        public IHttpActionResult DeleteOffice(int id)
        {
            Office office = db.Offices.Find(id);
            if (office == null)
            {
                return NotFound();
            }

            db.Offices.Remove(office);
            db.SaveChanges();

            return Ok(office);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OfficeExists(int id)
        {
            return db.Offices.Count(e => e.OfficeID == id) > 0;
        }
    }
}