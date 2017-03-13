using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace YourNamespace.Controllers
{
    public class HelloController : Controller
    {
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
            object  helloObj = new { Messsage="Hello World",
                                     FirstName = "Raz",
                                     LastName = "Aquato",
                                     Age = 10};
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
    }
}