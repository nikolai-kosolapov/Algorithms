namespace Graphs.Algorithms
{
    using System.Collections.Generic;
    using Graphs.Models;

    public abstract class DFSVisitor<T> : GraphVisitor<T>, IGraphVisitor<T>
    {
        private List<Node<T>> visited = new List<Node<T>>();

        private bool result = false;

        public override void Visit(Node<T> node)
        {
            this.result = this.VisitNode(node);
            this.visited.Add(node);

            foreach (var child in node.Adjacents)
            {
                if (this.result)
                {
                    return;
                }

                if (!this.visited.Contains(child))
                {
                    this.Visit(child);
                }
            }

        }
    }
}
