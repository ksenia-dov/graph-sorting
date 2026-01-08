public static class DataSeeder
{
    public static Graph SeedGraph()
    {
        NodeItem root = new(4);
        NodeItem child3 = new(3);
        NodeItem child2 = new(2);
        NodeItem child5 = new(5);
        NodeItem child6 = new(6);
        NodeItem child1 = new(1);

        root.AddChildren(child3, child2, child5, child1, child6);
        child3.AddChildren(child2);
        child2.AddChildren(child1);
        child5.AddChildren(child1);

        return new Graph(root);
    }
}