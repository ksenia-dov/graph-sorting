public static class GraphDataSeeder
{
    public static Graph SeedGraph()
    {
        NodeItem root = new NodeItem(4);
        NodeItem child3 = new NodeItem(3);
        NodeItem child2 = new NodeItem(2);
        NodeItem child5 = new NodeItem(5);
        NodeItem child6 = new NodeItem(6);
        NodeItem child1 = new NodeItem(1);

        root.AddChild(child3);
        root.AddChild(child2);
        root.AddChild(child5);
        root.AddChild(child1);
        root.AddChild(child6);

        child3.AddChild(child2);

        child2.AddChild(child1);

        child5.AddChild(child1);

        return new Graph(root);
    }
}