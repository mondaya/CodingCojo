using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DojoDachiDemo
{
    public class DojoDachi : Controller
    {
        private static Random rand = new Random();
        [HttpGet]
        [Route("dojodachi")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Fullness") == null)
                HttpContext.Session.SetInt32("Fullness", 20);
            if (HttpContext.Session.GetInt32("Happiness") == null)
                HttpContext.Session.SetInt32("Happiness", 20);
            if (HttpContext.Session.GetInt32("Meals") == null)
                HttpContext.Session.SetInt32("Meals", 3);
            if (HttpContext.Session.GetInt32("Energy") == null)
                HttpContext.Session.SetInt32("Energy", 50);

            if (HttpContext.Session.GetString("Image") == null)
                HttpContext.Session.SetString("Image", "/image/initial.jpg");

            ViewBag.Fullness = getFullness();
            ViewBag.Happiness = getHappiness();
            ViewBag.Meals = getMeals();
            ViewBag.Engery = getEnergy();
            ViewBag.Image = getImage();
            return View();
        }




        [HttpGet]
        [Route("dojodachi/perform/{Task}")]
        public JsonResult Peform(string Task)
        {
            string messsge = "";
            string image = "";
            Console.WriteLine(Task);
            switch (Task)
            {
                case "Feed":
                    {
                        int? meals = getMeals();
                        int? fullness = getFullness();
                        if (meals >= 1)
                        {
                            meals -= 1;
                            HttpContext.Session.SetInt32("Meals", (int)meals);

                            if(rand.Next(1,101) >= 25){
                                int gain = rand.Next(5, 11);
                                fullness += gain;
                                HttpContext.Session.SetInt32("Fullness", (int)fullness);
                                messsge = $"fullness +{gain}";
                                image = "full_4.jpg";
                            }
                            else
                            {
                                messsge = "He does not like to be feed";
                                image = "full_2.jpg";

                            }
                        }
                        else
                        {
                            messsge = "No food";
                            image = "full_1.jpg";
                        }
                    }

                    break;
                case "Play":
                    {
                        int? energy = getEnergy();
                        int? happiness = getHappiness();
                        if (energy >= 5)
                        {
                            energy -= 5;
                            HttpContext.Session.SetInt32("Energy", (int)energy);
                            if(rand.Next(1,101) > 25){
                                int gain = rand.Next(5, 11);
                                happiness += gain;
                                HttpContext.Session.SetInt32("Happiness", (int)happiness);
                                messsge = $"Happiness +{gain},  Energy -5";
                                image = "full_5.jpg";
                            }
                            else
                                messsge = "He does not want to play :(";
                                image = "full_2.jpg";

                        }
                        else
                            messsge = "No energy";
                            image = "full_2.jpg";
                    }
                    break;
                case "Work":
                    {
                        int? energy = getEnergy();
                        int? meals = getMeals();
                        if (energy >= 5)
                        {
                            energy -= 5;
                            HttpContext.Session.SetInt32("Energy", (int)energy);
                            int gain = rand.Next(1, 4);
                            meals += gain;
                            HttpContext.Session.SetInt32("Meals", (int)meals);
                            messsge = $"Meals +{gain} Energy -5";
                            image = "happy_4.jpg";


                        }
                        else
                            messsge = "No energy";
                            image = "full_2.jpg";

                    }
                    break;
                case "Sleep":
                    {
                        int? energy = getEnergy();
                        int? happiness = getHappiness();
                        int? fullness = getFullness();
                       
                         energy += 15;
                         HttpContext.Session.SetInt32("Energy", (int)energy);
                         fullness -= 5;
                         HttpContext.Session.SetInt32("Fullness", (int)fullness);
                         happiness -= 5;
                         HttpContext.Session.SetInt32("Happiness", (int)happiness);
                         messsge = "Fullness -5, Happiness -5, Energy +15";
                         image = "full_5.jpg";
                       
                    }
                    break;
                default:
                    break;
            }
            HttpContext.Session.SetString("Image", $"/image/{image}");
            HttpContext.Session.SetString("Message", $"You Played with DojoDachi! {messsge}");            
            return Json(new
            {
                Fullness = getFullness(),
                Happiness = getHappiness(),
                Meals = getMeals(),
                Energy = getEnergy()
                
            });
        }

        [HttpGet]
        [Route("dojodachi/emoji/state")]
        public JsonResult DojoDachiState()
        {
            bool restartFlg = setWinLostMessageReturnRestFlag();
            Console.WriteLine($"{getImage()}{getMessage()}");
            return Json(new { image = getImage(), message = getMessage(), restart = restartFlg });
        }

        [HttpGet]
        [Route("dojodachi/reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        private int? getFullness()
        {
            return HttpContext.Session.GetInt32("Fullness");
        }
        private int? getHappiness()
        {
            return HttpContext.Session.GetInt32("Happiness");
        }
        private int? getMeals()
        {
            return HttpContext.Session.GetInt32("Meals");
        }
        private int? getEnergy()
        {
            return HttpContext.Session.GetInt32("Energy");
        }


        private string getImage()
        {
            return HttpContext.Session.GetString("Image");
        }

        private string getMessage()
        {
            return HttpContext.Session.GetString("Message");
        }

        private bool setWinLostMessageReturnRestFlag()
         {
               
                if(getEnergy() >= 100 && getHappiness() >= 100 &&  getFullness() >= 100){
                     HttpContext.Session.SetString("Image", $"/image/won.jpg");
                     HttpContext.Session.SetString("Message", $"Congratulation You won!");
                     return true;
                }

                if(getHappiness() <= 0 ||  getFullness() <= 0){
                     HttpContext.Session.SetString("Image", $"/image/lost.jpg");
                     HttpContext.Session.SetString("Message", $"Your DojoDachi has passed away!");
                     return true;
                }

                return false;
            }

    }
}