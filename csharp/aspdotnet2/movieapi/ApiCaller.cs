using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Models.Movie;

namespace movieapi
{
    public class WebRequest
    {
        public static async Task GetMovieDataAsync(string term, Action<MovieDB> Callback)
        {
            // Create a temporary HttpClient connection.
            using (var Client = new HttpClient())
            {
                try
                {
                    Client.BaseAddress = new Uri($"https://api.themoviedb.org/3/search/movie?api_key=f3e3435aa57e9200f55f76a770ceea5d&language=en-US&query={term}&page=1&include_adult=false");
                    HttpResponseMessage Response = await Client.GetAsync(""); // Make the actual API call.
                    Response.EnsureSuccessStatusCode(); // Throw error if not successful.
                    string StringResponse = await Response.Content.ReadAsStringAsync(); // Read in the response as a string.
                    
                    JObject MovieObject = JsonConvert.DeserializeObject<JObject>(StringResponse);
                    JToken firstMoveObject = null;
                    if(MovieObject["results"] != null){
                        JArray resultList = MovieObject["results"].Value<JArray>();
                        if(resultList.Count > 0)
                            firstMoveObject  = resultList[0]; 
                    }
                    
                   MovieDB MovieData = null;
                   if(firstMoveObject != null){ 

                            MovieData = new MovieDB{
                            title = firstMoveObject["original_title"].Value<string>(),
                            rating = firstMoveObject["vote_average"].Value<float>(),
                            releasedAt = firstMoveObject["release_date"].Value<DateTime>()                        

                        };
                   }                 
                    // Finally, execute our callback, passing it the response we got.
                    Callback(MovieData);
                }
                catch (HttpRequestException e)
                {
                    // If something went wrong, display the error.
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }
        }
    }
}