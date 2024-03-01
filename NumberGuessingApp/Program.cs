namespace NumberGuessingApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, This is Number Guessing Game.");

            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            int score = 0;

            int min = 1;
            int max = DifficultyChooser.ChooseDifficulty();


            int number = new Random().Next(min, max);
            int attempts = 10;

            
            while (attempts > 0)
            {
                Console.WriteLine($"Please enter your guess (1-{max}): ");
                string input = Console.ReadLine();
                int guess;

                if (int.TryParse(input, out guess))
                {
                    if (guess < min || guess > max)
                    {
                        Console.WriteLine($"Please enter a number between {min} and {max}.");
                        continue;
                    }

                    if (guess == number)
                    {
                        Console.WriteLine($"Congratulations, {name}! You have guessed the number.");
                        score = ScoringSystem.CalculateScore(max, attempts);
                        Console.WriteLine($"Your score is {score}.");
                        Save.AsCSV(name, score);
                        ScoreSort.Sort();
                        break;
                    }
                    else if (guess > number)
                    {
                        Console.WriteLine("The number is lower.");
                    }
                    else
                    {
                        Console.WriteLine("The number is higher.");
                    }

                    attempts--;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                
            }



            
        }
    }
}
