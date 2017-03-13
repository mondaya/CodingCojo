using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace YourNamespace.Controllers
{
    public class CallingCardController : Controller
    {
        [HttpGet]
        [Route("card/{FirstName}/{LastName}/{Age}/{FavoriteColor}")]
        public JsonResult Card(string FirstName, string LastName, uint Age, string FavoriteColor)
        {
            // The Json method convert the object passed to it into JSON
        var  card = new {FirstName = FirstName,
                                    LastName = LastName,
                                     Age = Age,
                                     FavoriteColor = FavoriteColor
                                     };
            return Json(card);
        }
    }
}