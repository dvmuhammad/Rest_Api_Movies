using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models.DTO;
using Api.Models.Models;
using Api.Repositories.Interfaces;
using AutoMapper;

namespace Api.Services.Services
{
    public class MoviesService
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IMapper _mapper;

        public MoviesService(IRepository<Movie> movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MoviesReadDto>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<MoviesReadDto>>(movies);
        }

        public async Task<MoviesReadDto> GetByIdAsync(int id)
        {
            var movies = await _movieRepository.GetByIdAsync(id);

            return _mapper.Map<MoviesReadDto>(movies);
        }

        private void DataBaseSaveChanges()
        {
            _movieRepository.SaveChanges();
        }

        public async Task AddAndSaveAsync(MoviesCreateDto model)
        {
            var movies = _mapper.Map<Movie>(model);
            _movieRepository.Add(movies);
            await _movieRepository.SaveChangesAsync();
        }

        private async Task Update(int id, MovieUpdateDto dto)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            if (movie == null)
            {
                throw new AggregateException($"Movie with id: {id} not found");
            }

            _mapper.Map(dto, movie);
            
            _movieRepository.Update(movie);
        }
        
        public async Task UpdateAndSaveAsync(int id, MovieUpdateDto dto)
        {
            await Update(id, dto);
            DataBaseSaveChanges();
        }

        private async Task Delete(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            if (movie == null)
            {
                throw new ArgumentException($"Movie with id : {id} not found");
            }
            _movieRepository.Delete(movie);
        }

        public async Task DeleteAndSaveAsync(int id)
        {
            await Delete(id);
            DataBaseSaveChanges();
        }
    }
}