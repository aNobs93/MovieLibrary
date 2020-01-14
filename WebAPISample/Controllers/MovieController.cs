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
            try
            {
                var movie = db.Movies.Find(id);
                if(movie != null)
                {
                    return Ok(movie);
                }
            }
            catch
            {
                return BadRequest("Invalid Id");
            }
            return BadRequest("Invalid Id");
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
            try
            {
                Movie updatedMovie = db.Movies.Where(u => u.MovieId == id).FirstOrDefault();
                if(updatedMovie != null)
                {
                    updatedMovie.Title = movie.Title;
                    updatedMovie.Genre = movie.Genre;
                    updatedMovie.Director = movie.Director;
                    db.SaveChanges();
                }

            }
            catch
            {
                 BadRequest("Invalid Id");
            }

            // Update movie in db logic
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                Movie movie = db.Movies.Find(id);
                db.Movies.Remove(movie);
                db.SaveChanges();

            }
            catch
            {
                 BadRequest("No Movie With That Id");
            }
            // Delete movie from db logic
        }
    }

}