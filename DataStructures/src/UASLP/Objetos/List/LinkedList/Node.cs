namespace UASLP.Objetos.List.LinkedList
{
    internal class Node<T>
    {
        internal T? data;
        internal Node<T>? next;
        internal Node<T>? previous;

        internal Node(T data)
        {
            this.data = data;
        }
    }
}
