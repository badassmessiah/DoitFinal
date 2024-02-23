using System.Xml.Serialization;

namespace HangmanApp
{
    public static class LeaderBoard
    {
        public static void ShowLeaderBoard()
        {
            var scores = LoadScores();
            scores.Sort((x, y) => y.Score.CompareTo(x.Score));
            Console.WriteLine("Leaderboard:");
            for (int i = 0; i < Math.Min(10, scores.Count); i++)
            {
                Console.WriteLine($"{i + 1}. {scores[i].Name} - {scores[i].Score}");
            }
        }

        private static List<ScoreData> LoadScores()
        {
            var path = @"../../../scores.xml";
            var scores = new List<ScoreData>();
            if (File.Exists(path))
            {
                var serializer = new XmlSerializer(typeof(List<ScoreData>));
                using (var fileStream = new StreamReader(path))
                {
                    scores = (List<ScoreData>)serializer.Deserialize(fileStream);
                }
            }
            return scores;
        }
    }
}
