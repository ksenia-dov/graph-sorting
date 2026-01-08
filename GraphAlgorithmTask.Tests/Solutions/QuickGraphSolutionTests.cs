using System.Collections.Generic;
using System.Linq;
using Xunit;

public class QuickGraphSolutionTests
{
    private readonly QuickGraphSolution solution;

    public QuickGraphSolutionTests()
    {
        solution = new QuickGraphSolution();
    }

    [Fact]
    public void TopologicalSort_ReturnsExpectedLevels()
    {
        IReadOnlyCollection<IReadOnlyCollection<int>> expected = [[1, 6], [2, 5], [3], [4]];

        var groups = solution.ExecuteInternal();
        var actual = groups
            .Select(g => g.OrderBy(x => x).ToArray())
            .ToArray();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TopologicalSort_ContainsAllVertices()
    {
        int[] expected = { 1, 2, 3, 4, 5, 6 };

        var groups = solution.ExecuteInternal();
        var actual = groups.SelectMany(g => g).OrderBy(x => x).ToArray();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TopologicalSort_HasNoDuplicateVertices()
    {
        var groups = solution.ExecuteInternal();
        var actual = groups.SelectMany(g => g);

        Assert.Equal(6, actual.Count());
    }
}
