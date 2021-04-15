using DigitalHive.Api.Data;
using DigitalHive.Api.Data.Models;
using DigitalHive.Api.Data.Models.DAO;
using Microsoft.AspNetCore.Mvc;

namespace DigitalHive.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UsersController : ControllerBase
  {
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
      var response = _userService.Authenticate(model);

      if (response == null)
        return BadRequest(new { message = "Username or password is incorrect" });

      return Ok(response);
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetAll()
    {
      var users = _userService.GetAll();
      return Ok(users);
    }

    [HttpPost]
    public IActionResult RegisterUser(RegisterRequest model)
    {
      var response = _userService.Register(model);

      if (response == null)
        return BadRequest(new { message = "Cannot register user" });

      return Ok(response);
    }
  }
}