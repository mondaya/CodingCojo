using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resturanter.Models;

namespace RESTuaranter.Controllers
{

    public class HomeController : Controller
    {

        private ResturanterContext  _context;
    
        public HomeController(ResturanterContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
            // Other code
        }
        
        [HttpPost]        
        [Route("review")]      
        public IActionResult Review(Review review)
        {
             if(ModelState.IsValid) {                       
                _context.Add(review);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }           
          
            return View("Index");
        }

         // GET: /Home/
        [HttpGet]
        [Route("reviews")]
        public IActionResult Reviews()
        {   
            List<Review> AllReviews = _context.Reviews.ToList();
         
            return View(AllReviews);
        }


 
        // GET: /Home/
        [HttpGet]
        [Route("json")]
        public JsonResult Read()
        {   
            List<Person> AllUsers = _context.Users.ToList();
            return Json(AllUsers);
        }

         // GET: /Home/
        [HttpPost]
        [Route("json")]
        public JsonResult Create(Person person)        {
           
            if(ModelState.IsValid) {       
                _context.Add(person);
                _context.SaveChanges();
                return Json(new {success=true});
            }
            // OR _context.Users.Add(NewPerson);
          
            return Json(new {success=false});
        }

        [HttpPost]
        [Route("json/update/{Id}")]
        public JsonResult Update(int Id, Person person)        {
           
                 
            Person r_user = _context.Users.SingleOrDefault(user=>user.PersonId == Id);
            r_user.Age = person.Age;
            _context.SaveChanges();
            return Json(new {success=true});
            
           
        }

         [HttpPost]
        [Route("json/remove/{Id}")]
        public JsonResult Remove(int Id, Person person)        {
           
                 
            Person r_user = _context.Users.SingleOrDefault(user=>user.PersonId == Id);
            _context.Users.Remove(r_user);           
            _context.SaveChanges();
            return Json(new {success=true});
            
           
        }
    }
}
