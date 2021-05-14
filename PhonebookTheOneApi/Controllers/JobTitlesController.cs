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
    public class JobTitlesController : ApiController
    {
        private Phonebook2Entities db = new Phonebook2Entities();

        // GET: api/JobTitles
        public IQueryable<JobTitle> GetJobTitles()
        {
            return db.JobTitles;
        }

        // GET: api/JobTitles/5
        [ResponseType(typeof(JobTitle))]
        public IHttpActionResult GetJobTitle(int id)
        {
            JobTitle jobTitle = db.JobTitles.Find(id);
            if (jobTitle == null)
            {
                return NotFound();
            }

            return Ok(jobTitle);
        }

        // PUT: api/JobTitles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJobTitle(int id, JobTitle jobTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobTitle.JobTitleID)
            {
                return BadRequest();
            }

            db.Entry(jobTitle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTitleExists(id))
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

        // POST: api/JobTitles
        [ResponseType(typeof(JobTitle))]
        public IHttpActionResult PostJobTitle(JobTitle jobTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JobTitles.Add(jobTitle);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jobTitle.JobTitleID }, jobTitle);
        }

        // DELETE: api/JobTitles/5
        [ResponseType(typeof(JobTitle))]
        public IHttpActionResult DeleteJobTitle(int id)
        {
            JobTitle jobTitle = db.JobTitles.Find(id);
            if (jobTitle == null)
            {
                return NotFound();
            }

            db.JobTitles.Remove(jobTitle);
            db.SaveChanges();

            return Ok(jobTitle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobTitleExists(int id)
        {
            return db.JobTitles.Count(e => e.JobTitleID == id) > 0;
        }
    }
}