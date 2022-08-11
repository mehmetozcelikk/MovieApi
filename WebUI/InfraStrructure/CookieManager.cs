using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebUI.Models;

namespace WebUI.InfraStrructure
{
    public class CookieManager
    {
        HttpContext _httpContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieManager( /* HttpContext httpContext*/ IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            //_httpContext = httpContext;
        }

        public string Cookie( ) {
            HttpClient client = new HttpClient();

            var tokendata = client.GetAsync("http://localhost:5159/api/Token/GetToken").Result;
            var token = tokendata.Content.ReadAsStringAsync().Result;

            ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(token),
                CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);



            var SigninTask = _httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddHours(8),
                });
            return token;

        }

        private IEnumerable<Claim> GetUserClaims(string token) {

            var guid = Guid.NewGuid().ToString();
            List<Claim> claims = new List<Claim> {
            new Claim("Secret" , token)
        };
            return claims;
        }
        public  string SaveCookie(string query)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(10);
            string words5 = _httpContextAccessor.HttpContext.Request.Cookies["words5"] != null ? _httpContextAccessor.HttpContext.Request.Cookies["words4"] : "";
            string words4 = _httpContextAccessor.HttpContext.Request.Cookies["words4"] != null ? _httpContextAccessor.HttpContext.Request.Cookies["words4"] : "";
            string words3 = _httpContextAccessor.HttpContext.Request.Cookies["words3"] != null ? _httpContextAccessor.HttpContext.Request.Cookies["words3"] : "";
            string words2 = _httpContextAccessor.HttpContext.Request.Cookies["words2"] != null ? _httpContextAccessor.HttpContext.Request.Cookies["words2"] : "";
            string words1 = _httpContextAccessor.HttpContext.Request.Cookies["words1"] != null ? _httpContextAccessor.HttpContext.Request.Cookies["words1"] : "";

            if (query.ToLower() == words1.ToLower() || query.ToLower() == words2.ToLower() || query.ToLower() == words3.ToLower() || query.ToLower() == words4.ToLower() || query.ToLower() == words5.ToLower())
            {
                if (query.ToLower() == words1.ToLower())
                {
                    return query;
                }
                if (query.ToLower() == words2.ToLower())
                {
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("words1", query, option);
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("words2", words1, option);
                    return query;
                }
                if (query.ToLower() == words3.ToLower())
                {
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("words1", query, option);
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("words2", words1, option);
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("words3", words2, option);
                    return query;
                }
                if (query.ToLower() == words4.ToLower())
                {
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("words1", query, option);
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("words2", words1, option);
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("words3", words2, option);
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("words4", words3, option);
                    return query;
                }
                if (query.ToLower() == words5.ToLower())
                {
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("words1", query, option);
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("words2", words1, option);
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("words3", words2, option);
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("words4", words3, option);
                    _httpContextAccessor.HttpContext.Response.Cookies.Append("words5", words4, option);
                    return query;
                }
                return query;
            }
            _httpContextAccessor.HttpContext.Response.Cookies.Append("words1", query, option);

            _httpContextAccessor.HttpContext.Response.Cookies.Append("words5", words4, option);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("words4", words3, option);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("words3", words2, option);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("words2", words1, option);


            return query;
        }

        public string[] ReadCookie()
        {
            string words5 = _httpContextAccessor.HttpContext.Request.Cookies["words5"];   // kayıtlı aranan kelimeler varsa onları cookie den çekiyorum
            string words4 = _httpContextAccessor.HttpContext.Request.Cookies["words4"];
            string words3 = _httpContextAccessor.HttpContext.Request.Cookies["words3"];
            string words2 = _httpContextAccessor.HttpContext.Request.Cookies["words2"];
            string words1 = _httpContextAccessor.HttpContext.Request.Cookies["words1"];
            string[] searchkeyvalues = { words1, words2, words3, words4, words5 };
            return searchkeyvalues;
        }
    }
}
