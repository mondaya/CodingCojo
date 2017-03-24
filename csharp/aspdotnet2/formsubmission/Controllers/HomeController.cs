using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Formsubmission.Models;

namespace formsubmission.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            return View();
        }

        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            return View();
        }


        [HttpPost]
        [Route("")]
        public IActionResult Submission(FormSubmission form)
        {   
            if(ModelState.IsValid){
                return RedirectToAction("Success");
            }

            ViewBag.errors =  ModelState.Values;
            
            return  View("Index");
           
        }
    }
}
