using RestEase;
using System.ComponentModel.DataAnnotations;
using VHub.Media.Api.Contracts.Movies.Requests;
using VHub.Media.Api.Contracts.Movies.Responses;

namespace VHub.Media.Api.Contracts;


[BasePath("media/movies")]
public interface IMoviesController
{
    [Post("new")]
    Task<string> CreateMovieWithPersonsAsync(
        [Required, Body] CreateMovieRequest request, CancellationToken cancellationToken);

    [Put("update")]
    Task UpdateMovieAsync(
        [Required, Body] UpdateMovieRequest request, CancellationToken cancellationToken);

    [Delete("delete/{id}")]
    Task DeleteMovieByIdAsync(
        [Required, Path] string id, CancellationToken cancellationToken);

    [Get("{id}")]
    Task<GetMovieResponse> GetMovieByIdAsync(
        [Required, Path] string id, CancellationToken cancellationToken);

    [Post]
    Task<List<GetMovieResponse>> GetMoviesByFilterAsync(
        [Body] GetMoviesByFilterRequest filter, CancellationToken cancellationToken);
}
