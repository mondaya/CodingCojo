using Microsoft.AspNetCore.Mvc;
 
namespace TimeDisplayDemo
{
    public class TimeDisplayController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}