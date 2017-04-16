using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using NetworkProfessional.Models;
using System;

namespace NetworkProfessional.Controllers
{
    public class NetworkProfessionalController : Controller
    {

        private NetworkProfessionalContext _context;

        public NetworkProfessionalController(NetworkProfessionalContext context)
        {
            _context = context;
        }

        // GET: /Home/       
        [HttpGet]
        [Route("users")]
        public IActionResult DashBoard()
        {
            int? userLoginId = HttpContext.Session.GetInt32("userId");
            if (userLoginId != null)
            {
                ViewBag.UserName = HttpContext.Session.GetString("userName");

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            List<Connection> PeopleInUserNetwork = _context.GetAllMyConnections((int)userLoginId);
            List<Connection> NotInNetwork =
            _context.Professionals
               .GroupJoin(PeopleInUserNetwork,
                       User => User.id,
                       connection => connection.Follower.id,
                       (User, Connections) => new Connection{
                            ConnectionId = Connections.Count() >= 1 ? Connections.First().ConnectionId : 0,
                            Follower = User, 
                            FollowerInvited = Connections.Count() >= 1 ? Connections.First().FollowerInvited : false,
                            Followed = Connections.Count() >= 1 ? Connections.First().Follower : null, 
                            AcceptedInvite = Connections.Count() >= 1 ? Connections.First().AcceptedInvite : false,
                            IgnoredInvite = Connections.Count() >= 1 ? Connections.First().IgnoredInvite : false}
               )
               .Where(connection => ((connection.Followed != null &&  connection.IgnoredInvite) || connection.Followed == null )
                && connection.Follower.id != (int)userLoginId)
               .Select(connection => connection).ToList();

            Console.WriteLine(_context.Professionals.Count());
            Console.WriteLine(NotInNetwork.Count());
            return View(NotInNetwork);
        }

        [HttpGet]
        [Route("professional_profile")]
        public IActionResult Profile()
        {
            int? userLoginId = HttpContext.Session.GetInt32("userId");
            if (userLoginId != null)
            {
                ViewBag.UserName = HttpContext.Session.GetString("userName");
                
                List<Connection> UserNetwork = _context.GetAllMyConnections((int)userLoginId);

                Console.WriteLine(UserNetwork.Count());
              
                return View(UserNetwork);
               
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPostAttribute]
        [RouteAttribute("connect/{FollowerId}")]
        public JsonResult Connect(int FollowerId){
           int? userLoginId = HttpContext.Session.GetInt32("userId");
            if (userLoginId != null){
                Network connection = new Network();
                connection.FollowerId = FollowerId;
                connection.UserFollowedId = (int)userLoginId;
                _context.Networks.Add(connection);
                _context.SaveChanges();
                return Json(new {success = true});
            }
            return Json(new {Error = true});  
        }

        [HttpPostAttribute]
        [RouteAttribute("accept/{InventId}")]
        public IActionResult Accept(int InventId){
           int? userLoginId = HttpContext.Session.GetInt32("userId");
            if (userLoginId != null){
                Network connection = _context.Networks.Single(n=>n.id == InventId);
                connection.AcceptedInvite = true;
                 connection.IgnoredInvite = false;
                _context.SaveChanges();
                return RedirectToAction("Profile");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPostAttribute]
        [RouteAttribute("decline/{InventId}")]
        public IActionResult Decline(int InventId){
           int? userLoginId = HttpContext.Session.GetInt32("userId");
            if (userLoginId != null){
                Network connection = _context.Networks.Single(n=>n.id == InventId);
                connection.IgnoredInvite = true;
                 connection.AcceptedInvite = false;
                _context.SaveChanges();
                return RedirectToAction("Profile");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
