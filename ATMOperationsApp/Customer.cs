namespace ATMOperationsApp
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalNumber { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }

        public string ShowCustomerInfo()
        {
            return $"Name: {Name}, Surname: {Surname}, Personal Number: {PersonalNumber}, Balance: {Balance}";
        }

        public double CheckBalance()
        {
            DataOperations.WriteLogsToFile(Logger.CheckBalance(this));
            return Balance;
        }

        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Deposit amount cannot be negative.");
                return;
            }

            Balance += amount;
            DataOperations.UpdateCustomer(this);
            DataOperations.WriteLogsToFile(Logger.Deposit(this, amount));
        }

        public void Withdraw(double amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Withdrawal amount cannot be negative.");
                return;
            }

            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds");
                return;
            }

            Balance -= amount;
            DataOperations.UpdateCustomer(this);
            DataOperations.WriteLogsToFile(Logger.Withdraw(this, amount));
        }
    }
}
