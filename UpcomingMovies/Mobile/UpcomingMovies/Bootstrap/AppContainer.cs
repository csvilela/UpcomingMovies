using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using UpcomingMovies.Repository;
using UpcomingMovies.Services.Data;
using UpcomingMovies.Services.General;
using UpcomingMovies.Services.General.Interfaces;
using UpcomingMovies.ViewModels;

namespace UpcomingMovies.Bootstrap
{
    public class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BaseViewModel>();
            builder.RegisterType<UpcomingMoviesViewModel>();
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<MovieDetailsViewModel>();
            builder.RegisterType<MenuViewModel>();

            builder.RegisterType<UpcomingMoviesService>().As<IUpcomingMoviesService>();
            builder.RegisterType<MovieDetailsService>().As<IMovieDetailsService>();

            builder.RegisterType<NavigationService>().As<INavigationService>();

            builder.RegisterType<GenericRepository>().As<IGenericRepository>();

            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
