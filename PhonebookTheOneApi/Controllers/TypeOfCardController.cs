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
    public class TypeOfCardController : ApiController
    {
        private Phonebook2Entities db = new Phonebook2Entities();

        // GET: api/TypeOfCard
        public IQueryable<TypeOfCard> GetTypeOfCards()
        {
            return db.TypeOfCards;
        }

        // GET: api/TypeOfCard/5
        [ResponseType(typeof(TypeOfCard))]
        public IHttpActionResult GetTypeOfCard(int id)
        {
            TypeOfCard typeOfCard = db.TypeOfCards.Find(id);
            if (typeOfCard == null)
            {
                return NotFound();
            }

            return Ok(typeOfCard);
        }

        // PUT: api/TypeOfCard/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypeOfCard(int id, TypeOfCard typeOfCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeOfCard.TypeOfCardID)
            {
                return BadRequest();
            }

            db.Entry(typeOfCard).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeOfCardExists(id))
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

        // POST: api/TypeOfCard
        [ResponseType(typeof(TypeOfCard))]
        public IHttpActionResult PostTypeOfCard(TypeOfCard typeOfCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeOfCards.Add(typeOfCard);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = typeOfCard.TypeOfCardID }, typeOfCard);
        }

        // DELETE: api/TypeOfCard/5
        [ResponseType(typeof(TypeOfCard))]
        public IHttpActionResult DeleteTypeOfCard(int id)
        {
            TypeOfCard typeOfCard = db.TypeOfCards.Find(id);
            if (typeOfCard == null)
            {
                return NotFound();
            }

            db.TypeOfCards.Remove(typeOfCard);
            db.SaveChanges();

            return Ok(typeOfCard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeOfCardExists(int id)
        {
            return db.TypeOfCards.Count(e => e.TypeOfCardID == id) > 0;
        }
    }
}