namespace InitialTask.LinkedList
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }

        public T Data { get; }
        public Node<T> Next;
    }
}