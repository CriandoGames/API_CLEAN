using AutoMapper;
using Manager.API.Util;
using Manager.API.ViewModels;
using Manager.Core;
using Manager.Domain.Entities;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {


        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }



        [HttpPost]
        [Route("/api/v1/users")]
        public async Task<ActionResult> Create(CreateUserViewModel input)
        {
            try
            {

                var userMap = _mapper.Map<UserCreateDTO>(input);
                var userCreate = await _service.Create(userMap);

                return Created($"{userCreate.Id}",
                 new ResultViewModel
                 {
                     Data = userCreate,
                     Message = "Usuário criado com sucesso",
                     Success = true
                 });

            }
            catch (DomainException e)
            {

                return BadRequest(ErrorsResponse.DomainErrorMessage(e.Message, e.Errors));

            }
            catch
            {

                return BadRequest(ErrorsResponse.ApplicationErrorMessage());

            }

        }


        [HttpPut]
        [Route("/api/v1/users")]
        public async Task<ActionResult> Update(UpdateUserViewModel input)
        {
            try
            {

                var userMap = _mapper.Map<UserOutputDTO>(input);

                var userCreate = await _service.Update(userMap);

                return Ok(
                 new ResultViewModel
                 {
                     Data = userCreate,
                     Message = "Usuário criado com sucesso",
                     Success = true
                 });

            }
            catch (DomainException e)
            {

                return BadRequest(ErrorsResponse.DomainErrorMessage(e.Message, e.Errors));

            }
            catch
            {

                return BadRequest(ErrorsResponse.ApplicationErrorMessage());

            }

        }


        [HttpDelete]
        [Route("/api/v1/users/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {


                await _service.Delete(id);

                return Ok(
                 new ResultViewModel
                 {
                     Message = "Usuário Deletado com sucesso",
                     Success = true
                 });

            }
            catch (DomainException e)
            {

                return BadRequest(ErrorsResponse.DomainErrorMessage(e.Message, e.Errors));

            }
            catch
            {

                return BadRequest(ErrorsResponse.ApplicationErrorMessage());

            }

        }


        [HttpGet]
        [Route("/api/v1/users/{id}")]
        public async Task<ActionResult> GetUser(Guid id)
        {
            try
            {

                var user = await _service.Get(id);

                if (user == null)
                {
                   return NotFound(new ResultViewModel
                    {
                        Data = null,
                        Message = "Usuário não encontrado",
                        Success = true
                    });
                }

                return Ok(
                 new ResultViewModel
                 {
                     Data = user,
                     Message = "Usuário Encontrado com sucesso",
                     Success = true
                 });

            }
            catch (DomainException e)
            {
                return BadRequest(ErrorsResponse.DomainErrorMessage(e.Message, e.Errors));
            }
            catch
            {
                return BadRequest(ErrorsResponse.ApplicationErrorMessage());
            }

        }


        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/all")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var users = await _service.GetAll();
                             
                return Ok(
                 new ResultViewModel
                 {
                     Data = users,
                     Message = "Usuários Encontrados com sucesso",
                     Success = true
                 });

            }
            catch (DomainException e)
            {
                return BadRequest(ErrorsResponse.DomainErrorMessage(e.Message, e.Errors));
            }
            catch
            {
                return BadRequest(ErrorsResponse.ApplicationErrorMessage());
            }

        }


        [HttpGet]
        [Route("/api/v1/users/get-by-email")]
        public async Task<ActionResult> GetByEmail(string email)
        {
            try
            {
                var users = await _service.GetByEmail(email);

                if (users == null)
                {
                    return NotFound(new ResultViewModel
                    {
                        Message = "Usuário não encontrado",
                        Success = true
                    });
                }

                return Ok(
                 new ResultViewModel
                 {
                     Data = users,
                     Message = "Usuários Encontrados com sucesso",
                     Success = true
                 });

            }
            catch (DomainException e)
            {
                return BadRequest(ErrorsResponse.DomainErrorMessage(e.Message, e.Errors));
            }
            catch
            {
                return BadRequest(ErrorsResponse.ApplicationErrorMessage());
            }

        }


        [HttpGet]
        [Route("/api/v1/users/search-by-name")]
        public async Task<ActionResult> SearchByName(string name)
        {
            try
            {
                var users = await _service.SearchByName(name);

                if (users.Count == 0)
                {
                    return NotFound(new ResultViewModel
                    {
                        Data = null,
                        Message = "Usuário não encontrado",
                        Success = true
                    });
                }

                return Ok(
                 new ResultViewModel
                 {
                     Data = users,
                     Message = "Usuários Encontrados com sucesso",
                     Success = true
                 });

            }
            catch (DomainException e)
            {
                return BadRequest(ErrorsResponse.DomainErrorMessage(e.Message, e.Errors));
            }
            catch
            {
                return BadRequest(ErrorsResponse.ApplicationErrorMessage());
            }

        }


        [HttpGet]
        [Route("/api/v1/users/search-by-email")]
        public async Task<ActionResult> SearchByEmail(string email)
        {
            try
            {
                var users = await _service.SearchByEmail(email);

                if (users.Count == 0)
                {
                    return NotFound(new ResultViewModel
                    {
                        Data = null,
                        Message = "Usuário não encontrado",
                        Success = true
                    });
                }

                return Ok(
                 new ResultViewModel
                 {
                     Data = users,
                     Message = "Usuários Encontrados com sucesso",
                     Success = true
                 });

            }
            catch (DomainException e)
            {
                return BadRequest(ErrorsResponse.DomainErrorMessage(e.Message, e.Errors));
            }
            catch
            {
                return BadRequest(ErrorsResponse.ApplicationErrorMessage());
            }

        }

    }
}
