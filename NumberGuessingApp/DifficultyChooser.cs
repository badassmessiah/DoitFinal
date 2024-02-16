using NumberGuessingApp;

public class DifficultyChooser
{
    public static int ChooseDifficulty()
    {
        string difficulty;
        int max = 0;

        do
        {
            Console.WriteLine("Choose difficulty: Easy (e), Medium (m), Hard (h)");
            difficulty = InputValidation.ValidateDifficulty(Console.ReadLine().ToLower());

            switch (difficulty)
            {
                case "e":
                    Console.WriteLine("You have chosen Easy difficulty. You have 10 attempts to guess the number between 1 and 15.");
                    max = 15;
                    break;
                case "m":
                    Console.WriteLine("You have chosen Medium difficulty. You have 10 attempts to guess the number between 1 and 25.");
                    max = 25;
                    break;
                case "h":
                    Console.WriteLine("You have chosen Hard difficulty. You have 10 attempts to guess the number between 1 and 50.");
                    max = 50;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please choose difficulty again.");
                    difficulty = null;
                    break;
            }
        } while (difficulty == null);

        return max;
    }
}
