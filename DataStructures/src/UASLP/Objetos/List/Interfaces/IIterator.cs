namespace UASLP.Objetos.List.Interfaces
{
    public interface IIterator<T>
    {
        bool HasNext();
        T? Next();
        bool HasPrevious();
        T? Previous();
    }
}
