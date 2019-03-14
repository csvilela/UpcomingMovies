using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using UpcomingMovies.Models;
using UpcomingMovies.Services;
using System.Threading.Tasks;
using UpcomingMovies.Annotations;
using UpcomingMovies.Services.General.Interfaces;

namespace UpcomingMovies.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool _isBusy;
        private string _title;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        string title = string.Empty;
        protected readonly INavigationService _navigationService;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public BaseViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }

        public virtual Task InitializeAsync(object data)
        {
            return Task.FromResult(false);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
