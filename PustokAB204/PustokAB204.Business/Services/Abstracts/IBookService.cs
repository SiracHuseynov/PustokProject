using PustokAB204.Business.DTOs.BookDTOs;
using PustokAB204.Core.Models;

namespace PustokAB204.Business.Services.Abstracts;

public interface IBookService
{
    void Delete(int id);
    Task AddAsync(BookCreateDTO createDTO);
    void Update(BookUpdateDTO updateDTO);


    BookGetDTO Get(Func<Book, bool>? func = null);
    IEnumerable<BookGetDTO> GetAll(Func<Book, bool>? func = null);
}
