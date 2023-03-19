namespace UASLP.Objetos.List.Interfaces
{
    public interface IUList<T>
    {
        void AddAtTail(T data);
        void AddAtFront(T data);
        void Remove(int index);
        void RemoveAll();
        void SetAt(int index, T data);
        T? GetAt(int index);
        void RemoveAllWithValue(T data);
        int GetSize();
        bool IsEmpty();
        IIterator<T> GetIterator();
    }
}
