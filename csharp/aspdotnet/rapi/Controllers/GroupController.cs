using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers
{
    public class GroupController : Controller
    {
        List<Group> allGroups { get; set; }
        private List<Artist> allArtists;
        public GroupController()
        {
            allGroups = JsonToFile<Group>.ReadJson();
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        [Route("groups")]
        [HttpGet]
        public JsonResult Groups()
        {
            var groups = from match in allGroups
                         select match;
            return Json(groups);
        }

        [Route("groups/name/{Name}")]
        [HttpGet]
        public JsonResult GroupsWithName(string Name)
        {
            var groups = from match in allGroups
                         where match.GroupName == Name
                         select match;
            return Json(groups);
        }

        [Route("groups/id/{id}/{ListArtists:bool?}")]
        [HttpGet]
        public JsonResult GroupsWithId(int id, bool ListArtists = false)
        {

            if (!ListArtists)
            {
                var groups = from match in allGroups
                             where match.Id == id
                             select match;
                return Json(groups);
            }
            else
            {
                var groups = from grp in allGroups
                             join  artists in allArtists on grp.Id equals artists.GroupId  into co
                             where grp.Id == id
                             select new { grp.Id, grp.GroupName,artists=co };
                return Json(groups);
            }

        }


    }
}