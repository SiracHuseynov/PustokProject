using PustokAB204.Business.Exceptions;
using PustokAB204.Business.Services.Abstracts;
using PustokAB204.Core.Models;
using PustokAB204.Core.RepositoryAbstracts;

namespace PustokAB204.Business.Services.Concretes;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;
    public GenreService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }
    public async Task AddGenreAsync(Genre genre)
    {
        if (!_genreRepository.GetAll().Any(x => x.Name == genre.Name))
        {
            await _genreRepository.AddAsync(genre);
            await _genreRepository.CommitAsync();
        }
        else
        {
            throw new DuplicateGenreException("Eyni adli janr yarana bilmez!");
        }
    }

    public void DeleteGenre(int id)
    {
        var existGenre = _genreRepository.Get(x => x.Id == id);
        if (existGenre == null) throw new EntityNotFoundException("Bele bir janr yoxdur!");

        _genreRepository.Delete(existGenre);
        _genreRepository.Commit();
    }

    public List<Genre> GetAllGenres(Func<Genre, bool>? func = null)
    {
        return _genreRepository.GetAll(func);
    }

    public Genre GetGenre(Func<Genre, bool>? func = null)
    {
        return _genreRepository.Get(func);
    }

    public void UpdateGenre(int id, Genre newGenre)
    {
        var oldGenre = _genreRepository.Get(x => x.Id == id);
        if (oldGenre == null) throw new EntityNotFoundException("bele bir janr yoxdur!");

        if (!_genreRepository.GetAll().Any(x => x.Name == newGenre.Name && x.Id != id))
        {
            oldGenre.Name = newGenre.Name;
            _genreRepository.Commit();
        }
        else
        {
            throw new DuplicateGenreException("Eyni adli janr yarana bilmez!");
        }
    }
}
