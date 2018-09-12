using Graphs.Algorithms;
using Graphs.Models;
using Graphs.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace AlgorithmsTest.Graphs
{
    public class DFSVisitorTest
    {
        [Fact]
        public void Should_VisitAllNodes()
        {
            // Arrange

            // Load strings from the file
            var path = "./Graphs/TestGraph2.kg";
            var str = File.ReadAllLines(path);

            // Create parser
            var parser = new GraphParser();

            // Parse the graph
            var graph = parser.GetStringGraphByString(str);

            // Create visitor
            var visitor = new DFSVisitorCounter();

            // Act
            visitor.Visit(graph[0]);

            // Assert
            Assert.Equal(32, visitor.Count);

        }

        private class DFSVisitorCounter : DFSVisitor<string>
        {
            public int Count = 0;

            protected override bool VisitNode(Node<string> node)
            {
                this.Count++;
                return false;
            }
        }
    }
}
