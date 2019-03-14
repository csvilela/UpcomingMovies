using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UpcomingMovies.Models;
using UpcomingMovies.Services.Data;
using UpcomingMovies.Services.General.Interfaces;
using UpcomingMovies.ViewModels;

namespace UpcomingMovies.Test
{
    public class MovieDetailsViewModelTest
    {
        [Test]
        public async Task Movie_Not_Null_After_InitializeAsync()
        {
            //Arrange
            var navigationService = new Mock<INavigationService>();
            var movieDetailsService = new Mock<IMovieDetailsService>();

            var vm = new MovieDetailsViewModel(movieDetailsService.Object, navigationService.Object);

            //Act
            await vm.InitializeAsync(null);

            //Assert
            Assert.NotNull(vm.Movie != null);
        }

        [Test]
        public async Task Movie_Is_Correct_When_Returned_From_Service()
        {
            //Arrange
            var mockMovie = new MovieDetails
            {
                BackdropPath = "testpath",
                Genres = new string[]{ "Action", "Adventure" },
                Overview = "This is a test movie",
                PosterPath = "testpath",
                ReleaseDate = DateTime.Today,
                Title = "Test Movie"
            };

            var navigationService = new Mock<INavigationService>();
            var movieDetailsService = new Mock<IMovieDetailsService>();
            movieDetailsService.Setup
                (m => m.GetMovieDetails(It.IsAny<int>()))
                .Returns(Task.FromResult(mockMovie));

            var vm = new MovieDetailsViewModel(movieDetailsService.Object, navigationService.Object);

            //Act
            await vm.InitializeAsync(1);

            //Assert
            Assert.AreEqual(mockMovie.BackdropPath, vm.Movie.BackdropPath);
            Assert.AreEqual(mockMovie.Overview, vm.Movie.Overview);
            Assert.AreEqual(mockMovie.PosterPath, vm.Movie.PosterPath);
            Assert.AreEqual(mockMovie.ReleaseDate, vm.Movie.ReleaseDate);
            Assert.AreEqual(mockMovie.Title, vm.Movie.Title);
        }
       
    }
}