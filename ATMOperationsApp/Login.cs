
namespace ATMOperationsApp
{
    public static class Login
    {
        public static Customer LogIn()
        {
            Console.Write("Enter your Personal Number: ");
            string personalNumber = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            var customer = DataOperations.LoadCustomer(personalNumber, password);
            if (customer == null)
            {
                Console.WriteLine("Invalid ID or password. Please try again.");
                return null;
            }
            DataOperations.WriteLogsToFile(Logger.LogIn(customer));
            return customer;
        }
    }
}
