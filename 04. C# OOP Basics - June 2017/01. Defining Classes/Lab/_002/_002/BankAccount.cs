//namespace _002
//{
    public class BankAccount
    {
        private int id;
        private double balance;

        public int ID { get; set; }

        public double Balance { get; set; }

        public void Deposit(double amount)
        {
            this.balance += amount;
        }

        public void Withdraw(double amount)
        {
            this.balance -= amount;
        }

        public override string ToString()
        {
            return $"Account {this.id}, balance {this.balance}";
        }
    }
//}