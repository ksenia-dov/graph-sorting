public class Graph
{
    public NodeItem Root { get; private set; }

    public Graph(NodeItem root)
    {
        if (root == null)
        {
            throw new InvalidOperationException("Graph root cannot be null.");
        }
        Root = root;
    }

    public IReadOnlyCollection<IReadOnlyCollection<int>> Sort()
    {
        var levels = new Dictionary<int, List<int>>();
        var visitedNodes = new Dictionary<NodeItem, int>();

        int ComputeLevel(NodeItem node)
        {
            if (visitedNodes.TryGetValue(node, out var nodeLevel)) return nodeLevel;

            int level = (node.Children == null || node.Children.Count == 0)
                ? 0
                : node.Children.Max(child => ComputeLevel(child)) + 1;

            visitedNodes[node] = level;
            node.SetLevel(level);

            if (!levels.TryGetValue(level, out var list))
            {
                levels[level] = list = new List<int>();
            }

            list.Add(node.Value);

            return level;
        }

        ComputeLevel(Root);

        var maxLevel = levels.Keys.Any() ? levels.Keys.Max() : -1;
        var result = new List<IReadOnlyCollection<int>>();

        for (int i = 0; i <= maxLevel; i++)
        {
            if (levels.TryGetValue(i, out var values))
            {
                values.Sort();
                result.Add(values);
            }
            else
            {
                result.Add(Array.Empty<int>());
            }
        }

        return result.AsReadOnly();
    }
}