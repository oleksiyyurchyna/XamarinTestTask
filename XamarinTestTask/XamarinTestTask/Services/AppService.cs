using Xamarin.Forms;

namespace XamarinTestTask.Services
{
    public class AppService : IAppService
    {
        public Page MainPage { get; set; }

        public void DisplayAlert(string title, string message, string action)
        {
            MainPage.DisplayAlert(title, message, action);
        }
    }
}
