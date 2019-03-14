using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using UpcomingMovies.Models;
using UpcomingMovies.Services.Data;
using System.Windows.Input;
using UpcomingMovies.Services.General.Interfaces;
using System.Linq;

namespace UpcomingMovies.ViewModels
{
    public class UpcomingMoviesViewModel : BaseViewModel
    {
        private readonly IUpcomingMoviesService _upcomingMoviesService;
        private int lastPageLoaded;
        private ObservableCollection<UpcomingMovie> _movies;
        private object _selectedItem;

        public ObservableCollection<UpcomingMovie> UpcomingMovies {
            get => _movies;
            set
            {
                _movies = value;
                OnPropertyChanged();
            }
        }

        public ICommand MovieTappedCommand => new Command<UpcomingMovie>(OnMovieTapped);

        public ICommand ItemAppearingCommand => new Command<UpcomingMovie>(OnItemAppearing);

        public object SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public UpcomingMoviesViewModel(IUpcomingMoviesService upcomingMoviesService, INavigationService navigationService)
            :base(navigationService)
        {
            this._upcomingMoviesService = upcomingMoviesService;

            Title = "Upcoming Movies";
            this.lastPageLoaded = 0;

            UpcomingMovies = new ObservableCollection<UpcomingMovie>();

        }

        public override async Task InitializeAsync(object data)
        {
            await FetchNextBatchOfUpcomingMovies();
        }

        private async Task FetchNextBatchOfUpcomingMovies()
        {

            IsBusy = true;

            try
            {
                lastPageLoaded++;
                var movies = await _upcomingMoviesService.GetUpcomingMovies(lastPageLoaded);
                foreach (var movie in movies)
                {
                    this.UpcomingMovies?.Add(movie);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void OnMovieTapped(UpcomingMovie tappedMovie)
        {
            _navigationService.NavigateToAsync<MovieDetailsViewModel>(tappedMovie.Id);
            this.SelectedItem = null;
        }

        private async void OnItemAppearing(UpcomingMovie appearingMovie)
        {
            if (UpcomingMovies.Last().Id == appearingMovie.Id)
            {
                await FetchNextBatchOfUpcomingMovies();
            }
            this.SelectedItem = null;
        }
    }
}