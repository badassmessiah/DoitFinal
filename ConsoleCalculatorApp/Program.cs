namespace ConsoleCalculatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is A Console Calculator");

            while (true)
            {
                double firstNumber = InputValidation.GetValidNumber("\nEnter First Number");
                double secondNumber = InputValidation.GetValidNumber("Enter Second Number");
                string operation = InputValidation.GetValidOperation("Enter Operation. A for Add, S for Subtract, M for Multiply, D for Divide");

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

       
    }
}
