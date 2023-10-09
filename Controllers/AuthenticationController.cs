using Microsoft.AspNetCore.Mvc;
using VacationRequester.Data;

namespace VacationRequester.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {

        [HttpPost("login")]
        public void Login()
        {
           
        }

        [HttpPost("register")]
        public void Register()
        {

        }

    }
}