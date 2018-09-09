namespace Graphs.Models
{
    using System.Collections.Generic;

    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
            this.Adjacents = new List<Node<T>>();
        }

        public T Value { get; set; }

        public IList<Node<T>> Adjacents { get; set; }
    }
}
