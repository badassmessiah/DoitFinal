using System.Text.Json;

namespace ATMOperationsApp
{
    public static class DataOperations
    {
        private const string FilePath = "../../../Customers.json";
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        private static List<Customer>? customers;

        public static void SaveNewCustomer(Customer customer)
        {
            if (customer == null)
            {
                Console.WriteLine("Customer cannot be null.");
                return;
            }

            customers = customers ?? LoadCustomers();

            customer.Id = customers.Any() ? customers.Max(c => c.Id) + 1 : 1;

            customers.Add(customer);

            try
            {
                WriteCustomersToFile(customers);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Failed to write customers to file: {ex}");
            }
        }

        public static List<Customer> LoadCustomers()
        {
            if (customers != null)
            {
                return customers;
            }

            try
            {
                customers = File.Exists(FilePath)
                    ? JsonSerializer.Deserialize<List<Customer>>(File.ReadAllText(FilePath))
                    : new List<Customer>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load customers from file: {ex}");
                customers = new List<Customer>();
            }

            return customers;
        }

        public static Customer? LoadCustomer(int id, string password)
        {
            if (password == null)
            {
                Console.WriteLine("Password cannot be null.");
                return null;
            }

            customers = customers ?? LoadCustomers();

            return customers.FirstOrDefault(c => c.Id == id && c.Password == password);
        }

        public static void UpdateCustomer(Customer customer)
        {
            if (customer == null)
            {
                Console.WriteLine("Customer cannot be null.");
                return;
            }

            customers = customers ?? LoadCustomers();

            var index = customers.FindIndex(c => c.Id == customer.Id);

            if (index != -1)
            {
                customers[index] = customer;
                try
                {
                    WriteCustomersToFile(customers);
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Failed to update customer: {ex}");
                }
            }
            else
            {
                Console.WriteLine("Customer not found in the list.");
            }
        }

        private static void WriteCustomersToFile(List<Customer> customers)
        {
            try
            {
                File.WriteAllText(FilePath, JsonSerializer.Serialize(customers, options));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write customers to file: {ex}");
            }
        }
    }
}
