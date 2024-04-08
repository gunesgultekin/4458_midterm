using _4458_midterm.Context;
using _4458_midterm.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _4458_midterm.Repositories
{
    public class WebAppRepository : IWebAppRepository
    {
        private DBContext _context;
        public WebAppRepository(DBContext context)
        {
            _context = context;
        }
        public async Task<string> addTuition(long student_num, string term, long amount)
        {
            var student = await _context.Students.Where(s => s.student_num == student_num && s.term == term).FirstOrDefaultAsync();

            if (student == null)
            {
                return "* failure : cannot find student or term info *";
            }

            if (student.tuition > 0)
            {
                return "* failure : student already have a " + (student.tuition + "$") + " tuition for " + term + "term";
            }

            student.tuition = amount;
            _context.SaveChanges();


            return "* sucess : tuition saved *";
        }

        public async Task<List<Students>> unpaidTuitions(string term)
        {
            var unpaidList = await _context.Students.Where(s => s.tuition > 0 && s.term == term).ToListAsync();
            if (unpaidList == null || unpaidList.Count == 0)
            {
               return new List<Students>();
            }

            return unpaidList;
            
        }
    }
}
