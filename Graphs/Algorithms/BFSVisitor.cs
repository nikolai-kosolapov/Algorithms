// <copyright file="BFSVisitor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Graphs.Algorithms
{
    using System.Collections.Generic;
    using Graphs.Models;

    public abstract class BFSVisitor<T> : GraphVisitor<T>
    {
        private Queue<Node<T>> queue = new Queue<Node<T>>();
        private List<Node<T>> visited = new List<Node<T>>();

        public override void Visit(Node<T> node)
        {
            this.queue.Enqueue(node);
            this.visited.Add(node);

            while (this.queue.Count > 0)
            {
                var item = this.queue.Dequeue();
                this.VisitNode(item);

                foreach (var child in item.Adjacents)
                {
                    if (!this.visited.Contains(item))
                    {
                        this.queue.Enqueue(child);
                        this.visited.Add(child);
                    }
                }

                this.visited.Add(item);
            }
        }
    }
}