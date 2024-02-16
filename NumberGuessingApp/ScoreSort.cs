using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuessingApp
{
    public static class ScoreSort
    {
        public static void Sort()
        {
            string path = @"../../../scores.csv";
            string[] lines = File.ReadAllLines(path);
            List<(string Name, int ScoreValue)> scores = new List<(string Name, int ScoreValue)>();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');
                string name = fields[0];
                if (int.TryParse(fields[1], out int score))
                {
                    scores.Add((name, score));
                }
            }

            scores = scores.OrderByDescending(s => s.ScoreValue).ToList();

            Console.WriteLine("Top 10 scores:");
            for (int i = 0; i < 10; i++)
            {
                if (i < scores.Count)
                {
                    Console.WriteLine($"{i + 1}. {scores[i].Name} - {scores[i].ScoreValue}");
                }
            }
        }
    }
}
