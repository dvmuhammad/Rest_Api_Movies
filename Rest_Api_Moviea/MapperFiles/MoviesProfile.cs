using Api.Models.DTO;
using Api.Models.Models;
using AutoMapper;

namespace Rest_Api_Moviea.MapperFiles
{
    public class MoviesProfile: Profile
    {
        public MoviesProfile()
        {
            CreateMap<Movie, MoviesReadDto>();
            CreateMap<MoviesCreateDto, Movie>();
            CreateMap<MovieUpdateDto, Movie>().ReverseMap();
        }
    }
}