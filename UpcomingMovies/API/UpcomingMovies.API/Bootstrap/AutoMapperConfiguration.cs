using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpcomingMovies.API.Models;

namespace UpcomingMovies.API.Bootstrap
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Core.Domain.UpcomingMovie, UpcomingMovie>();
                cfg.CreateMap<Core.Domain.MovieDetail, MovieDetail>()
                .ForMember(d => d.Genres,
                s => s.MapFrom(m => m.Genres.Select(g => g.Name)));
            });
            return config;
        }
    }
}
