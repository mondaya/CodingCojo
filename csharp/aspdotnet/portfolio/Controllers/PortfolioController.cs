using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace PortfolioDemo
{
    public class PortfolioController : Controller
    {
        [HttpGet]
        [Route("home")]
       public IActionResult Index()
        {
            return View();           
        }

        [HttpGet]
        [Route("projects")]
       public IActionResult Projects()
        {
            return View();            
        }

        [HttpGet]
        [Route("contact")]
        public IActionResult Contact()
        {
            return View();           
        }
    }
}