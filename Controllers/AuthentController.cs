using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PhotoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentController : Controller
    {
        [Authorize]
        [Route("getlogin")]
        public IActionResult GetLogin()
        {
            var name = User.Claims.FirstOrDefault(p => p.Type == "name");
            return Ok($"Ваш логин {name.Value}");
        }

        [Authorize(Roles = "admin")]
        [Route("getrole")]
        public IActionResult GetRole()
        {
            return Ok("Ваша роль: администратор");
        }
    }
}