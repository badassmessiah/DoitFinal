namespace ATMOperationsApp
{
    public class Registration
    {
        public static Customer Register()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your surname: ");
            string surname = Console.ReadLine();

            string personalNumber;
            do
            {
                Console.Write("Enter your personal number (11 characters long): ");
                personalNumber = Console.ReadLine();
                if (personalNumber.Length != 11)
                {
                    Console.WriteLine("Personal number must be 11 characters long. Please try again.");
                }

                var existingCustomers = DataOperations.LoadCustomers();
                foreach (var customer in existingCustomers)
                {
                    if (customer.PersonalNumber == personalNumber)
                    {
                        Console.WriteLine("This personal number is already registered. Please try again.");
                        personalNumber = "";
                        break;
                    }
                }
            } while (personalNumber.Length != 11);

            Random random = new Random();
            string password = random.Next(1000, 9999).ToString();


            double balance = 1000;

            Customer newCustomer = new Customer
            {
                Name = name,
                Surname = surname,
                PersonalNumber = personalNumber,
                Password = password,
                Balance = balance
            };

            return newCustomer;
        }

    }
}
