using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinTestTask.Services
{
    public class AppService : IAppService
    {
        public Page MainPage { get; set; }

        public async Task DisplayAlert(string title, string message, string action)
        {
            await MainPage.DisplayAlert(title, message, action);
        }
    }
}
