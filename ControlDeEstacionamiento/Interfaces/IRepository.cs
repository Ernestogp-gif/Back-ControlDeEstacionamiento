namespace ControlDeEstacionamiento.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        
        Task<T> GetById(string id);
        
        Task<int> Create(T entity);
        
        Task<T> Update(string id, T entity);
        
        Task<bool> Delete(string id);
        
    }
}
