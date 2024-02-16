namespace MiniCRMCore.Interfaces.IServices
{
    public interface IService<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        bool IfExist(T obj);
    }
}
