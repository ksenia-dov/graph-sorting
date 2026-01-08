List<ISolution> solutions = [new QuickGraphSolution(), new DFSSearchGraphSolution()];

Console.WriteLine("Running Graph Solutions...");
solutions.ForEach(solution => solution.Execute());