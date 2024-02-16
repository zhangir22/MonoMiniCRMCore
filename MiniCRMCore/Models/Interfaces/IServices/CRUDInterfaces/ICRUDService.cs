namespace MiniCRMCore.Interfaces
{
    public interface ICRUDService<T> 
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
