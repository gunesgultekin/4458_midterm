namespace _4458_midterm.Interfaces
{
    public interface IMobileAppRepository
    {
        public Task<List<string>> queryTuition(long student_num);
    }
}
