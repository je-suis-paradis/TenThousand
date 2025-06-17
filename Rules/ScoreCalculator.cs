using System.Collections.Generic;
using System.Linq;

namespace TenThousand.Rules
{
    public static class ScoreCalculator
    {
        public static int CalculateScore(List<int> dice)
        {
            int score = 0;

            // Steg 1: Räkna förekomst av varje tärningsvärde (1–6)
            var counts = new Dictionary<int, int>();
            for (int i = 1; i <= 6; i++)
            {
                counts[i] = 0;
            }

            foreach (var die in dice)
            {
                counts[die]++;
            }

                // Steg 2: Specialfall – Straight (1-2-3-4-5-6)
                if (counts.Values.All(v => v == 1))
                {
                    return 1000;
                }

                // Steg 3: Specialfall – Tre par
                if (counts.Values.Count(v => v == 2) == 3)
                {
                    return 750;
                }

                // Steg 4: Specialfall – Två trissar
                if (counts.Values.Count(v => v == 3) == 2)
                {
                    return 500;
                }

                // Steg 5: Trissar
                foreach (var pair in counts)
                {
                    int value = pair.Key;
                    int count = pair.Value;

                    if (count >= 3)
                {
                        // Tre av samma
                    score += (value == 1) ? 1000 : value * 100;
                    count -= 3;
                }

                    // Enskilda 1:or och 5:or efter ev. triss
                if (value == 1)
                    score += count * 100;
                else if (value == 5)
                    score += count * 50;
                }

            return score;
        }
    }
}
