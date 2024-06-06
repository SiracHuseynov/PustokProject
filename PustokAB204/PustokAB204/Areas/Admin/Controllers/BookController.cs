using Microsoft.AspNetCore.Mvc;
using PustokAB204.Business.DTOs.BookDTOs;
using PustokAB204.Business.Services.Abstracts;

namespace PustokAB204.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IGenreService _genreService;
        private readonly IAuthorService _authorService;
        public BookController(IBookService bookService, IGenreService genreService, IAuthorService authorService)
        {
            _bookService = bookService;
            _genreService = genreService;
            _authorService = authorService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetAll();

            return View(books);
        }

        public IActionResult Create()
        {
            ViewBag.Genres = _genreService.GetAllGenres();
            ViewBag.Authors = _authorService.GetAll(); 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCreateDTO bookCreateDTO)
        {
            ViewBag.Genres = _genreService.GetAllGenres();
            ViewBag.Authors = _authorService.GetAll();

            if (!ModelState.IsValid)
            {
                return View();
            }
            await _bookService.AddAsync(bookCreateDTO);
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            BookUpdateDTO bookUpdateDTO = new BookUpdateDTO();
            ViewBag.Genres = _genreService.GetAllGenres();
            ViewBag.Authors = _authorService.GetAll();
            var existBook = _bookService.Get(x => x.Id == id);

            if (existBook == null)
                return NotFound();


            bookUpdateDTO.CostPrice = existBook.CostPrice;
            bookUpdateDTO.Price = existBook.Price;
            bookUpdateDTO.DiscountPercent = existBook.DiscountPercent;
            bookUpdateDTO.AuthorId = existBook.Author.Id;
            bookUpdateDTO.GenreId = existBook.Genre.Id; 
            bookUpdateDTO.Name = existBook.Name;
            bookUpdateDTO.Description = existBook.Description;

            return View(bookUpdateDTO);
        }

        [HttpPost]
        public IActionResult Update(BookUpdateDTO bookUpdateDTO)
        {
            ViewBag.Genres = _genreService.GetAllGenres();
            ViewBag.Authors = _authorService.GetAll();

            if (!ModelState.IsValid)
                return View();

            _bookService.Update(bookUpdateDTO);
            return RedirectToAction("Index");
        }
    }
}
