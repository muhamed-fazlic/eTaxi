namespace eTaxi.Application.Contracts.Persistence
{
    public interface IGenericRepository<T, TSearch> where T : class where TSearch : class
    {
        Task<IReadOnlyList<T>> GetAsync();
        Task<IReadOnlyList<T>> GetAsync(TSearch search = null);
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
