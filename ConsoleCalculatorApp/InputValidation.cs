namespace ConsoleCalculatorApp
{
    public static class InputValidation
    {
        public static double GetValidNumber(string userInput)
        {
            double number;
            string input;
            do
            {
                Console.WriteLine(userInput);
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || input.Trim() != input || !double.TryParse(input, out number))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    number = double.NaN;
                }

            } while (double.IsNaN(number));

            return number;
        }

        public static string GetValidOperation(string userInput)
        {
            string operation;
            do
            {
                Console.WriteLine(userInput);
                operation = Console.ReadLine();
            } while (operation == null || !"asmd".Contains(operation.ToLower()));

            return operation;
        }
    }
}
