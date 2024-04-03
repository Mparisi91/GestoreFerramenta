namespace Gestione_Ferramenta.Repos
{
    public interface IRepo<T>
    {
             
        T? GetById(int id);
        List<T> GetAll();
        bool insert(T t);
        bool update(T t);
        bool delete(int id);

    }
}
