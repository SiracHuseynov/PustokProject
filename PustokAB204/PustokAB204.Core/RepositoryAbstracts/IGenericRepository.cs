using PustokAB204.Core.Models;

namespace PustokAB204.Core.RepositoryAbstracts;

public interface IGenericRepository<T> where T : BaseEntity, new()
{
    Task AddAsync(T entity); 
    void Delete(T entity);
    T Get(Func<T, bool>? func = null, params string[]? includes);
    List<T> GetAll(Func<T, bool>? func = null, params string[]? includes);
    int Commit();
    Task<int> CommitAsync();
}
