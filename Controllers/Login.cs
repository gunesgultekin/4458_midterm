using _4458_midterm.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _4458_midterm.Controllers
{

    [ApiController]
    [Route("/api/login")]
    public class Login : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        public Login(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpGet("login")]
        public async Task<string> login()
        {
            return await _loginRepository.login();
        }

    }
}
