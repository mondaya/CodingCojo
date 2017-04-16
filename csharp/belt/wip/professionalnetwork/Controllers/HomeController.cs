using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
using NetworkProfessional.Models;

namespace NetworkProfessional.Controllers
{
    public class HomeController : Controller
    {

        private NetworkProfessionalContext _context;

        public HomeController(NetworkProfessionalContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("main")]
        public IActionResult Index()
        {
            ViewBag.LoginView = new LoginViewModel();
            ViewBag.Login = null;
            return View("Index");
        }
               
        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel userForm)
        {

            if (ModelState.IsValid)
            {

                Professional userDb = _context.Professionals.SingleOrDefault(newUser => newUser.Email == userForm.Email);
                if(userDb == null){

                    Professional user = new Professional
                    {
                        FirstName = userForm.FirstName,
                        LastName = userForm.LastName,
                        Email = userForm.Email,
                        Password = userForm.Password
                    };
                    //TODO more chaecks need before saving user                   
                    _context.Add(user);
                    _context.SaveChanges();
                    userDb = _context.Professionals.SingleOrDefault(newUser => newUser.Email == userForm.Email);
                    HttpContext.Session.SetInt32("userId", userDb.id);
                    HttpContext.Session.SetString("userName", userDb.FirstName);
                    return RedirectToAction("DashBoard", "NetworkProfessional");
                    //return RedirectToAction("Transactions", new { userId = userDb.id });
                }
                else
                {
                    ViewBag.UserExistsMsg = "user Already exists";
                }
            }
            ViewBag.Login = null;
            return View("Index");
        }


        // GET: /Home/
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginViewModel userForm)
        {

            if (ModelState.IsValid)
            {
                Professional userDb = _context.Professionals.SingleOrDefault(user => user.Email == userForm.Email);
                if (userDb != null && userDb.Password ==  userForm.Password)
                {
                    HttpContext.Session.SetInt32("userId", userDb.id);  
                    HttpContext.Session.SetString("userName", userDb.FirstName);                                    
                    return RedirectToAction("DashBoard", "NetworkProfessional");
                }
                else 
                {
                    ViewBag.InvalidUserMsg = "Unable to match user name or password";
                }
            }

            ViewBag.Errors = ModelState.Values;
            ViewBag.Login = new LoginViewModel();
            return View("Index");


        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();           
            return View("Index");


        }       


    }
}
