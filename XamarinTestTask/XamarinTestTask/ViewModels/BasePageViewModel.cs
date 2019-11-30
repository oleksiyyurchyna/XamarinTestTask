using System.ComponentModel;

using Xamarin.Forms;
using XamarinTestTask.Services;

namespace XamarinTestTask.ViewModels
{
    public class BasePageViewModel : BaseViewModel
    {
        private IAppService _appService;

        protected IAppService AppService
        {
            get
            {
                return _appService ?? (_appService = DependencyService.Get<IAppService>());
            }
        }

        public string Title { get; set; }
    }
}
