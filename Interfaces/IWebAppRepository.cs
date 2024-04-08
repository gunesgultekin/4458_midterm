using _4458_midterm.Context;

namespace _4458_midterm.Interfaces
{
    public interface IWebAppRepository
    {
        public Task<string> addTuition(long student_num, string term, long amount);
        public Task<List<Students>> unpaidTuitions(string term);

    }
}
