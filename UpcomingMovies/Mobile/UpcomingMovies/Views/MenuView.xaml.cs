using UpcomingMovies.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UpcomingMovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuView : ContentPage
    {
        MainView RootPage { get => Application.Current.MainPage as MainView; }

        public MenuView()
        {
            InitializeComponent();

        }
    }
}