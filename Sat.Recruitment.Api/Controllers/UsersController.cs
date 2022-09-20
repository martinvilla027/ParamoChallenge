using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Contract.Request;
using Sat.Recruitment.Api.Service;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost]
        [Route("/CreateUser")]
        public IActionResult CreateUser([FromBody] UserRequest request)
        {
            var result = _userService.CreateUser(request);
            if (result.Errors.Any())
            {
                return BadRequest(result.Errors);
            }

            return Created("", result.User);
        }
    }
}
