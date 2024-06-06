using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using PustokAB204.Business.DTOs.BookDTOs;
using PustokAB204.Business.Exceptions;
using PustokAB204.Business.Extensions;
using PustokAB204.Business.Services.Abstracts;
using PustokAB204.Core.Models;
using PustokAB204.Core.RepositoryAbstracts;

namespace PustokAB204.Business.Services.Concretes;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IWebHostEnvironment _env;
    private readonly IGenreRepository _genreRepository;
    private readonly IMapper _mapper;
    public BookService(IBookRepository bookRepository, IWebHostEnvironment env, IGenreRepository genreRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _env = env;
        _genreRepository = genreRepository;
        _mapper = mapper;
    }


    public async Task AddAsync(BookCreateDTO createDTO)
    {
        if (createDTO.ImageFile == null) throw new Exceptions.FileNotFoundException("file not found!");
        var existGenre = _genreRepository.Get(x => x.Id == createDTO.GenreId);
        if (existGenre == null)
            throw new EntityNotFoundException("genre not found!");
        //Book book = new Book
        //{
        //    Name = createDTO.Name,
        //    Description = createDTO.Description,
        //    DiscountPercent = createDTO.DiscountPercent,
        //    Price = createDTO.Price,
        //    GenreId = createDTO.GenreId,
        //};

        Book book = _mapper.Map<Book>(createDTO);

        book.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/books", createDTO.ImageFile);
        await _bookRepository.AddAsync(book);
        await _bookRepository.CommitAsync();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public BookGetDTO Get(Func<Book, bool>? func = null)
    {
        var book = _bookRepository.Get(func, "Genre", "Author"); 

        BookGetDTO bookGetdto = _mapper.Map<BookGetDTO>(book);

        return bookGetdto;
    }

    public IEnumerable<BookGetDTO> GetAll(Func<Book, bool>? func = null)
    {
        var books = _bookRepository.GetAll(func, "Genre", "Author"); 
        IEnumerable<BookGetDTO> booksDto = _mapper.Map<IEnumerable<BookGetDTO>>(books);

        return booksDto;
    }

    public void Update(BookUpdateDTO updateDTO)
    {
        var oldBook = _bookRepository.Get(x=> x.Id == updateDTO.Id);

        if (oldBook == null)
            throw new EntityNotFoundException("Book tapilmadi!");

        if(updateDTO.ImageFile != null)
        {
            if (updateDTO.ImageFile.ContentType != "image/png")
                throw new ImageContentTypeException("File formati png olabiler!");

            Helper.DeleteFile(_env.WebRootPath, @"uploads\books", oldBook.ImageUrl);

            oldBook.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\books", updateDTO.ImageFile); 
        }

        oldBook.CostPrice = oldBook.CostPrice;
        oldBook.Price = updateDTO.Price;
        oldBook.DiscountPercent = updateDTO.DiscountPercent;
        oldBook.AuthorId = updateDTO.AuthorId;
        oldBook.GenreId = updateDTO.GenreId;
        oldBook.Name = updateDTO.Name;
        oldBook.Description = updateDTO.Description;

        _bookRepository.Commit();
    }
}
