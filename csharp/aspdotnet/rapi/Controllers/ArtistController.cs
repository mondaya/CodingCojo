using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {

    
    public class ArtistController : Controller {

        private List<Artist> allArtists;

        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }

        [Route("artists")]
        [HttpGet]
        public JsonResult Artists() {
            var artists = from match in allArtists
                          select match;
            return Json(artists);
        }

        [Route("artists/name/{Name}")]
        [HttpGet]
        public JsonResult ArtistsWithName(string Name) {
            var artists = from match in allArtists
                          where match.ArtistName == Name
                          select match;
            return Json(artists);
        }

        [Route("artists/realname/{Name}")]
        [HttpGet]
        public JsonResult ArtistsWithRaelName(string Name) {
            var artists = from match in allArtists
                          where match.RealName == Name
                          select match;
            return Json(artists);
        }

        [Route("artists/hometown/{Town}")]
        [HttpGet]
        public JsonResult ArtistsWithHomeTown(string Town) {
            var artists = from match in allArtists
                          where match.Hometown == Town
                          select match;
            return Json(artists);
        }

        [Route("artists/groupid/{id}")]
        [HttpGet]
        public JsonResult ArtistsWithGroupId(uint id) {
            var artists = from match in allArtists
                          where match.GroupId == id
                          select match;
            return Json(artists);
        }
    }
}