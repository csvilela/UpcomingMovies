using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Services.General.Interfaces;

namespace UpcomingMovies.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(INavigationService navigationService)
            :base(navigationService)
        {
        }

        public override async Task InitializeAsync(object data)
        {
            await Task.WhenAll
                (
                    _navigationService.NavigateToAsync<UpcomingMoviesViewModel>()
                );
        }
    }
}
