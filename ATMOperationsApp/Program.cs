namespace ATMOperationsApp
{
    internal class Program
    {
        public static Customer currentCustomer = null;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to ATM Operations App\nLogin - 1\nRegister - 2\nExit App - 3");

                int.TryParse(Console.ReadLine(), out int choice);

                switch (choice)
                {
                    case 1:
                        currentCustomer = Login.LogIn();
                        if (currentCustomer != null)
                        {
                            Console.WriteLine($"Welcome {currentCustomer.Name} {currentCustomer.Surname}");
                        }
                        break;
                    case 2:
                        Customer newCustomer = Registration.Register();
                        Console.WriteLine("Registration successful");
                        Console.WriteLine(newCustomer.ShowCustomerInfo());
                        DataOperations.SaveNewCustomer(newCustomer);
                        Console.WriteLine($"Now you can log with your ID ({newCustomer.Id}) and password ({newCustomer.Password})");
                        break;
                    case 3:
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (currentCustomer != null)
                {
                    while (true)
                    {
                        Console.WriteLine("Check Balance - 1\nCash In - 2\nCash Out - 3\nLogout - 4");
                        int.TryParse(Console.ReadLine(), out choice);

                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine($"Your balance is {currentCustomer.CheckBalance()}\n");
                                break;
                            case 2:
                                Console.Write("Enter amount to cash in: ");
                                if (double.TryParse(Console.ReadLine(), out double cashInAmount))
                                {
                                    currentCustomer.Deposit(cashInAmount);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid amount. Please try again.");
                                }
                                break;
                            case 3:
                                Console.Write("Enter amount to cash out: ");
                                if (double.TryParse(Console.ReadLine(), out double cashOutAmount))
                                {
                                    currentCustomer.Withdraw(cashOutAmount);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid amount. Please try again.");
                                }
                                break;
                            case 4:
                                Console.WriteLine("You have been logged out. Thank you for using our ATM. Goodbye!\n");
                                currentCustomer = null;
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }

                        if (currentCustomer == null)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
