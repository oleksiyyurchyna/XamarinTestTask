using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinTestTask.Services
{
    public interface IAppService
    {
        Page MainPage { get; set; }

        Task DisplayAlert(string title, string message, string action);
    }
}
