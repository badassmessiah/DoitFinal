using System.Xml.Serialization;

namespace HangmanApp
{
    public class ScoreData
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }

    public static class Save
    {
        private static List<ScoreData> scores = new List<ScoreData>();
        private static string path = @"../../../scores.xml";
        private static XmlSerializer SerializerObj = new XmlSerializer(typeof(List<ScoreData>));

        public static void AsXML(string name, int score)
        {
            List<ScoreData> scores;

            if (File.Exists(path))
            {
                using (StreamReader FileStream = new StreamReader(path))
                {
                    scores = (List<ScoreData>)SerializerObj.Deserialize(FileStream);
                }
            }
            else
            {
                scores = new List<ScoreData>();
            }

            var existingScore = scores.FirstOrDefault(s => s.Name == name);
            if (existingScore != null)
            {
                existingScore.Score = Math.Max(existingScore.Score, score);
            }
            else
            {
                scores.Add(new ScoreData { Name = name, Score = score });
            }

            try
            {
                using (TextWriter WriteFileStream = new StreamWriter(path))
                {
                    SerializerObj.Serialize(WriteFileStream, scores);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            
        }
    }
}
