using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userdashboard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace userdashboard.Controllers {
    public class MessageController : Controller {
        private UserContext _context;
 
        public MessageController(UserContext context) {
            _context = context;
        }
 
        [HttpGet]
        [Route("dash")]
        public IActionResult Dash(){
            ViewBag.errors = "";
            User userObject = _context.Users.Where(usr => usr.UserID == 1)
                .Include(msgs => msgs.ReceivedMessages).SingleOrDefault();
            List<Message> messageObject = _context.Messages.Where(msg => msg.MessageRecieverID == 1)
                .Include(usr => usr.MessageSender)
                .OrderByDescending(msg => msg.CreatedAt)
                .ToList();
            ViewBag.userObject = userObject;
            ViewBag.messageObject = messageObject;
            return View();
        }
    }
}
