using System.Linq;
using Xunit;

public class QuickGraphTests
{
    [Fact]
    public void TopologicalSort_ReturnsExpectedLevels()
    {
        var groups = QuickGraphSolution.TopologicalSort();
        int[][] expected =
        {
            new[] { 1, 6 },
            new[] { 2, 5 },
            new[] { 3 },
            new[] { 4 }
        };

        var actualSortedGroups = groups
            .Select(g => g.OrderBy(x => x).ToArray())
            .ToArray();

        var expectedSortedGroups = expected
            .Select(g => g.OrderBy(x => x).ToArray())
            .ToArray();

        Assert.Equal(expectedSortedGroups, actualSortedGroups);
    }

    [Fact]
    public void TopologicalSort_ContainsAllVertices()
    {
        var groups = QuickGraphSolution.TopologicalSort();

        var allVertices = groups.SelectMany(g => g).ToArray();

        int[] expectedVertices = { 1, 2, 3, 4, 5, 6 };

        Assert.Equal(expectedVertices.OrderBy(x => x), allVertices.OrderBy(x => x));
    }

    [Fact]
    public void TopologicalSort_HasNoDuplicateVertices()
    {
        var groups = QuickGraphSolution.TopologicalSort();

        var allVertices = groups.SelectMany(g => g).ToArray();

        Assert.Equal(allVertices.Length, allVertices.Distinct().Count());
    }
}
