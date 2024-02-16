using System.IO;

namespace NumberGuessingApp
{
    public static class Save
    {
        public static void AsCSV(string name, int score)
        {
            string path = @"../../../scores.csv";
            string csv = $"{name},{score}\n";

            if (!File.Exists(path))
            {
                File.WriteAllText(path, "Name,Score\n");
                File.AppendAllText(path, csv);
            }
            else
            {
                string[] lines = File.ReadAllLines(path);
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(',');
                    if (fields[0] == name)
                    {
                        int existingScore;
                        if (int.TryParse(fields[1], out existingScore))
                        {
                            if (score > existingScore)
                            {
                                lines[i] = csv.Trim();
                                File.WriteAllLines(path, lines);
                            }
                        }
                        return;
                    }
                }
                File.AppendAllText(path, csv);
            }
        }
    }
}
