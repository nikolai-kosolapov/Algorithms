using Graphs.Parsers;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace AlgorithmsTest.Graphs
{
    public class GraphParserTest
    {
        [Fact]
        public void Should_ParseString_to_Graph()
        {
            // Arrange
            
            // Load strings from the file
            var path = "./Graphs/TestGraph.kg";
            var str = File.ReadAllLines(path);
            
            // Create parser
            var parser = new GraphParser();

            // Act
            var result = parser.GetStringGraphByString(str);

            // Assert
            Assert.Equal(14, result.Count);
            Assert.Equal(3, result.Where(x => x.Value == "16").Count());
            var testNode = result.First(x => x.Value == "7");
            Assert.Equal(5, testNode.Adjacents.Count);
            Assert.Contains(testNode.Adjacents, x => x.Value == "4");
        }

        [Fact]
        public void Should_ThrowException_if_AraryHasLessOneString()
        {
            // Arrange
            var path = "./Graphs/TestGraph.kg";
            var str = File.ReadAllLines(path).Take(1).ToArray();

            // Create parser
            var parser = new GraphParser();

            // Act
            var ex = Assert.Throws<Exception>( () => parser.GetStringGraphByString(str));

            // Assert
            Assert.Equal("Array should have more than one string", ex.Message);
        }

        [Fact]
        public void Should_WorkWithEmptyStrings()
        {
            // Arrange

            // Load strings from the file
            var path = "./Graphs/TestGraph2.kg";
            var str = File.ReadAllLines(path);

            // Create parser
            var parser = new GraphParser();

            // Act
            var result = parser.GetStringGraphByString(str);

            // Assert
            Assert.Equal(32, result.Count);
        }
    }
}
