using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UpcomingMovies.API.Core.Services.Interfaces;
using UpcomingMovies.API.Models;

namespace UpcomingMovies.API.Controllers
{
    public class MovieDetailsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMovieDetailsService _movieDetailsService;

        public MovieDetailsController(IMapper mapper, IMovieDetailsService movieDetailsService)
        {
            this._mapper = mapper;
            this._movieDetailsService = movieDetailsService;
        }

        [HttpGet]
        [Route("movie/{id:int}")]
        public async Task<IActionResult> GetMovieDetails(int id)
        {
            var movieDetails = _mapper.Map<MovieDetail>(await _movieDetailsService.GetMovieDetails(id));

            if(movieDetails != null)
            {
                return Ok(movieDetails);
            }

            return NotFound();
        }
    }
}