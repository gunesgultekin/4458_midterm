using _4458_midterm.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _4458_midterm.Controllers
{

    [ApiController]
    [Route("/api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]

    public class BankingAppController : ControllerBase
    {
        private IBankingAppRepository _bankingAppRepository;
        public BankingAppController(IBankingAppRepository bankingAppRepository)
        {
            _bankingAppRepository = bankingAppRepository;
        }

        [Authorize]
        [HttpGet("queryTuition")]
        public async Task<List<string>> queryTuition(long student_num)
        {
            return await _bankingAppRepository.queryTuition(student_num);
        }

        [HttpGet("payTuition")]
        public async Task<string> payTuition(long student_num, string term, long payment_amount)
        {
            return await _bankingAppRepository.payTuition(student_num, term, payment_amount);

        }
    }
}
