using Api.Models.Models;
using Api.Repositories.Interfaces;
using Api.Services.Services;
using AutoMapper;
using NSubstitute;
using NUnit.Framework;

namespace Api.Tests
{
    [TestFixture]
    public class Tests
    {
        private MoviesService _moviesService;
        private IRepository<Movie> _repository;
        private IMapper _mapper;
        
        [SetUp]
        public void Setup()
        {
            _repository = Substitute.For<IRepository<Movie>>();
            _mapper = Substitute.For<IMapper>();
            _moviesService = new MoviesService(_repository, _mapper);
        }    
    }
}