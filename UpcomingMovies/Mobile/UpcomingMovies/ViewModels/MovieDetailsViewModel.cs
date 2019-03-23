using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using UpcomingMovies.Models;
using UpcomingMovies.Views;
using UpcomingMovies.Services.Data;
using UpcomingMovies.Services.General.Interfaces;

namespace UpcomingMovies.ViewModels
{
    public class MovieDetailsViewModel : BaseViewModel
    {
        private readonly IMovieDetailsService _movieDetailsService;
        private MovieDetails _movie;

        public MovieDetails Movie {
            get => _movie;
            set
            {
                _movie = value;
                OnPropertyChanged();
            }
        }

        public MovieDetailsViewModel(IMovieDetailsService movieDetailsService, INavigationService navigationService)
            :base(navigationService)
        {
            this._movieDetailsService = movieDetailsService;
            Title = "Movie Details";

            Movie = new MovieDetails();
        }

        public override async Task InitializeAsync(object data)
        {
            IsBusy = true;

            try
            {
                Movie = await _movieDetailsService.GetMovieDetails((int)data);
                Title = Movie.Title;
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
    }
}