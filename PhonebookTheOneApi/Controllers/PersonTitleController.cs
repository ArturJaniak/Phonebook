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
    public class PersonTitleController : ApiController
    {
        private Phonebook2Entities db = new Phonebook2Entities();

        // GET: api/PersonTitle
        public IQueryable<PersonTitle> GetPersonTitles()
        {
            return db.PersonTitles;
        }

        // GET: api/PersonTitle/5
        [ResponseType(typeof(PersonTitle))]
        public IHttpActionResult GetPersonTitle(int id)
        {
            PersonTitle personTitle = db.PersonTitles.Find(id);
            if (personTitle == null)
            {
                return NotFound();
            }

            return Ok(personTitle);
        }

        // PUT: api/PersonTitle/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonTitle(int id, PersonTitle personTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personTitle.PersonTitleID)
            {
                return BadRequest();
            }

            db.Entry(personTitle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonTitleExists(id))
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

        // POST: api/PersonTitle
        [ResponseType(typeof(PersonTitle))]
        public IHttpActionResult PostPersonTitle(PersonTitle personTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonTitles.Add(personTitle);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personTitle.PersonTitleID }, personTitle);
        }

        // DELETE: api/PersonTitle/5
        [ResponseType(typeof(PersonTitle))]
        public IHttpActionResult DeletePersonTitle(int id)
        {
            PersonTitle personTitle = db.PersonTitles.Find(id);
            if (personTitle == null)
            {
                return NotFound();
            }

            db.PersonTitles.Remove(personTitle);
            db.SaveChanges();

            return Ok(personTitle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonTitleExists(int id)
        {
            return db.PersonTitles.Count(e => e.PersonTitleID == id) > 0;
        }
    }
}