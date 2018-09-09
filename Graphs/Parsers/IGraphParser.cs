namespace Graphs.Parsers
{
    using System.Collections.Generic;
    using Graphs.Models;

    public interface IGraphParser
    {
        IList<Node<string>> GetStringGraphByString(string[] str);
    }
}
