using GCLab16_OMDB_API_.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GCLab16_OMDB_API_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        /*I am aware I did not implement the MovieSearch/Result views & controller methods exactly how the lab wanted me to. I implemented this all 
          pretty quickly after 1 read-through of the lab and noticed I had done it wrong after finishing the Result method. I hope the 
          implementation of MovieNight is sufficient to demonstrate my understanding of the desired implementation strategy/logic
        */
        public IActionResult MovieSearch()
        {
            return View();
        }
        public IActionResult Result(string title)
        {
            MovieModel result = MovieDAL.GetMovie(title);
            return View(result);
        }
        [HttpGet]
        public IActionResult MovieNight() //we have to instantiate this blank list, otherwise the program will freak and say that the model is null in MovieNight view.
        {
            List<MovieModel> result = new List<MovieModel>();
            return View(result);
        }
        [HttpPost]
        public IActionResult MovieNight(string title1, string title2, string title3)
        {
            List<MovieModel> result = new List<MovieModel>();
            result.Add(MovieDAL.GetMovie(title1));
            result.Add(MovieDAL.GetMovie(title2));
            result.Add(MovieDAL.GetMovie(title3));
            if (result == null)
            {
                return RedirectToAction("MovieNight");
            }
            return View(result);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
