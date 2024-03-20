namespace bobs_burger_api.Repository
{
    public interface IRepository<T>
    {
        Task<ICollection<T>> GetAll();
        Task<T?> Get(int id);
        Task<T?> Get(string id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T?> Delete(int id);
        Task<T?> Delete(string id);
    }
}
