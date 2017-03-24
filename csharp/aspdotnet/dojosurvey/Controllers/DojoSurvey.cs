using Microsoft.AspNetCore.Mvc;
 
namespace DojoSurveyDemo
{
    public class DojoSurvey : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("result")]
        public IActionResult Result(string user_name, string dojo_location, string fav_lang, string comment )
        {   
            ViewBag.user_name =  user_name;
            ViewBag.dojo_location = dojo_location;
            ViewBag.fav_lang = fav_lang;
            ViewBag.comment = comment;

            return View();
        }

    }
}