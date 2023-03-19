using UASLP.Objetos.List.Interfaces;

namespace UASLP.Objetos.List.LinkedList
{
    public class LinkedListIterator<T> : IIterator<T>
    {
        private Node<T>? currentNode;

        internal LinkedListIterator(Node<T>? head)
        {
            currentNode = head;
        }

        public bool HasNext()
        {
            return currentNode != null;
        }

        public T? Next()
        {
            T? data = currentNode.data;
            currentNode = currentNode.next;
            return data;
        }

        public bool HasPrevious()
        {
            return currentNode != null;
        }

        public T? Previous()
        {
            T? data = currentNode.data;
            currentNode = currentNode.previous;
            return data;
        }

        //internal methods

        internal Node<T>? GetCurrentNode()
        {
            return currentNode;
        }
    }
}
