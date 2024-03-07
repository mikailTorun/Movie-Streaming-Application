using MediatR;
using MovieStream.Application.Abstruction.Services.Contents;
using MovieStream.Application.Repositories.Contents;

namespace MovieStream.Application.Features.Contents.Queries
{
    public class GetMarkedMovieQueryHandler : IRequestHandler<GetMarkedMovieQueryResquest, GetMarkedMovieQueryResponse>
    {
        private readonly IUserMarkedMovieReadRepository _userMarkedMovieReadRepository;
        private readonly IMovieReadRepository _movieReadRepository;

        public GetMarkedMovieQueryHandler(IUserMarkedMovieReadRepository userMarkedMovieReadRepository, IMovieReadRepository movieReadRepository)
        {
            _userMarkedMovieReadRepository = userMarkedMovieReadRepository;
            _movieReadRepository = movieReadRepository;
        }

        public async Task<GetMarkedMovieQueryResponse> Handle(GetMarkedMovieQueryResquest request, CancellationToken cancellationToken)
        {
            var result = await _userMarkedMovieReadRepository.GetByUser(request.UserId);
            var response = await _movieReadRepository.GetListByIds(result.Select(x=>x.MovieId).ToList());
            return new() { Movies = response };
        }
    }
}
