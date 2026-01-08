using System;
using System.Collections.Generic;
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
        IReadOnlyCollection<IReadOnlyCollection<int>> expected = [[1, 6], [2, 5], [3], [4]];
        var graph = DataSeeder.SeedGraph();

        var actual = graph.Sort();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Sort_HandlesBranchingGraph()
    {
        IReadOnlyCollection<IReadOnlyCollection<int>> expected = [[1, 2], [3], [4]];
        var n1 = new NodeItem(1);
        var n2 = new NodeItem(2);
        var n3 = new NodeItem(3);
        var n4 = new NodeItem(4);
        n3.AddChildren(n1, n2);
        n4.AddChildren(n2, n3);
        var graph = new Graph(n4);

        var actual = graph.Sort();

        Assert.Equal(expected, actual);
    }
}
