namespace _003
{
    public class BankAccount
    {
        private int id;
        private double balance;

        public int ID { get; set; }

        public double Balance { get; set; }

        public void Deposit(double amount)
        {
            this.Balance += amount;
        }

        public void Withdraw(double amount)
        {
            this.Balance -= amount;
        }

        public override string ToString()
        {
            return $"Account ID{this.ID}, balance {this.Balance:F2}";
        }
    }
}