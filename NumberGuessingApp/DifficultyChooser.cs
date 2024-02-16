using NumberGuessingApp;

public class DifficultyChooser
{
    public static int ChooseDifficulty()
    {
        int max = 0;
        string input;

        do
        {
            Console.WriteLine("Choose difficulty: Easy (e), Medium (m), Hard (h)");
            input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "e":
                    max = 15;
                    break;
                case "m":
                    max = 25;
                    break;
                case "h":
                    max = 50;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please choose difficulty again.");
                    max = 0;
                    break;
            }
        } while (max == 0);

        Console.WriteLine($"You have chosen {input.ToUpper()} difficulty. You have 10 attempts to guess the number between 1 and {max}.");
        return max;
    }
}
