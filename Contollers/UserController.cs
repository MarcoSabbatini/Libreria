using Libreria.Service.Abstraction;
using Libreria.Service.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
namespace Libreria.Contollers
{
    [ApiController]
    [Route("api/v1/[controller]/authentication")]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }


        [HttpPost]
        [Route("signup")]
        public IActionResult SignUp(UserDto userDto)
        {
            if (_userService.SignUp(userDto).Success)
            {
                return Ok();
            }
            else return BadRequest();

        }

        [HttpPost]
        [Route("signin")]
        public IActionResult SignIn(string _email, string _password)
        {
            if (_userService.SignIn(new Service.Models.AuthOptions.Credentials()
            {
                email = _email,
                password = _password

            }).Success) { return Ok(); }
            else return BadRequest();
        }

    }
}
