using Xamarin.Forms;

namespace XamarinTestTask.Services
{
    public interface IAppService
    {
        Page MainPage { get; set; }

        void DisplayAlert(string title, string message, string action);
    }
}
