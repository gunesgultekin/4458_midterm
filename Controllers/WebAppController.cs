using _4458_midterm.Context;
using _4458_midterm.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _4458_midterm.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class WebAppController : ControllerBase
    {
        private readonly IWebAppRepository _webAppRepository;
        public WebAppController(IWebAppRepository webAppRepository)
        {
            _webAppRepository = webAppRepository;
        }
        [HttpGet("addTuition")]
        public async Task<string> addTuition(long student_num, string term, long amount)
        {
            return await _webAppRepository.addTuition(student_num, term, amount);
        }
        [HttpGet("unpaidTuitions")]
        public async Task<List<Students>> unpaidTuitions(string term)
        {
            return await _webAppRepository.unpaidTuitions(term);

        }
    }
}
