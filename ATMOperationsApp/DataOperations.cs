using System.Text.Json;

namespace ATMOperationsApp
{
    public static class DataOperations
    {
        public static void SaveNewCustomer(Customer customer)
        {
            List<Customer> customers;

            if (File.Exists("../../../Customers.json"))
            {
                var json = File.ReadAllText("../../../Customers.json");
                customers = JsonSerializer.Deserialize<List<Customer>>(json);
            }
            else
            {
                customers = new List<Customer>();
            }

            int maxId = 0;
            if (customers.Count > 0)
            {
                foreach (var _customer in customers)
                {
                    if (_customer.Id > maxId)
                    {
                        maxId = _customer.Id;
                    }
                }
            }
            customer.Id = maxId + 1;

            customers.Add(customer);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var updatedJson = JsonSerializer.Serialize(customers, options);
            File.WriteAllText("../../../Customers.json", updatedJson);
        }

        public static List<Customer> LoadCustomers()
        {
            if (File.Exists("../../../Customers.json"))
            {
                var json = File.ReadAllText("../../../Customers.json");
                return JsonSerializer.Deserialize<List<Customer>>(json);
            }
            else
            {
                return new List<Customer>();
            }
        }
    }
}
