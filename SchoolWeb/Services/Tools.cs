namespace SchoolWeb.Services
{
    public class Tools : ITools
    {
        public string GetTodayDate()
        {
            return DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
