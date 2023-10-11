using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VacationRequester.Models;
using VacationRequester.Repositories.Interfaces;

namespace VacationRequester.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;

        public RoleController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        
    }
}
