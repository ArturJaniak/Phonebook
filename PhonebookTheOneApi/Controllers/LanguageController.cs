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
    public class LanguageController : ApiController
    {
        private Phonebook2Entities db = new Phonebook2Entities();
        [ResponseType(typeof(IEnumerable<Language>))]
        [Route("api/Language")]
        // GET: api/Language
        public IQueryable<Language> GetLanguages()
        {
            return db.Languages;
        }

        // GET: api/Language/5
        [ResponseType(typeof(Language))]
        public IHttpActionResult GetLanguage(int id)
        {
            Language language = db.Languages.Find(id);
            if (language == null)
            {
                return NotFound();
            }

            return Ok(language);
        }

        // PUT: api/Language/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLanguage(int id, Language language)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != language.LanguageID)
            {
                return BadRequest();
            }

            db.Entry(language).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageExists(id))
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

        // POST: api/Language
        [ResponseType(typeof(Language))]
        public IHttpActionResult PostLanguage(Language language)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Languages.Add(language);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = language.LanguageID }, language);
        }

        // DELETE: api/Language/5
        [ResponseType(typeof(Language))]
        public IHttpActionResult DeleteLanguage(int id)
        {
            Language language = db.Languages.Find(id);
            if (language == null)
            {
                return NotFound();
            }

            db.Languages.Remove(language);
            db.SaveChanges();

            return Ok(language);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LanguageExists(int id)
        {
            return db.Languages.Count(e => e.LanguageID == id) > 0;
        }
    }
}