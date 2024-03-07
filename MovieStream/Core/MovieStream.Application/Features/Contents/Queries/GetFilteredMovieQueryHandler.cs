using MediatR;
using MovieStream.Application.Abstruction.Services.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStream.Application.Features.Contents.Queries
{
    public class GetFilteredMovieQueryHandler : IRequestHandler<GetFilteredMovieQueryRequest, GetFilteredMovieQueryResponse>
    {
        private readonly IMovieService _movieService;

        public GetFilteredMovieQueryHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<GetFilteredMovieQueryResponse> Handle(GetFilteredMovieQueryRequest request, CancellationToken cancellationToken)
        {
            return await _movieService.GetFilteredMovieAsync(request);
        }
    }
}
