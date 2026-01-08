public static class DFSSearchGraphSolution
{
    public static void Sort()
    {
        var graph =  GraphDataSeeder.SeedGraph();
        var sortedLevels = graph.Sort();

        Console.WriteLine("DFS Sort Result:");

        for (int i = 0; i < sortedLevels.Length; i++)
        {
            Console.WriteLine($"Level {i}: {string.Join(", ", sortedLevels[i])}");
        }
    }
}