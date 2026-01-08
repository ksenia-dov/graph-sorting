public class NodeItem(int value)
{
    public int Value { get; private set; } = value;
    public List<NodeItem> Children { get; private set; } = new List<NodeItem>();
    public int Level { get; private set; }

    public void AddChild(NodeItem child)
    {
        ArgumentNullException.ThrowIfNull(child);
        Children.Add(child);
    }

    public void SetLevel(int level)
    {
        Level = level;
    }
}