using AutoMapper;
using Manager.API.Util;
using Manager.API.Util.Token;
using Manager.API.ViewModels;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SecureIdentity.Password;

namespace Manager.API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserRepository _repository;
        private readonly ITokenGenerator _tokenGenerator;
  

        public AuthController(IUserRepository repository, ITokenGenerator tokenGenerator)
        {
            _repository = repository;
            _tokenGenerator = tokenGenerator;
    
        }

        [HttpPost]
        [Route("v1/auth")]
        public async Task<IActionResult> Authenticate([FromBody] AuthViewModel input)
        {


            try
            {
                var foundUser = await _repository.GetByEmailAsync(input.Login);

                if( foundUser == null)
                {
                    return Unauthorized(ErrorsResponse.UnathorizedErrorMessage());
                }


                if(!PasswordHasher.Verify(foundUser.Password,input.Password))
                    return Unauthorized(ErrorsResponse.UnathorizedErrorMessage());


              
                _tokenGenerator.SetUser(foundUser);
                var token = _tokenGenerator.GenerateToken();
                    return Ok(new ResultViewModel
                    {
                        Data = 
                        token,
                        Message = "Usuário criado com sucesso",
                        Success = true
                    });

                
            }
            catch (Exception)
            {

                return StatusCode(500, ErrorsResponse.ApplicationErrorMessage());
            }




        }

    }
}
