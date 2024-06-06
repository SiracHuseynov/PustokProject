using PustokAB204.Core.Models;
using PustokAB204.Core.RepositoryAbstracts;
using PustokAB204.Data.DAL;

namespace PustokAB204.Data.RepositoryConcretes;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(AppDbContext appDbContext) : base(appDbContext) { }
}
