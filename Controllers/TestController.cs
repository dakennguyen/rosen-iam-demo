using Demo.Data;
using Demo.Models.Entities;
using Demo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IGenericRepository<User> userRepository;

        public TestController(IGenericRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return this.Ok(userRepository.Get());
        }
    }
}