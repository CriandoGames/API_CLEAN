using Manager.API.Util;
using Manager.API.Util.Token;
using Manager.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthController(IConfiguration configuration, ITokenGenerator tokenGenerator)
        {
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        [Route("v1/auth")]
        public IActionResult Authenticate([FromBody] AuthViewModel input)
        {


            try
            {
                var user = _configuration["Jwt:Login"];
                var password = _configuration["Jwt:Password"];
                if (user == input.Login || password == input.Password)
                {

                    var token = _tokenGenerator.GenerateToken();
                    return Ok(new ResultViewModel
                    {
                        Data = token,
                        Message = "Usuário criado com sucesso",
                        Success = true
                    });

                }
                else
                {
                    return Unauthorized(ErrorsResponse.UnathorizedErrorMessage());
                }


            }
            catch (Exception)
            {

                return StatusCode(500, ErrorsResponse.ApplicationErrorMessage());
            }




        }

    }
}
