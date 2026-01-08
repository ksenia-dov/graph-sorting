public class DFSSearchGraphSolution : ISolution
{
    public void Execute()
    {
        var graph = DataSeeder.SeedGraph();
        var sortedLevels = graph.Sort();

        Console.WriteLine("DFS Sort Result:");
        for (int i = 0; i < sortedLevels.Count; i++)
        {
            Console.WriteLine($"Level {i}: {string.Join(", ", sortedLevels.ElementAt(i))}");
        }
    }
}