using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourNamespace.BackEndApi;
using System;
using DbConnection;

namespace YourNamespace.Controllers
{
    public class HelloController : Controller
    {

        private readonly DbConnector _dbConnector;
 
        public HelloController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        [HttpGet]
        [Route("")]
        public string Index()
        {
            return "Hello World!";
        }

        [HttpGet]
        [Route("json")]
        public JsonResult Example()
        {
            // The Json method convert the object passed to it into JSON
            object helloObj = new
            {
                Messsage = "Hello World",
                FirstName = "Raz",
                LastName = "Aquato",
                Age = 10
            };
            return Json(helloObj);
        }

        [HttpGet]
        [Route("home")]
        public IActionResult Index_()
        {
            return View();
            //OR
            //return View("Index");
            //Both of these returns will render the same view (You only need one!)
        }

        [HttpGet]
        [Route("json/redirect")]
        public IActionResult IndexRedirect()
        {
            return RedirectToAction("Example");
            //OR
            //return View("Index");
            //Both of these returns will render the same view (You only need one!)
        }

        //Other code
        [HttpGet]
        [Route("other")]
        public IActionResult Method()
        {
            // The anonymous object consists of keys and values
            // The keys should match the parameter names of the method being redirected to
            return RedirectToAction("OtherMethod", new { Food = "sandwiches", Quantity = 5 });
        }

        [HttpGet]
        [Route("other/{Food}")]
        public string OtherMethod(string Food, int Quantity)
        {
            return $"I ate {Quantity} {Food}.";
            // Writes "I ate 5 sandwiches."
        }

        /*// Other code
        public class FirstController : Controller
        {
            public IActionResult Method()
            {
                return RedirectToAction("OtherMethod", "Second");
            }
        }
        
        // In another file
        public class SecondController : Controller
        {
            public IActionResult OtherMethod()
            {
                return View();
            }
        } */

        [HttpGet]
        [Route("session")]
        public JsonResult session()
        {
            HttpContext.Session.SetString("UserName", "Samantha");
            // To retrieve a string from session we use ".GetString"
            string LocalVariable = HttpContext.Session.GetString("UserName");

            // To store an int in session we use ".SetInt32"
            HttpContext.Session.SetInt32("UserAge", 28);

            // To retrieve an int from session we use ".GetInt32"
            int? IntVariable = HttpContext.Session.GetInt32("UserAge");
            object obj = new
            {
                Messsage = "Hello World",
                Name = LocalVariable,
                Age = IntVariable
            };
            return Json(obj);

        }


        [HttpGet]
        [Route("tempdata")]
        // Other code
        public IActionResult TempMethod()
        {
            TempData["Variable"] = "Hello World";
            return RedirectToAction("TempOtherMethod");
        }
        [HttpGet]
        [Route("tempdata/response")]
        public string TempOtherMethod()
        {
            return TempData["Variable"] as string;
            // writes "Hello World" if redirected to from Method()
        }

        [HttpGet]
        [Route("pokemon/{pokeid}")]
        public IActionResult QueryPoke(int pokeid)
        {
            var PokeInfo = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(pokeid, ApiResponse =>
                {
                    PokeInfo = ApiResponse;
                }
            ).Wait();
            // Other code
            Console.WriteLine(PokeInfo);
            return RedirectToAction("Example");

        }

        [HttpGet]
        [Route("sql")]
        public List<Dictionary<string, object>>  Sql()
        {
            List<Dictionary<string, object>> AllUsers = _dbConnector.Query("SELECT * FROM users");
            // Other code
            return AllUsers;
        }
    }
}