using AutoMapper;
using MediatR;
using MovieStream.Application.Abstruction.Services.Contents;
using MovieStream.Application.Models.Contents;
using MovieStream.Application.Repositories.Contents;

namespace MovieStream.Application.Features.Contents.Queries
{
    public class GetAllMovieQueryHandler : IRequestHandler<GetAllMovieQueryRequest, GetAllMovieQueryResponse>
    {
        private readonly IMovieService _movieService;
        private readonly IUserMarkedMovieReadRepository _userMarkedMovieReadRepository;
        private readonly IMapper _mapper;

        public GetAllMovieQueryHandler(IMovieService movieService, IMapper mapper, IUserMarkedMovieReadRepository userMarkedMovieReadRepository)
        {
            _movieService = movieService;
            _mapper = mapper;
            _userMarkedMovieReadRepository = userMarkedMovieReadRepository;
        }

        public async Task<GetAllMovieQueryResponse> Handle(GetAllMovieQueryRequest request, CancellationToken cancellationToken)
        {
            var movies = await _movieService.GetAllMovieAsync();
            var myMarkedMovieIds = (await _userMarkedMovieReadRepository.GetByUser(request.UserId)).Select(x=>x.MovieId);
            var data = new List<MovieModel>();
            foreach (var movie in movies)
            {
                movie.IsMarked = myMarkedMovieIds.Contains(movie.Id);
                data.Add(_mapper.Map<MovieModel>(movie));
            }
            return new() { Movies = data };
        }
    }
}
