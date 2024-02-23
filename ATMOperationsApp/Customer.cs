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
            return $"Id: {Id}, Name: {Name}, Surname: {Surname}, Personal Number: {PersonalNumber}, Balance: {Balance}";
        }

        public double CheckBalance()
        {
            return Balance;
        }
        public void Deposit(double amount)
        {
            Balance += amount;
            DataOperations.UpdateCustomer(this);
        }

        public void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds");
            }
            else
            {
                Balance -= amount;
                DataOperations.UpdateCustomer(this);
            }
        }

    }
}
