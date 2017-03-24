using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DapperApp.Factory;
using LoginReg.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginReg.Controllers
{
    public class LoginRegController : Controller
    {

        private readonly UserFactory userFactory;
        public LoginRegController()
        {
            //Instantiate a UserFactory object that is immutable (READONLY)
            //This establishes the initial DB connection for us.
            userFactory = new UserFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        [Route("register")]
        public IActionResult Index(User user)
        {
            if(ModelState.IsValid){
                userFactory.Add(user);
                return RedirectToAction("Success");
            }

            return View(user);

        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(User user)
        {
            if((user.Email != null && user.Email.Length > 0 ) && (user.Password !=null && user.Password.Length > 0) ){
                User loginUser = userFactory.FindByEmail(user.Email);                
                if(loginUser != null && loginUser.Password == user.Password)
                    return RedirectToAction("Success");              
            }
            
            return View("Index");

        }
       
        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
           return View();
        }
    }
}
