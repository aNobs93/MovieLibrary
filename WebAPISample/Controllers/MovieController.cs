using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    public class MovieController : ApiController
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET api/values
        [HttpGet]
        public IHttpActionResult Get()
        {
            var movies = db.Movies.ToList();
            return Ok(movies);
        }

        // GET api/values/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var movie = db.Movies.Find(id);
            // Retrieve movie by id from db logic
            return Ok(movie);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Movie value)
        {

            db.Movies.Add(value);
            db.SaveChanges();
            
            // Create movie in db logic
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int id, Movie movie)
        {
            Movie updatedMovie = db.Movies.Where(u => u.MovieId == id).FirstOrDefault();
            updatedMovie.Title = movie.Title;
            updatedMovie.Genre = movie.Genre;
            updatedMovie.Director = movie.Director;
            db.SaveChanges();

            // Update movie in db logic
        }

        // DELETE api/values/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Movie movie = db.Movies.Find(id);
                db.Movies.Remove(movie);
                db.SaveChanges();

            }
            catch
            {
                return BadRequest("No Movie With That Id");
            }
            return BadRequest("No Movie With That Id");

            // Delete movie from db logic
        }
    }

}