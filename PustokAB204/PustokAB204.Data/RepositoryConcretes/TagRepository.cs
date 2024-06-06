using PustokAB204.Core.Models;
using PustokAB204.Core.RepositoryAbstracts;
using PustokAB204.Data.DAL;

namespace PustokAB204.Data.RepositoryConcretes;

public class TagRepository : GenericRepository<Tag>, ITagRepository
{
    public TagRepository(AppDbContext appDbContext) : base(appDbContext) { }
}
