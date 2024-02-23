namespace ATMOperationsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ATM Operations App\nLogin - 1/Register - 2");

            int choice;
            do
            {
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        // Handle login
                        break;
                    case 2:
                        Customer newCustomer = Registration.Register();
                        Console.WriteLine("Registration successful");
                        Console.WriteLine(newCustomer.ShowCustomerInfo());
                        DataOperations.SaveNewCustomer(newCustomer);
                        Console.WriteLine($"Now you can log with your ID ({newCustomer.Id}) and password ({newCustomer.Password})");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.WriteLine("\nLogin - 1/Register - 2\n");
                        break;
                }
            } while (choice != 1 && choice != 2);
        }


    }
}
