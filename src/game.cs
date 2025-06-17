using System;
using System.Collections.Generic;
using TenThousand.Rules;

namespace TenThousand
{
    public class Game
    {
        private int totalScore = 0;
        private List<int> currentRoll = new();
        private List<int> keptDice = new();

        public void Start()
        {
            bool gameRunning = true;

            Console.WriteLine("🎲 Welcome to Ten Thousand! First to 10,000 wins.\n");

            while (gameRunning)
            {
                // Roll dice (if none saved, roll all 6 again)
                int diceToRoll = 6 - keptDice.Count;
                currentRoll = DiceRoller.RollDice(diceToRoll);

                Console.WriteLine($"\nYou rolled:");
                for (int i = 0; i < currentRoll.Count; i++)
                {
                    Console.WriteLine($"Die {i + 1}: {currentRoll[i]}");
                }

                Console.WriteLine("\nChoose action: [K]eep, [R]oll again, [B]ank");
                string input = Console.ReadLine()?.ToLower();

                switch (input)
                {
                    case "k":
                        KeepDice();
                        break;
                    case "r":
                        RollAgain();
                        break;
                    case "b":
                        BankPoints();
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }

                if (totalScore >= 10000)
                {
                    Console.WriteLine("\n🎉 You reached 10,000 points! You win!");
                    gameRunning = false;
                }
            }
        }

        private void KeepDice()
        {
            Console.WriteLine("\nEnter dice to keep (e.g. 1 5 5):");
            string input = Console.ReadLine();
            var kept = input.Split(' ');
            foreach (var str in kept)
            {
                if (int.TryParse(str, out int die) && currentRoll.Contains(die))
                {
                    keptDice.Add(die);
                    currentRoll.Remove(die); // Ta bort en instans av värdet
                }
            }
        }

        private void RollAgain()
        {
            if (keptDice.Count == 6)
            {
                Console.WriteLine("All dice are kept! You must bank.");
                return;
            }
            // else if: next loop to handle roll
        }

        private void BankPoints()
        {
            int score = ScoreCalculator.CalculateScore(keptDice);
            Console.WriteLine($"\nYou banked {score} points!");
            totalScore += score;
            keptDice.Clear();
            currentRoll.Clear();
            Console.WriteLine($"Total score: {totalScore}");
        }
    }
}
