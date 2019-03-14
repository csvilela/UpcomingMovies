using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UpcomingMovies.API.Core.Services.Interfaces;
using UpcomingMovies.API.Models;

namespace UpcomingMovies.API.Controllers
{
    public class UpcomingMoviesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUpcomingMoviesService _upcomingMoviesService;

        public UpcomingMoviesController(IMapper mapper, IUpcomingMoviesService upcomingMoviesService)
        {
            this._mapper = mapper;
            this._upcomingMoviesService = upcomingMoviesService;
        }

        [HttpGet]
        [Route("upcomingmovies/{page:int}")]
        public async Task<IActionResult> GetUpcomingMovies(int page = 1)
        {
            var upcomingMovies = _mapper.Map<List<UpcomingMovie>>(await _upcomingMoviesService.GetUpcomingMovies(page));

            if(upcomingMovies != null)
            {
                return Ok(upcomingMovies);
            }

            return NotFound();
        }
    }
}