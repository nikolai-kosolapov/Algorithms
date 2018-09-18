// <copyright file="IGraphVisitor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Graphs.Algorithms
{
    using Graphs.Models;

    public interface IGraphVisitor<T>
    {
        void Visit(Node<T> node);
    }
}
