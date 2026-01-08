using QuikGraph;
using QuikGraph.Algorithms;

public class QuickGraphSolution : ISolution
{
    public void Execute() =>
        ExecuteInternal();

    public IReadOnlyCollection<IEnumerable<int>> ExecuteInternal()
    {
        BidirectionalGraph<int, Edge<int>> graph = CreateGraph();

        IEnumerable<int> sortedGraph = graph.TopologicalSort().Reverse();
        var depth = new Dictionary<int, int>();
        foreach (var vertix in sortedGraph)
        {
            depth[vertix] = graph.OutEdges(vertix).Any()
                ? graph.OutEdges(vertix).Max(e => depth[e.Target]) + 1
                : 0;
        }
        var groups = depth
           .GroupBy(kv => kv.Value)
           .OrderBy(g => g.Key)
           .Select(g => g.Select(kv => kv.Key))
           .ToList();

        Console.WriteLine("Topological Sort Result:");
        for (int i = 0; i < groups.Count; i++)
        {
            Console.WriteLine($"Level {i}: {string.Join(", ", groups[i])}");
        }
        return groups.AsReadOnly();
    }

    private static BidirectionalGraph<int, Edge<int>> CreateGraph()
    {
        var graph = new BidirectionalGraph<int, Edge<int>>();

        graph.AddVerticesAndEdge(new Edge<int>(4, 2));
        graph.AddVerticesAndEdge(new Edge<int>(4, 6));
        graph.AddVerticesAndEdge(new Edge<int>(4, 5));
        graph.AddVerticesAndEdge(new Edge<int>(4, 1));
        graph.AddVerticesAndEdge(new Edge<int>(4, 3));
        graph.AddVerticesAndEdge(new Edge<int>(3, 2));
        graph.AddVerticesAndEdge(new Edge<int>(2, 1));
        graph.AddVerticesAndEdge(new Edge<int>(5, 1));

        return graph;
    }
}