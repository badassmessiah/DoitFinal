using System.Text;
using System.Text.Json;
using System.Text.Encodings.Web;

namespace ATMOperationsApp
{
    public static class DataOperations
    {
        private const string LogFilePath = "../../../Logs.json";
        private const string CustomersFilePath = "../../../Customers.json";
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
        private static List<Customer>? customers;

        public static void SaveNewCustomer(Customer customer)
        {
            if (customer == null)
            {
                Console.WriteLine("Customer cannot be null.");
                return;
            }

            if (customers == null)
            {
                customers = LoadCustomers();
            }

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
                customers = File.Exists(CustomersFilePath)
                    ? JsonSerializer.Deserialize<List<Customer>>(File.ReadAllText(CustomersFilePath))
                    : new List<Customer>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load customers from file: {ex}");
                customers = new List<Customer>();
            }

            return customers;
        }

        public static Customer? LoadCustomer(string personalNumber, string password)
        {
            if (password == null)
            {
                Console.WriteLine("Password cannot be null.");
                return null;
            }
            if (personalNumber == null)
            {
                Console.WriteLine("Personal number cannot be null.");
                return null;
            }

            if (customers == null)
            {
                customers = LoadCustomers();
            }

            return customers.FirstOrDefault(c => c.PersonalNumber == personalNumber && c.Password == password);
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
                File.WriteAllText(CustomersFilePath, JsonSerializer.Serialize(customers, options));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write customers to file: {ex}");
            }
        }

        private static List<string> logs = new List<string>();

        public static void WriteLogsToFile(string log)
        {
            try
            {
                List<string> existingLogs = new List<string>();

                if (File.Exists(LogFilePath))
                {
                    existingLogs = JsonSerializer.Deserialize<List<string>>(File.ReadAllText(LogFilePath)) ?? new List<string>();
                }

                existingLogs.Add(log);

                string json = JsonSerializer.Serialize(existingLogs, options);

                File.WriteAllText(LogFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write logs to file: {ex}");
            }
        }

    }
}
