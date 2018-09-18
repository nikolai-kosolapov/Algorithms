namespace Graphs.Algorithms
{
    using Graphs.Models;

    public abstract class GraphVisitor<T> : IGraphVisitor<T>
    {
        public abstract void Visit(Node<T> node);

        protected abstract bool VisitNode(Node<T> node);
    }
}
