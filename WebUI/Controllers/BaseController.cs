using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebUI.Controllers
{
    //[Authorize]
    public class BaseController : Controller
    {
        public BaseController()
        {

        }

        public Claim GetClaim(string claimtype)
        {
            return HttpContext.User.Claims.Where(i => i.Type == claimtype).FirstOrDefault();
        }
        public string GetToken( )
        {
            string token = HttpContext.User.Claims.Where(i => i.Type == "Secret").FirstOrDefault().Value;
            return token;
        }
        public string GetMovieToken()
        {
            string token = HttpContext.User.Claims.Where(i => i.Type == "MovieSecret").FirstOrDefault().Value;
            return token;
        }
        public int Test { get; set; }
    }
}
