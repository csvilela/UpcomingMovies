using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Services.General.Interfaces;

namespace UpcomingMovies.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        //TODO: Wire up menu with actual view models generically
        public MenuViewModel(INavigationService navigationService)
            :base(navigationService)
        {
        }
        
    }
}
