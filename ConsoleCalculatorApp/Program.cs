namespace ConsoleCalculatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is A Console Calculator");

            while (true)
            {
                double firstNumber = GetValidNumber("\nEnter First Number");
                double secondNumber = GetValidNumber("Enter Second Number");
                string operation = GetValidOperation("Enter Operation. A for Add, S for Subtract, M for Multiply, D for Divide");

                switch (operation.ToLower())
                {
                    case "a":
                        Console.WriteLine("Answer: " + Calculations.Add(firstNumber, secondNumber));
                        break;
                    case "s":
                        Console.WriteLine("Answer: " + Calculations.Subtract(firstNumber, secondNumber));
                        break;
                    case "m":
                        Console.WriteLine("Answer: " + Calculations.Multiply(firstNumber, secondNumber));
                        break;
                    case "d":
                        Console.WriteLine("Answer: " + Calculations.Divide(firstNumber, secondNumber));
                        break;
                }
            }
        }

        static double GetValidNumber(string userInput)
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

        static string GetValidOperation(string userInput)
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
