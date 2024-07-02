using Libreria.Service.Abstraction;
using Libreria.Service.Factories;
using Libreria.Service.Models.AuthOptions;
using Libreria.Service.Models.Dtos;
using Libreria.Service.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
namespace Libreria.Contollers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }


        [HttpPost]
        [Route("signup")]
        public IActionResult SignUp(UserCreationReq req)
        {
            if (_userService.Get(req.Email) == null)
            {
                _userService.Add(req.EntityCreation());
                return Ok(ResponseFactory.WithSuccess());
            } else return BadRequest(ResponseFactory.WithErrors("Choose a non-existent email"));

        }

        [HttpPost]
        [Route("signin")]
        public IActionResult SignIn(Credentials cred)
        {
            var user = _userService.Get(cred.email);
            if (user != null && cred.password.Equals(user.Password))
            {
                return Ok(ResponseFactory.WithSuccess(_userService.CreateSecurityToken(cred)));
            }
            else return BadRequest(ResponseFactory.WithErrors("Wrong email or password"));

            /*if (_userService.SignIn(new Service.Models.AuthOptions.Credentials()
            {
                email = _email,
                password = _password

            }).Success) { return Ok(); }
            else return BadRequest();*/
        }

    }
}
