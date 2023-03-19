using UASLP.Objetos.List.Interfaces;

namespace UASLP.Objetos.List.LinkedList
{
    internal class ULinkedList<T> : Interfaces.IUList<T>
    {
        private Node<T>? head;
        private Node<T>? tail;
        private int size;

        public void AddAtTail(T data)
        {

            Node<T> node = new(data);
            node.previous = tail;

            if (IsEmpty())
            {
                head = node;
            }
            else
            {
                tail.next = node;
            }
            tail = node;
            size++;

        }

        public void AddAtFront(T data)
        {

            Node<T> node = new(data);
            node.next = head;

            if (IsEmpty())
            {
                tail = node;
            }
            else
            {
                head.previous = node;
            }
            head = node;
            size++;

        }

        public void Remove(int index)
        {

            if (IsInvalidIndex(index))
            {
                return; //error handling
            }

            //cast is needed to make use of getCurrentNode internal method
            LinkedListIterator<T> iterator = (LinkedListIterator<T>)GetIterator();
            int current_index = 0;

            while (iterator.HasNext() && current_index != index)
            {
                iterator.Next();
                current_index++;
            }
            DeleteNode(iterator.GetCurrentNode());
            size--;

        }

        public void RemoveAll()
        {

            LinkedListIterator<T> iterator = (LinkedListIterator<T>)GetIterator();

            while (iterator.HasNext())
            {
                Node<T> temp = iterator.GetCurrentNode();
                iterator.Next();
                DeleteNode(temp);
            }
            size = 0;

        }

        public void SetAt(int index, T data)
        {

            if (IsInvalidIndex(index))
            {
                return; //error handling
            }

            LinkedListIterator<T> iterator = (LinkedListIterator<T>)GetIterator();
            int current_index = 0;

            while (iterator.HasNext() && current_index != index)
            {
                iterator.Next();
                current_index++;
            }

            iterator.GetCurrentNode().data = data;

        }

        public T? GetAt(int index)
        {

            if (IsInvalidIndex(index))
            {
                return default; //error handling
            }

            IIterator<T> iterator = GetIterator();
            int current_index = 0;

            while (iterator.HasNext() && current_index != index)
            {
                iterator.Next();
                current_index++;
            }
            return iterator.Next();

        }

        public void RemoveAllWithValue(T data)
        {

            LinkedListIterator<T> iterator = (LinkedListIterator<T>)GetIterator();

            while (iterator.HasNext())
            {
                Node<T> temp = iterator.GetCurrentNode();
                if (temp.data.Equals(data))
                { //compare value
                    DeleteNode(temp);
                    size--;
                }
                iterator.Next();
            }

        }

        public int GetSize()
        {
            return size;
        }

        public IIterator<T> GetIterator()
        {
            return new LinkedListIterator<T>(head);
        }

        public bool IsEmpty()
        {
            return head == null || tail == null;
        }

        //internal methods

        private bool IsInvalidIndex(int index)
        {
            return index >= size || index < 0;
        }

        private void DeleteNode(Node<T> node)
        {

            //node doesn't exists
            if (node == null)
            {
                return;
            }

            //list contains single element
            if (head == node && tail == node)
            {
                head = null;
                tail = null;
                return;
            }

            //delete first element
            if (head == node)
            {
                head = head.next;
                head.previous = null;
                return;
            }

            //delete last element
            if (tail == node)
            {
                tail = tail.previous;
                tail.next = null;
                return;
            }

            //delete any element
            node.previous.next = node.next;
            node.next.previous = node.previous;

        }
    }
}
