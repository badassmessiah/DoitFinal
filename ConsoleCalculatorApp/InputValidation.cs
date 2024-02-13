namespace ConsoleCalculatorApp
{
    public static class InputValidation
    {
        public static double ValidateNumber(string input)
        {
            if (!double.TryParse(input, out double number))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return double.NaN;
            }
            return number;
        }
    }
}
