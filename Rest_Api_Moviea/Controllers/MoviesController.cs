using System;
using System.Threading.Tasks;
using Api.Models.DTO;
using Api.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Rest_Api_Moviea.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController:Controller
    {
        private readonly MoviesService _moviesService;

        public MoviesController(MoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _moviesService.GetAllMoviesAsync());
        }

        [HttpGet("{id}", Name = "GetMovieById")]
        public async Task<IActionResult> GetMoviesById(int id)
        {
            var model = await _moviesService.GetByIdAsync(id);

            if (model==null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> GreatMovies(MoviesCreateDto dto)
        {
            await _moviesService.AddAndSaveAsync(dto);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie(int id, MovieUpdateDto dto)
        {
            try
            {
                await _moviesService.UpdateAndSaveAsync(id, dto);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }
        
        
        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                await _moviesService.DeleteAndSaveAsync(id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }
        
    }
}