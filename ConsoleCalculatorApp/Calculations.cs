
namespace ConsoleCalculatorApp
{
    public static class Calculations
    {
        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        public static double Divide(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Cannot divide by zero, come on :D");
                return double.NaN;
            }
            return a / b;
        }

    }
}
