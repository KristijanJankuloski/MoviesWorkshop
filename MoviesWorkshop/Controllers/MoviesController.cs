using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using MoviesWorkshop.Data.Repositories;
using MoviesWorkshop.DTOs;
using MoviesWorkshop.Mappers;
using MoviesWorkshop.Models;

namespace MoviesWorkshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieListDto>>> GetAll()
        {
            try
            {
                List<Movie> movies = await _movieRepository.GetAllAsync();
                List<MovieListDto> dto = movies.Select(m => m.ToMovieListDto()).ToList();
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetById(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("Id cannot be negative value");
                }
                Movie movie = await _movieRepository.GetByIdAsync(id);
                if (movie == null)
                {
                    return NotFound($"Movie with id[{id}] was not found");
                }
                return Ok(movie.ToMovieDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }

        [HttpGet("query")]
        public async Task<ActionResult<MovieDto>> GetByIdFromQuery([FromQuery] int? id)
        {
            try
            {
                if (id == null)
                    return BadRequest("Id not provided");
                if (id < 0)
                {
                    return BadRequest("Id cannot be negative value");
                }
                Movie movie = await _movieRepository.GetByIdAsync((int)id);
                if (movie == null)
                {
                    return NotFound($"Movie with id[{id}] was not found");
                }
                return Ok(movie.ToMovieDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] MovieCreateDto dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest("No movie provided");
                if (!ModelState.IsValid)
                    return BadRequest("Wrong parameters");
                await _movieRepository.InsertAsync(dto.ToMovie());
                return StatusCode(StatusCodes.Status201Created, "Movie Created");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] MovieUpdateDto dto)
        {
            try
            {
                if (id < 0)
                    return BadRequest("Id cannot be negative");
                dto.Id = id;
                if (dto == null)
                    return BadRequest("No movie provided");
                if (!ModelState.IsValid)
                    return BadRequest("Wrong parameters");
                await _movieRepository.UpdateAsync(dto.ToMovie());
                return Ok("Movie Updated");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                if (id < 0)
                    return BadRequest("Id cannot be negative value");
                await _movieRepository.DeleteByIdAsync(id);
                return Ok("Movie deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFromBody([FromBody] int id)
        {
            try
            {
                if (id < 0)
                    return BadRequest("Id cannot be negative value");
                await _movieRepository.DeleteByIdAsync(id);
                return Ok("Movie deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }
    }
}
