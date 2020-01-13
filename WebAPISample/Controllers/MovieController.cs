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
            var movies = db.Movies;   // Retrieve all movies from db logic
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
        public void Post([FromBody]Movie value)
        {
            Movie movie = new Movie();
            movie.Title = value.Title;
            movie.Genre = value.Title;
            movie.Director = value.Director;
            db.SaveChanges();
            
            // Create movie in db logic
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            // Update movie in db logic
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Movie movie = db.Movies.Find(id);

            // Delete movie from db logic
        }
    }

}