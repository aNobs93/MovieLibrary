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
            //List<Movie> movies = new List<Movie>();
            //foreach(var movie in db.Movies)
            //{
            //    movies.Add(movie);
            //}
            //  // Retrieve all movies from db logic
            //return Ok(movies);
        }

        // GET api/values/5
        //[HttpGet]
        public IHttpActionResult Get(int id)
        {
            var movie = db.Movies.Find(id);
            // Retrieve movie by id from db logic
            return Ok(movie);
        }

        // POST api/values
        public void Post([FromBody]Movie value)
        {

            db.Movies.Add(value);
            db.SaveChanges();
            
            // Create movie in db logic
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Movie value)
        {
            Movie updatedMovie = db.Movies.Where(u => u.MovieId == id).FirstOrDefault();
            updatedMovie.Title = value.Title;
            updatedMovie.Genre = value.Genre;
            updatedMovie.Director = value.Director;
            db.SaveChanges();

            // Update movie in db logic
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();

            // Delete movie from db logic
        }
    }

}