using _4458_midterm.Context;
using _4458_midterm.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _4458_midterm.Repositories
{
    public class BankingAppRepository : IBankingAppRepository
    {
        private readonly DBContext _context;
        public BankingAppRepository(DBContext context)
        {
            _context = context;
        }
        public async Task<string> payTuition(long student_num, string term, long payment_amount)
        {
            var student = await _context.Students.Where(s => s.student_num == student_num).FirstOrDefaultAsync();

            if (student == null)
            {
                return "* cannot find student *";
            }

            if (student.tuition == 0)
            {
                return "* you do not have any tuition fee debt *";

            }

            long tuition = student.tuition;

            var bankInfo = await _context.Bank.Where(b => b.student_num == student_num).FirstOrDefaultAsync();

            if (bankInfo == null)
            {
                return "* payment failed. bank server error *";

            }

            long balance = bankInfo.balance;

            if (balance < tuition) 
            {
                return "* payment failed. insufficient balance *";
            }

            if (payment_amount > tuition)
            {

                return "* payment failed. payment amount exceeded tuition fee *";

            }

            student.tuition -= payment_amount;
            bankInfo.balance -= payment_amount;
            _context.SaveChanges();
            return  "* payment successful. payment amount : " + payment_amount + "remaining debt: " + (tuition-payment_amount);


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

                if (bankInfo == null)
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
                return new List<string> { "* server error while executing query * \n", ex.Message };
            }


        }
    }
}
