using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DbConnection;
using Model;

namespace quotingdojo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {   
           
            return View();
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            List<Dictionary<string, object>>  quotes = DbConnector.Query("SELECT *  FROM `quotes` ORDER BY `created_at` DESC");
            ViewBag.quotes = quotes;
            return View();
        }



         // GET: /Home/
        [HttpPost]
        [Route("")]
        public IActionResult Quote(Quote info)
        {
            //Console.WriteLine(info.author);
            List<string>errors = new List<string>();

            if(info.author == null){
                  errors.Add("Author is Empty");  
            }else if(info.author.Length < 2){
                errors.Add("Author is has less than 2");  
            }

            if(info.quote == null){
                    errors.Add("Quote is Empty");  
            }else if(info.quote.Length < 5){
                    errors.Add("Quote is has less than 5");  
            }
            ViewBag.errors = errors;

            if(errors.Count == 0){
                DbConnector.Execute($"INSERT INTO `consoledb`.`quotes`(`author`,`quote`,`created_at`)VALUES('{info.author}','{info.quote }',NOw())");
                return RedirectToAction("Index");
            }
            else{ 
                ViewBag.info = info == null ? new Quote() : info;           
                return View("Error");
            }
        }
    }
}
