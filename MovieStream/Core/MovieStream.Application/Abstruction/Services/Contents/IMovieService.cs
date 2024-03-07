using MovieStream.Application.Features.Contents.Commands;
using MovieStream.Application.Features.Contents.Queries;
using MovieStream.Application.Models.Contents;
using MovieStream.Domain.Entities;

namespace MovieStream.Application.Abstruction.Services.Contents
{
    public interface IMovieService
    {
        Task<GetMovieQueryResponse> GetMovieAsync(GetMovieQueryRequest getMovieQueryRequest);
        Task<List<Movie>> GetAllMovieAsync();
        Task<GetFilteredMovieQueryResponse> GetFilteredMovieAsync(GetFilteredMovieQueryRequest request);
        Task<MovieModel> MarkMovie(Guid movieId,Guid userId);
    }
}
