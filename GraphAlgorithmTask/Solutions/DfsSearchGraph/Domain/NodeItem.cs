public class NodeItem(int value)
{
    private readonly List<NodeItem> children = new();

    public int Value { get; private set; } = value;

    public IReadOnlyCollection<NodeItem> Children => children;

    public int Level { get; private set; }

    public void AddChildren(params NodeItem[] children) =>
        this.children.AddRange(children);

    public void SetLevel(int level) =>
        Level = level;
}