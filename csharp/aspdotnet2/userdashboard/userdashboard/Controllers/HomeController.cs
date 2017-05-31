using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userdashboard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace userdashboard.Controllers {
    public class HomeController : Controller {
        private UserContext _context;
 
        public HomeController(UserContext context) {
            _context = context;
        }
 
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            ViewBag.errors = "";
            return View();
        }

        [HttpPost]
        [RouteAttribute("register")]
        public IActionResult Register(RegisterViewModel newUser) {
            if (ModelState.IsValid) {
                User usr = _context.Users.Where(person => person.Email == newUser.Email).SingleOrDefault();
                if (usr != null) {
                    ViewBag.reg_error = "Email already exists in our database, please choose a new one.";
                    return View("Index");
                } else {
                    User addUser = new User {
                        FirstName = newUser.FirstName,
                        LastName = newUser.LastName,
                        Email = newUser.Email,
                        Password = newUser.Password
                    };
                    _context.Add(addUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("curUser", newUser.UserID);
                    // This is the success route
                    return RedirectToAction("Dash", "Message");
                }
            } else {
                ViewBag.errors = ModelState.Values;
                return View("Index");
            }    
        }
        
        [HttpPost]
        [RouteAttribute("login")]
        public IActionResult Login(string Email, string Password) {
            User usr = _context.Users.Where(person => person.Email == Email).SingleOrDefault();
            if ((usr != null) && (Password != null)) {
                if ((string)usr.Password == Password) {
                    HttpContext.Session.SetInt32("curUser", usr.UserID);
                    // This is the success route
                    return RedirectToAction("Dash", "Message");
                }
            }
            ViewBag.login_error = "Invalid information provided.";
            return View("Index");
        }

        [HttpGet]
        [RouteAttribute("logout")]
        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }        
    }
}
