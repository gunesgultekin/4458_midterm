namespace _4458_midterm.Interfaces
{
    public interface IBankingAppRepository
    {
        public Task<List<string>> queryTuition (long tudent_num);
        public Task<string> payTuition(long student_num, string term, long payment_amount);

    }
}
