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
    public class LanguagePersonsController : ApiController
    {
        private Phonebook2Entities db = new Phonebook2Entities();

        // GET: api/LanguagePersons
        public IQueryable<LanguagePerson> GetLanguagePersons()
        {
            return db.LanguagePersons;
        }

        // GET: api/LanguagePersons/5
        [ResponseType(typeof(LanguagePerson))]
        public IHttpActionResult GetLanguagePerson(int id)
        {
            LanguagePerson languagePerson = db.LanguagePersons.Find(id);
            if (languagePerson == null)
            {
                return NotFound();
            }

            return Ok(languagePerson);
        }

        // PUT: api/LanguagePersons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLanguagePerson(int id, LanguagePerson languagePerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != languagePerson.LanguagePersonID)
            {
                return BadRequest();
            }

            db.Entry(languagePerson).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguagePersonExists(id))
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

        // POST: api/LanguagePersons
        [ResponseType(typeof(LanguagePerson))]
        public IHttpActionResult PostLanguagePerson(LanguagePerson languagePerson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LanguagePersons.Add(languagePerson);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = languagePerson.LanguagePersonID }, languagePerson);
        }

        // DELETE: api/LanguagePersons/5
        [ResponseType(typeof(LanguagePerson))]
        public IHttpActionResult DeleteLanguagePerson(int id)
        {
            LanguagePerson languagePerson = db.LanguagePersons.Find(id);
            if (languagePerson == null)
            {
                return NotFound();
            }

            db.LanguagePersons.Remove(languagePerson);
            db.SaveChanges();

            return Ok(languagePerson);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LanguagePersonExists(int id)
        {
            return db.LanguagePersons.Count(e => e.LanguagePersonID == id) > 0;
        }
    }
}