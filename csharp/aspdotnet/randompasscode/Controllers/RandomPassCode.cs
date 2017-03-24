using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

 
namespace RandomPassCodeDemo
{
    public class RandomPassCode : Controller
    {
        private int count;
        
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {  
            if (HttpContext.Session.GetInt32("count") == null){

                 HttpContext.Session.SetInt32("count", 0);               
                 Generate();               
            }           
            ViewBag.passCode = HttpContext.Session.GetString("passCode");
            ViewBag.count =  HttpContext.Session.GetInt32("count");
           
            return View();
        }

       /* [HttpGet]
        [Route("generate")]
        public IActionResult Generate()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[14];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            TempData["passCode"] = finalString;
            int? count = HttpContext.Session.GetInt32("count");
            count++;
            HttpContext.Session.SetInt32("count", (int)count);
            HttpContext.Session.SetString("passCode", finalString);
            return RedirectToAction("Index");
        }  */


        [HttpGet]
        [Route("generate")]
        public JsonResult Generate()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[14];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            TempData["passCode"] = finalString;
            int? count = HttpContext.Session.GetInt32("count");
            count++;
            HttpContext.Session.SetInt32("count", (int)count);
            HttpContext.Session.SetString("passCode", finalString);
            return Json(new {count = HttpContext.Session.GetInt32("count"),  passCode = HttpContext.Session.GetString("passCode") });
        }  

    }
}