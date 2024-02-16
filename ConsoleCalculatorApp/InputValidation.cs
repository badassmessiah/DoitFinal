namespace ConsoleCalculatorApp
{
    public static class InputValidation
    {
        public static double ValidateNumber(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Trim() != input || !double.TryParse(input, out double number))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return double.NaN;
            }
            return number;
        }

        public static double GetValidNumber(string userInput)
        {
            double number;
            do
            {
                Console.WriteLine(userInput);
                string input = Console.ReadLine();
                number = InputValidation.ValidateNumber(input);
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
