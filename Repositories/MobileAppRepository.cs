using _4458_midterm.Context;
using _4458_midterm.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _4458_midterm.Repositories
{
    public class MobileAppRepository : IMobileAppRepository
    {
        private DBContext _context;
        public MobileAppRepository(DBContext context) 
        {
            _context = context;
        }
        public async Task<List<string>> queryTuition(long student_num)
        {
            try
            {
                var student = await _context.Students.Where(s => s.student_num == student_num).FirstOrDefaultAsync();

                if (student == null)
                {
                    return new List<string>()
                    {
                        "* cannot find student *"
                    };

                }

                long tuition = student.tuition;

                var bankInfo = await _context.Bank.Where(b => b.student_num == student_num).FirstOrDefaultAsync();

                if(bankInfo == null)
                {
                    return new List<string>()
                    {
                        "* bank server error *"
                    };

                }

                long balance = bankInfo.balance;

                return new List<string>()
            {
                "Tuition Total : " + tuition,
                "Current Balance : " + balance,
            };

            }
            catch (Exception ex)
            {
                return new List<string> { "* server error while executing query * \n",ex.Message};
            }
            
            
        }
    }
}
