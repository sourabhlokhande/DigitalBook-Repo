using AuthService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelService.Model;

namespace AuthService.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AuthController(ITokenService tokenService, IConfiguration configuration)
        {
            _tokenService = tokenService;
            _configuration = configuration;
        }

        [HttpPost("Validate")]
        public ActionResult<string> Validate(Author author)
        {
            try
            {



                var authorObj = _tokenService.ValidateUser(author);
                if (authorObj != null)
                {
                    var token = _tokenService.BuildToken(_configuration["Jwt:Key"],
                                                _configuration["Jwt:Issuer"],
                                                new[]
                                                {
                                                        _configuration["Jwt:Aud1"],
                                                        _configuration["Jwt:Aud2"]
                                                        },
                                                authorObj);
                    return Ok(new
                    {
                        Token = token,
                        IsAuthenticated = true
                    });

                }
                return Ok(new
                {
                    Token = string.Empty,
                    IsAuthenticated = false
                });
            }
            //else
            //{
            //    return Unauthorized();
            //}
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
