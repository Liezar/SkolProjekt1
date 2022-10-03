namespace SkolProjekt1
{
    public interface IStorage<T> where T : class
    {
        List<T> Load();
        void Save(List<T> obj);
    }
}