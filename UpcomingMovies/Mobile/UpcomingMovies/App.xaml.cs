using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UpcomingMovies.Services;
using UpcomingMovies.Views;
using UpcomingMovies.Bootstrap;
using System.Threading.Tasks;
using UpcomingMovies.Services.General.Interfaces;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace UpcomingMovies
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            AppContainer.RegisterDependencies();

            InitializeNavigation();
        }

        private async Task InitializeNavigation()
        {
            await AppContainer.Resolve<INavigationService>().InitializeAsync();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
