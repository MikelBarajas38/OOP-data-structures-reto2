using UASLP.Objetos.List.Interfaces;

namespace UASLP.Objetos.List.ArrayList
{
    public class UArrayList<T> : Interfaces.IUList<T>
    {
        private const int INITIAL_SIZE = 2;
        private T[] array;
        private int size;

        public UArrayList()
        {
            array = new T[INITIAL_SIZE];
        }

        public void AddAtTail(T data)
        {

            if (IsFull())
            {
                IncreaseSize();
            }

            array[size] = data;
            size++;
        }

        public void AddAtFront(T data)
        {

            if (IsFull())
            {
                IncreaseSize();
            }

            IIterator<T> iterator = GetIteratorAt(size - 1);
            int currentIndex = size;

            while (iterator.HasPrevious())
            {
                array[currentIndex] = iterator.Previous();
                currentIndex--;
            }

            array[0] = data;
            size++;
        }

        public void Remove(int index)
        {

            if (IsInvalidIndex(index))
            {
                return; //error handling
            }

            for (int i = index; i < size - 1; i++)
            {
                array[i] = array[i + 1];
            }

            size--;

            if (ShouldDecrease())
            {
                DecreaseSize();
            }
        }

        //logical deletion, taking advantage of garbage collector
        public void RemoveAll()
        {
            array = new T[INITIAL_SIZE];
            size = 0;
        }

        public void SetAt(int index, T data)
        {

            if (IsInvalidIndex(index))
            {
                return; //error handling
            }

            array[index] = data;

        }

        public T? GetAt(int index)
        {

            if (IsInvalidIndex(index))
            {
                return default; //error handling
            }

            return array[index];

        }

        public void RemoveAllWithValue(T data)
        {

            for (int currentIndex = size - 1; currentIndex >= 0; currentIndex--)
            {
                if (array[currentIndex].Equals(data))
                {
                    Remove(currentIndex);
                }
            }

        }

        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public IIterator<T> GetIterator()
        {
            return new ArrayListIterator<T>(this);
        }

        //internal methods

        private int GetMaxCapacity()
        {
            return array.Length;
        }

        private void IncreaseSize()
        {
            T[] newArray = new T[array.Length * 2];

            //System.arraycopy(array, 0, newArray, 0, size);
            IIterator<T> iterator = GetIterator();
            int newIndex = 0;

            while (iterator.HasNext())
            {
                newArray[newIndex] = iterator.Next();
                newIndex++;
            }

            array = newArray;
        }

        private void DecreaseSize()
        {
            T[] newArray = new T[array.Length / 2];

            //System.arraycopy(array, 0, newArray, 0, size);
            IIterator <T> iterator = GetIterator();
            int newIndex = 0;

            while (iterator.HasNext())
            {
                newArray[newIndex] = iterator.Next();
                newIndex++;
            }

            array = newArray;
        }

        private bool IsFull()
        {
            return size == array.Length;
        }

        private bool ShouldDecrease()
        {
            return size < array.Length / 4; //better amortized complexity for (hypothetical) pop/push use cases.
        }

        private bool IsInvalidIndex(int index)
        {
            return index >= size || index < 0;
        }

        private IIterator<T> GetIteratorAt(int index)
        {
            return new ArrayListIterator<T>(this, index);
        }
    }
}
