using MediatR;
using MovieStream.Application.Repositories.Contents;
using MovieStream.Domain.Entities;

namespace MovieStream.Application.Features.Contents.Commands
{
    public class GenerateRandomMovieCommandHandler : IRequestHandler<GenerateRandomMovieCommandRequest, GenerateRandomMovieCommandResponse>
    {
        private readonly IMovieWriteRepository _movieWriteRepository;

        public GenerateRandomMovieCommandHandler(IMovieWriteRepository movieWriteRepository)
        {
            _movieWriteRepository = movieWriteRepository;
        }

        public async Task<GenerateRandomMovieCommandResponse> Handle(GenerateRandomMovieCommandRequest request, CancellationToken cancellationToken)
        {
            Movie movie = new();
            if(request.Count>100)
                request.Count = 100;
            for (int i = 1; i <= request.Count; i++)
            {
                movie.Title = "Title_0" + DateTime.Now.ToString("dd.mm.yyyy mm:hh:ffff");
                movie.Description = "Description_0" + DateTime.Now.ToString("dd.mm.yyyy mm:hh:ffff");
                movie.Name = "Name_0" + DateTime.Now.ToString("dd.mm.yyyy mm:hh:ffff");
                await _movieWriteRepository.SaveAsync(movie);
                await _movieWriteRepository.SaveChangesAsync();
            }
            
            return new() { Count = request.Count };
        }
    }
}
