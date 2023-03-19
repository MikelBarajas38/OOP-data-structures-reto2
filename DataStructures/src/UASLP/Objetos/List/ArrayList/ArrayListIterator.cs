using UASLP.Objetos.List.Interfaces;

namespace UASLP.Objetos.List.ArrayList
{
    public class ArrayListIterator<T> : Interfaces.IIterator<T>
    {
        private int currentIndex;
        private readonly UArrayList<T> List;

       public ArrayListIterator(UArrayList<T> NewList)
        {
            List = NewList;
            currentIndex = 0;
        }

        public ArrayListIterator(UArrayList<T> NewList, int index)
        {
            List = NewList;
            currentIndex = index;
        }

        public bool HasNext()
        {
            return currentIndex < List.GetSize();
        }

        public T? Next()
        {
            T? data = List.GetAt(currentIndex);
            currentIndex++;
            return data;
        }

        public bool HasPrevious()
        {
            return currentIndex >= 0;
        }

        public T? Previous()
        {
            T? data = List.GetAt(currentIndex);
            currentIndex--;
            return data;
        }
    }
}
