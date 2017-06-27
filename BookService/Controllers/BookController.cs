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
using BookService.Models;

namespace BookService.Controllers
{
    public class BookController : ApiController
    {

        private acesmisEntities1 db = new acesmisEntities1();

        // GET: api/Book
        public IQueryable<aspnet_Users> Getaspnet_Users()
        {
            return db.aspnet_Users;
        }

        // GET: api/Book/5
        [ResponseType(typeof(aspnet_Users))]
        public IHttpActionResult Getaspnet_Users(Guid id)
        {
            aspnet_Users aspnet_Users = db.aspnet_Users.Find(id);
            if (aspnet_Users == null)
            {
                return NotFound();
            }

            return Ok(aspnet_Users);
        }

        // PUT: api/Book/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putaspnet_Users(Guid id, aspnet_Users aspnet_Users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aspnet_Users.UserId)
            {
                return BadRequest();
            }

            db.Entry(aspnet_Users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!aspnet_UsersExists(id))
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

        // POST: api/Book
        [ResponseType(typeof(aspnet_Users))]
        public IHttpActionResult Postaspnet_Users(aspnet_Users aspnet_Users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.aspnet_Users.Add(aspnet_Users);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (aspnet_UsersExists(aspnet_Users.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aspnet_Users.UserId }, aspnet_Users);
        }

        // DELETE: api/Book/5
        [ResponseType(typeof(aspnet_Users))]
        public IHttpActionResult Deleteaspnet_Users(Guid id)
        {
            aspnet_Users aspnet_Users = db.aspnet_Users.Find(id);
            if (aspnet_Users == null)
            {
                return NotFound();
            }

            db.aspnet_Users.Remove(aspnet_Users);
            db.SaveChanges();

            return Ok(aspnet_Users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool aspnet_UsersExists(Guid id)
        {
            return db.aspnet_Users.Count(e => e.UserId == id) > 0;
        }
    }
}