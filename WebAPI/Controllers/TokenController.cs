using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    { 
        IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("GetToken")]
        public string  GetToken( )
        {

            if (true)
            {


                var tokenHandler = new JwtSecurityTokenHandler();

                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("Token:SigninKey"));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    //Subject = new ClaimsIdentity(new Claim[]
                    //{
                    //new Claim (ClaimTypes.Name, user.Id.ToString())
                    //}),
                    Audience = _configuration.GetValue<string>("Token:Audience"),
                    Issuer = _configuration.GetValue<string>("Token:Issuer"),
                    Expires = DateTime.Now.AddHours(999),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)

                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);

            }
            return string.Empty;
        }
    }
}