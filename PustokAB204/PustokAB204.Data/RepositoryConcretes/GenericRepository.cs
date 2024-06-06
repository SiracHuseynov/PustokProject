using Microsoft.EntityFrameworkCore;
using PustokAB204.Core.Models;
using PustokAB204.Core.RepositoryAbstracts;
using PustokAB204.Data.DAL;

namespace PustokAB204.Data.RepositoryConcretes;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
{
    private readonly AppDbContext _appDbContext;
    public GenericRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddAsync(T entity)
    {
        await _appDbContext.Set<T>().AddAsync(entity);
    }

    public int Commit()
    {
        return _appDbContext.SaveChanges();
    }

    public async Task<int> CommitAsync()
    {
        return await _appDbContext.SaveChangesAsync();
    }

    public void Delete(T entity)
    {
        _appDbContext.Set<T>().Remove(entity);
    }

    public List<T> GetAll(Func<T, bool>? func = null, params string[]? includes)
    {
        var entity = _appDbContext.Set<T>().AsQueryable();
        if (includes != null)
        {
            foreach (var item in includes)
            {
                entity = entity.Include(item);
            }
        }

        return func == null ?
               entity.ToList() :
               entity.Where(func).ToList();
    }

    public T Get(Func<T, bool>? func = null, params string[]? includes)
    {
        var entity = _appDbContext.Set<T>().AsQueryable();
        if (includes != null)
        {
            foreach (var item in includes)
            {
                entity = entity.Include(item);
            }
        }


        return func == null ?
               entity.FirstOrDefault() :
               entity.FirstOrDefault(func);
    }
}
