using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Factories.Note;
using Microsoft.AspNetCore.Mvc;
using Models.Note;
using Microsoft.AspNetCore.Http;

namespace ajaxnotes.Controllers
{
    public class HomeController : Controller
    {
        private readonly AjaxNoteFactory _ajaxNoteFactory;

        public HomeController(){
            _ajaxNoteFactory = new AjaxNoteFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {   
            ViewBag.Errors = new List<string>();
            if (HttpContext.Session.GetObjectFromJson<object>("ModelState") != null){
                   ViewBag.Errors = HttpContext.Session.GetObjectFromJson<object>("ModelState");
                   HttpContext.Session.Remove("ModelState");
            }

            IEnumerable<AjaxNote> items = _ajaxNoteFactory.FindAll();
            ViewBag.Notes = items;
            return View();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddNote(AjaxNote item)
        {  
            if(ModelState.IsValid){
              _ajaxNoteFactory.Add(item);  
            }
            else{
                HttpContext.Session.SetObjectAsJson("ModelState", ModelState.Values) ;   
            }         
            return  RedirectToAction("Index");
            
        }

        [HttpPost]
        [Route("update")]
        public JsonResult update(AjaxNote item)
        {  
            if(ModelState.IsValid){
              _ajaxNoteFactory.UpdateQuote(item);
              return  Json(new {success=true});

            }                       
            return  Json(new {success=false});
            
        }

        [HttpPost]
        [Route("remove/{noteId}")]
        public ActionResult remove(int noteId)
        {  
              _ajaxNoteFactory.DeleteQuote( noteId);
              return  RedirectToAction("Index");

                                  
        }
    }
}
