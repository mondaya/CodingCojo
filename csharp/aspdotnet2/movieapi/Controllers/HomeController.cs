using System.Collections.Generic;
using Factories.Note;
using Microsoft.AspNetCore.Mvc;
using Models.Movie;

namespace movieapi.Controllers
{
    
    
    public class HomeController : Controller
    {
        
        private readonly MovieDBFactory _movieDBFactory;

        public HomeController(MovieDBFactory movieDBFactory)
        {
            _movieDBFactory = movieDBFactory;
        }
        
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("movies")]
        public JsonResult AllNotes()
        {
            List<MovieDB> AllNotes = _movieDBFactory.FindAll();
            return Json(AllNotes);
        }
        



        [HttpGet]
        [Route("movie/{term}")]
        public JsonResult GetInfo(string term)
        {
            var MovieObject = new MovieDB();

            WebRequest.GetMovieDataAsync(term, MovieResponse => {
                MovieObject = MovieResponse;
            }).Wait();
            
            return CreateMovie(MovieObject);
        }

        [HttpGet]
        [Route("movie/new")]
        public JsonResult CreateMovie(MovieDB model)
        {
           if(model!=null){
               if (ModelState.IsValid){
                    _movieDBFactory.Add(model);
                    MovieDB newMovie = _movieDBFactory.GetLatest();
                    return Json(newMovie);
               }
            }
        
        return Json(new {Failed = "true"});
        }

    }
}
