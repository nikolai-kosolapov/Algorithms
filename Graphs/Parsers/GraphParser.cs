namespace Graphs.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Graphs.Models;

    public class GraphParser : IGraphParser
    {
        public IList<Node<string>> GetStringGraphByString(string[] str)
        {
            // get collection of nodes
            if (str.Length <= 1)
            {
                throw new Exception("Array should have more than one string");
            }

            var nodeValuesStr = str[0];
            var nodes = GetCollectionOfNodes(nodeValuesStr).ToArray();

            // create relationships
            CreateRelationShips(str, nodes);

            return nodes;
        }

        private static void CreateRelationShips(string[] str, Node<string>[] nodes)
        {
            for (var i = 1; i < str.Length; i++)
            {
                var adjacentsStr = str[i];
                var relations = adjacentsStr.Split(' ').Select(x => int.Parse(x));
                foreach (var relation in relations)
                {
                    nodes[i - 1].Adjacents.Add(nodes[relation]);
                    nodes[relation].Adjacents.Add(nodes[i - 1]);
                }
            }
        }

        private static IList<Node<string>> GetCollectionOfNodes(string nodeValuesStr)
        {
            var nodeValues = nodeValuesStr.Split(' ');
            var nodes = new List<Node<string>>();
            foreach (var value in nodeValues)
            {
                nodes.Add(new Node<string>(value));
            }

            return nodes;
        }
    }
}
