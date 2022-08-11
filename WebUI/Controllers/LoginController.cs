using Entities.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Claims;
using WebUI.InfraStrructure;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly CookieManager _cookie;




        public LoginController(ILogger<LoginController> logger, CookieManager cookie)
        {
            _logger = logger;
            _cookie = cookie;
        }

        public IActionResult Index()
        {
            if (null != HttpContext.User.Claims.Where(i => i.Type == "Secret").FirstOrDefault())
            {
                return RedirectToRoute(new { action = "MoviePage", controller = "Movie" });
            }
            return View();
        }


        public IActionResult GetToken( )
        {
            HttpClient client = new HttpClient();

            var tokendata = client.GetAsync("http://localhost:5159/api/Token/GetToken").Result;
            var token = tokendata.Content.ReadAsStringAsync().Result;

            ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(token),
    CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);



            var SigninTask = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddHours(8),
                });

            return RedirectToRoute(new { action = "MoviePage", controller = "Movie" });
        }
        private IEnumerable<Claim> GetUserClaims(string token)
        {
            HttpClient client = new HttpClient();
            var data = client.GetAsync("https://api.themoviedb.org/3/authentication/token/new?api_key=ec80cb6f4cc9c116212c2f138b6e7824").Result;
            var jsondata = data.Content.ReadAsStringAsync().Result;
            var value = JsonConvert.DeserializeObject<UserToken>(jsondata);


            List<Claim> claims = new List<Claim> {
            new Claim("Secret" , token),
            new Claim("MovieSecret" , value.Request_Token)
        };
            return claims;
        }

    }
}