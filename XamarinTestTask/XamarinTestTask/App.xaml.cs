using Xamarin.Forms;
using XamarinTestTask.Services;

namespace XamarinTestTask
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            DependencyService.Register<IAppService, AppService>();
            DependencyService.Get<IAppService>().MainPage = MainPage;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
