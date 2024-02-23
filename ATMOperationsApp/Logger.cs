

namespace ATMOperationsApp
{
    public static class Logger
    {

        public static string LogIn(Customer Customer)
        {
            return $"მომხმარებელი სახელად {Customer.Name} {Customer.Surname} დალოგინდა {DateTime.Now}-ში";
        }

        public static string LogOut(Customer Customer)
        {
            return $"მომხმარებელი სახელად {Customer.Name} {Customer.Surname} დალოგაუთდა {DateTime.Now}-ში";
        }

        public static string CheckBalance(Customer Customer)
        {
            return $"მომხმარებელმა სახელად {Customer.Name} {Customer.Surname} შეამოწმა ბალანსი {DateTime.Now}-ში";
        }

        public static string Deposit(Customer Customer, double amount)
        {
            return $"მომხმარებელმა სახელად {Customer.Name} {Customer.Surname} შეავსო ბალანსი {amount} ლარით {DateTime.Now}-ში";
        }

        public static string Withdraw(Customer Customer, double amount)
        {
            return $"მომხმარებელმა სახელად {Customer.Name} {Customer.Surname} გაანაღდა {amount} ლარი {DateTime.Now}-ში";
        }
    }
}
