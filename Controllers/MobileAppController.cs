using _4458_midterm.Context;
using _4458_midterm.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace _4458_midterm.Controllers
{
    [ApiController]
    [Route("/api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class MobileAppController : ControllerBase
    {
        private readonly IMobileAppRepository _mobileAppRepository;
        public MobileAppController(IMobileAppRepository mobileAppRepository)
        {
            _mobileAppRepository = mobileAppRepository;
        }

        [HttpGet("queryTuition")]
        public async Task<List<string>> queryTuition(long student_num)
        {
            return await _mobileAppRepository.queryTuition(student_num);

        }
       


    }
}
