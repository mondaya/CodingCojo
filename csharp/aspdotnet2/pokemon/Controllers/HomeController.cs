using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PokemonBackEndApi;

namespace pokemon.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("pokemon/{pokeid}")]
        public ActionResult QueryPoke(int pokeid)
        {
            var PokeInfo = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(pokeid, ApiResponse =>
                {
                    PokeInfo = ApiResponse;
                }
            ).Wait();
            // Other code         
            List<object> types  = DeserializeJsonStr<List<object>>(PokeInfo["types"].ToString());
            Dictionary<string, object> type_0 = DeserializeJsonStr<Dictionary<string, object>>(types[0].ToString()); 
            object name = DeserializeJsonStr<Dictionary<string, object>>(type_0["type"].ToString())["name"];  
            List<string> pkmtypes = new List<string>();

            foreach(object entity in  types){
                Dictionary<string, object> entity_obj = DeserializeJsonStr<Dictionary<string, object>>(entity.ToString()); 
                string  type = DeserializeJsonStr<Dictionary<string, object>>(entity_obj["type"].ToString())["name"] as string;
                pkmtypes.Add(type);
            }


           Dictionary<string, object> sprites = DeserializeJsonStr<Dictionary<string, object>>(PokeInfo["sprites"].ToString()); 

           ViewBag.name=PokeInfo["name"];
           ViewBag.primaryType=name;
           ViewBag.height=PokeInfo["height"];
           ViewBag.weight=PokeInfo["weight"];
           ViewBag.pokemons_type=pkmtypes;
           ViewBag.sprites = sprites;

            return View();
            //Json(new{name=PokeInfo["name"],primaryType=name,height=PokeInfo["height"],weight=PokeInfo["weight"], pokemons_type=pkmtypes});

        }

        private T DeserializeJsonStr<T> (string jsonStr){
            return JsonConvert.DeserializeObject<T>(jsonStr);
        }
    }
}
