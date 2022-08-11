using Entities.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http.Headers;
using WebUI.InfraStrructure;

namespace WebUI.Controllers
{
    [Authorize]
    public class MovieController : BaseController
    {
        CookieManager _cookieManager;
        public MovieController(CookieManager cookieManager)
        {
            _cookieManager = cookieManager;
        }

        public IActionResult MoviePage()
        {
            var searchkeyvalues = _cookieManager.ReadCookie();
            ViewBag.savedsearch = searchkeyvalues;

            var customMovieVM = GetCustomMovieVM();
            return View(customMovieVM);
        }

        [HttpGet]
        public IActionResult GetSearchMovies(string query, int i = 1)  // sayfalama için kütüphane kullanmadım 
        {
            var data = GetData("search", Convert.ToString(i), "1", query);

            var value = JsonConvert.DeserializeObject<MovieSearchVM>(data);
            value.query = query;    

            var customMovieVM = GetCustomMovieVM();           // Türkiye’de yakında vizyona girecek olan filmlerin listesi
            customMovieVM.movieSearchVMs = value;
            customMovieVM.movieSearchVMs.Page=i;
            return View(customMovieVM);
        }

        public IActionResult GetMovieDetail(string id)
        {
            var data = GetData("MovieDetails", "1", id.ToString() , "");
            var movieDetailVM = JsonConvert.DeserializeObject<MovieDetailVM>(data);
            var customMovieVM = GetCustomMovieVM();         // Türkiye’de yakında vizyona girecek olan filmlerin listesi
            var similarMoviesVM = GetSimilarMovies(id);
            customMovieVM.similarMoviesVM= similarMoviesVM;
            customMovieVM.movieDetailVM = movieDetailVM;
            return View(customMovieVM);
        }



        public  CustomMovieVM GetCustomMovieVM()
        {
            var data = GetData("upcoming", "1", "1", "");
            var turkeymoviesvalue = JsonConvert.DeserializeObject<TurkeyMoviesVM>(data);

            CustomMovieVM customMovieVM = new CustomMovieVM();
            customMovieVM.turkeyMoviesVM = turkeymoviesvalue;

            return customMovieVM;
        }

        public  SimilarMoviesVM GetSimilarMovies(string id)
        {
            var data = GetData("similar", "1", id.ToString(), "");

            var similarMoviesvalue = JsonConvert.DeserializeObject<SimilarMoviesVM>(data);
            return similarMoviesvalue;
        }



        public  string  GetData(string? url, string? page, string? id, string? query)
        {
            HttpClient client = new HttpClient();

            //var contenttype = new MediaTypeWithQualityHeaderValue("application/json");
            //client.DefaultRequestHeaders.Accept.Add(contenttype);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetToken());


            var dataa = client.GetAsync("http://localhost:5159/api/MovieAPI/"+ url+"?url=" +url+"&page="+page+ "&id="+id+"&query=" +query).Result;
            var value = dataa.Content.ReadAsStringAsync().Result;
            return value;
        }
        public IActionResult SaveKeywordCookie(string query)
        {    
            _cookieManager.SaveCookie(query);
            return RedirectToAction("GetSearchMovies", "Movie", new {query=query} );
        }

    }
}
