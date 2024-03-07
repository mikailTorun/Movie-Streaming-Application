using MediatR;

namespace MovieStream.Application.Features.Contents.Commands
{
    public class GenerateRandomMovieCommandRequest : IRequest<GenerateRandomMovieCommandResponse>
    {
        public int Count { get; set; }
    }
}
