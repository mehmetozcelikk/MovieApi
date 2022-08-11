using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieAPIController : ControllerBase
    {
        IMovieAPIService _movieAPIService;
        public MovieAPIController(IMovieAPIService movieAPIService)
        {
            _movieAPIService = movieAPIService;
        }

        [HttpGet("Search")]
        public async Task<ActionResult> SearchMovie(string? url, string? page, string? id, string? query)
        {
            var data = await _movieAPIService.SearchMovie(url, page, id, query);
            return Ok(data);
        }
        [HttpGet("MovieDetails")]
        public async Task<ActionResult> MovieDetails(string? url, string? page, string? id, string? query)
        {
            var data = await _movieAPIService.MovieDetails(url, page, id, query);
            return Ok(data);
        }
        [HttpGet("Upcoming")]
        public async Task<ActionResult> UpcomingMovie(string? url, string? page, string? id, string? query)
        {
            var data = await _movieAPIService.UpcomingMovie(url, page, id, query);
            return Ok(data);
        }
        [HttpGet("Similar")]
        public async Task<ActionResult> SimilarMovie(string? url, string? page, string? id, string? query)
        {
            var data = await _movieAPIService.SimilarMovie(url, page, id, query);
            return Ok(data);
        }

    }
}
