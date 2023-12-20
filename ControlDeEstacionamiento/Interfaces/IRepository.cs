namespace ControlDeEstacionamiento.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        
        Task<T> GetById(string id);
        /*
        Task<T> Create(T entity);
        Task<T> Update(int id, T entity);
        Task<bool> Delete(int id);
        */
    }
}
