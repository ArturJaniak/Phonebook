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
    public class FloorRoomsController : ApiController
    {
        private Phonebook2Entities db = new Phonebook2Entities();

        // GET: api/FloorRooms
        public IQueryable<FloorRoom> GetFloorRooms()
        {
            return db.FloorRooms;
        }

        // GET: api/FloorRooms/5
        [ResponseType(typeof(FloorRoom))]
        public IHttpActionResult GetFloorRoom(int id)
        {
            FloorRoom floorRoom = db.FloorRooms.Find(id);
            if (floorRoom == null)
            {
                return NotFound();
            }

            return Ok(floorRoom);
        }

        // PUT: api/FloorRooms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFloorRoom(int id, FloorRoom floorRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != floorRoom.FloorRoomID)
            {
                return BadRequest();
            }

            db.Entry(floorRoom).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FloorRoomExists(id))
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

        // POST: api/FloorRooms
        [ResponseType(typeof(FloorRoom))]
        public IHttpActionResult PostFloorRoom(FloorRoom floorRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FloorRooms.Add(floorRoom);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = floorRoom.FloorRoomID }, floorRoom);
        }

        // DELETE: api/FloorRooms/5
        [ResponseType(typeof(FloorRoom))]
        public IHttpActionResult DeleteFloorRoom(int id)
        {
            FloorRoom floorRoom = db.FloorRooms.Find(id);
            if (floorRoom == null)
            {
                return NotFound();
            }

            db.FloorRooms.Remove(floorRoom);
            db.SaveChanges();

            return Ok(floorRoom);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FloorRoomExists(int id)
        {
            return db.FloorRooms.Count(e => e.FloorRoomID == id) > 0;
        }
    }
}