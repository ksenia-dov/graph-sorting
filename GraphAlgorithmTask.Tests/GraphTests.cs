using System;
using System.Linq;
using Xunit;

public class GraphTests
{
    [Fact]
    public void Sort_ThrowsInvalidOperation_ForNullRoot()
    {
        Assert.Throws<InvalidOperationException>(() => new Graph(null));
    }

    [Fact]
    public void Sort_ComputesLevels_ForSimpleTree()
    {
        var graph = GraphDataSeeder.SeedGraph();

        var result = graph.Sort();

        var expected = new[]
        {
            new[] { 1, 6},
            new[] { 2, 5 },
            new[] { 3 },
            new[] { 4 }
        };

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Sort_HandlesBranchingGraph()
    {
        var n1 = new NodeItem(1);
        var n2 = new NodeItem(2);
        var n3 = new NodeItem(3);
        var n4 = new NodeItem(4);

        n3.AddChild(n1);
        n3.AddChild(n2);
        n4.AddChild(n2);
        n4.AddChild(n3);

        var graph = new Graph(n4);

        var result = graph.Sort();

        var expected = new[]
        {
            new[] { 1, 2 },
            new[] { 3 },
            new[] { 4 }
        };

        Assert.Equal(expected, result);
    }
}
