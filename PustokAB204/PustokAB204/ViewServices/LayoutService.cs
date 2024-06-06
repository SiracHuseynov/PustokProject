using PustokAB204.Business.Services.Abstracts;
using PustokAB204.Core.Models;

namespace PustokAB204.ViewServices
{
    public class LayoutService
    {
        private readonly IGenreService _genreService;

        public LayoutService(IGenreService genreService)
        {
            _genreService = genreService;
        }


        public List<Genre> GetGenres()
        {
            return _genreService.GetAllGenres();
        }
    }
}
