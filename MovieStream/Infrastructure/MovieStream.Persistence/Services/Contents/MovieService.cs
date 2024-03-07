using AutoMapper;
using MovieStream.Application.Abstruction.Services.Contents;
using MovieStream.Application.Abstruction.Services.Identity;
using MovieStream.Application.Features.Contents.Commands;
using MovieStream.Application.Features.Contents.Queries;
using MovieStream.Application.Models.Contents;
using MovieStream.Application.Repositories.Contents;
using MovieStream.Domain.Entities;

namespace MovieStream.Persistence.Services.Contents
{
    public class MovieService : IMovieService
    {
        private readonly IMovieReadRepository _movieReadRepository;
        private readonly IMovieWriteRepository _movieWriteRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IUserMarkedMovieWriteRepository _userMarkedMovieWriteRepository;
        private readonly IUserMarkedMovieReadRepository _userMarkedMovieReadRepository;

        public MovieService(IMovieWriteRepository movieWriteRepository, IMovieReadRepository movieReadRepository, IMapper mapper, IUserService userService, IUserMarkedMovieWriteRepository userMarkedMovieWriteRepository, IUserMarkedMovieReadRepository userMarkedMovieReadRepository)
        {
            _movieWriteRepository = movieWriteRepository;
            _movieReadRepository = movieReadRepository;
            _mapper = mapper;
            _userService = userService;
            _userMarkedMovieWriteRepository = userMarkedMovieWriteRepository;
            _userMarkedMovieReadRepository = userMarkedMovieReadRepository;
        }

        public async Task<List<Movie>> GetAllMovieAsync()
        {
            return (await _movieReadRepository.GetAllAsync(tracking:false)).ToList();
        }        

        public async Task<GetFilteredMovieQueryResponse> GetFilteredMovieAsync(GetFilteredMovieQueryRequest request)
        {
            var filterResult = await _movieReadRepository.GetFilteredAsync(request);
            return filterResult;
        }

        public async Task<GetMovieQueryResponse> GetMovieAsync(GetMovieQueryRequest getMovieQueryRequest)
        {
            var product = await this._movieReadRepository.GetAsync(getMovieQueryRequest.Id, true);
            return this._mapper.Map<GetMovieQueryResponse>(product);
        }

        public async Task<MovieModel> MarkMovie(Guid movieId, Guid userId)
        {
            var isDeleteOps = await _userMarkedMovieReadRepository.GetByUserAndMovie(movieId,userId);
            if (isDeleteOps != null)
            {
                _= await _userMarkedMovieWriteRepository.RemoveAsync(isDeleteOps.Id);
            }
            else
            {
                _ = await _userMarkedMovieWriteRepository.SaveAsync(new() { MovieId = movieId, MovieStreamUserId = userId });
            }
            _=await _userMarkedMovieWriteRepository.SaveChangesAsync();
            return  _mapper.Map<MovieModel>( await _movieReadRepository.GetAsync(movieId,false));
        }
    }
}
