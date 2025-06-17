using System.Collections.Generic;
using System.Linq;
using TenThousand;
using TenThousand.Rules;

class DiceRoller
{
    private static Random rng = new Random();

    public static List<int> RollDice(int numberOfDice = 6, int delay = 200)
    {
        List<int> results = new List<int>();

        Console.WriteLine("🎲 Alea iacta est... or something along those lines.\n");
        for (int i = 0; i < numberOfDice; i++)
        {
            int roll = rng.Next(1, 7);
            results.Add(roll);
            Console.Write($"Die {i + 1}: ");
            Thread.Sleep(delay);
            Console.WriteLine(roll);
        }

        return results;
    }
}

class Program
{
    static void Main(string[] args)
    {
        new Game().Start();
        Console.WriteLine("This is a dice game. You are to throw your dice enough times to score 10.000 points.");
        Console.WriteLine("");
        Console.WriteLine("Choose mode: (1) Play    (2) Toggle Test Mode");

        var choice = Console.ReadLine();

        List<int> diceRoll;

        if (choice == "2")
        {
            Console.WriteLine("Enter 6 values (1-6), separate with space (e.g. 1 2 3 4 5 6):");
            var input = Console.ReadLine();
            diceRoll = input.Split(' ')
                            .Select(x => int.Parse(x))
                            .ToList();
        }
        else
        {
            Console.WriteLine("\nNow, cross your fingers and throw them bones like your life depended on them.");
            diceRoll = DiceRoller.RollDice();
        }
        // Console.WriteLine("Simple enough, isn't it!? Now pick a set of dice.");

            // Player chooses from five different sets
            // Console.WriteLine("");
            // Console.WriteLine("Are you really really sure, that's a set you'd bet your life on?");
            // Console.WriteLine("");
            // Player chooses to move forward or go back to chose another set

            // Console.WriteLine("Well, fair enough. That set may be as good as any. Are we ready then?");
            // Console.WriteLine("");
            //Console.WriteLine("Now, cross your fingers and throw them bones like your life depended on it...");

        
        Console.WriteLine("\nYou rolled:");
        for (int i = 0; i < diceRoll.Count; i++)
        {
            Console.WriteLine($"Die {i + 1}: {diceRoll[i]}");
        }

        int score = ScoreCalculator.CalculateScore(diceRoll);
        Console.WriteLine($"\nYou scored: {score} points.");
        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
}
