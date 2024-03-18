namespace bobs_burger_api.Repository
{
    public interface IRepository<T>
    {
        Task<ICollection<T>> GetAll();
    }
}
