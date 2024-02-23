using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanApp
{
    public static class RandomWord
    {
        static List<string> words = new()
        {
            "apple", "banana", "orange", "grape", "kiwi",
            "strawberry", "pineapple", "blueberry", "peach", "watermelon"
        };

        public static string GetRandomWord()
        {
            Random random = new();
            int index = random.Next(words.Count);
            return words[index];
        }

    }
}
