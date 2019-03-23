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
    public class UpcomingMoviesViewModelTest
    {
        [Test]
        public async Task UpcomingMoviesList_Not_Null_After_InitializeAsync()
        {
            //Arrange
            var navigationService = new Mock<INavigationService>();
            var upcomingMoviesService = new Mock<IUpcomingMoviesService>();

            var vm = new UpcomingMoviesViewModel(upcomingMoviesService.Object, navigationService.Object);

            //Act
            await vm.InitializeAsync(null);

            //Assert
            Assert.NotNull(vm.UpcomingMovies);
        }

        [Test]
        public async Task UpcomingMoviesList_Has_Items_When_Returned_From_Service()
        {
            //Arrange
            var mockList = new List<UpcomingMovie>();
            mockList.Add(new UpcomingMovie
            {
                Id = 1,
                Overview = "Test",
                PosterPath = "testpath",
                ReleaseDate = DateTime.Today,
                Title = "Test Movie 1"
            });
            mockList.Add(new UpcomingMovie
            {
                Id = 2,
                Overview = "Test",
                PosterPath = "testpath",
                ReleaseDate = DateTime.Today,
                Title = "Test Movie 2"
            });

            var navigationService = new Mock<INavigationService>();
            var upcomingMoviesService = new Mock<IUpcomingMoviesService>();
            upcomingMoviesService.Setup
                (m => m.GetUpcomingMovies(It.IsAny<int>()))
                .Returns(Task.FromResult((IEnumerable<UpcomingMovie>)mockList));

            var vm = new UpcomingMoviesViewModel(upcomingMoviesService.Object, navigationService.Object);

            //Act
            await vm.InitializeAsync(null);

            //Assert
            Assert.AreEqual(2, vm.UpcomingMovies.Count);
        }

        [Test]
        public void MovieTappedCommand_Is_Not_Null()
        {
            //Arrange
            var navigationService = new Mock<INavigationService>();
            var upcomingMoviesService = new Mock<IUpcomingMoviesService>();

            //Act
            var vm = new UpcomingMoviesViewModel(upcomingMoviesService.Object, navigationService.Object);

            //Assert
            Assert.NotNull(vm.MovieTappedCommand);
        }
    }
}