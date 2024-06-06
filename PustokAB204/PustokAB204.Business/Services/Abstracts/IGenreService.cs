using PustokAB204.Core.Models;

namespace PustokAB204.Business.Services.Abstracts;

public interface IGenreService
{
    Task AddGenreAsync(Genre genre);
    void DeleteGenre(int id);
    void UpdateGenre(int id, Genre newGenre);

    Genre GetGenre(Func<Genre, bool>? func = null);
    List<Genre> GetAllGenres(Func<Genre, bool>? func = null);
}
