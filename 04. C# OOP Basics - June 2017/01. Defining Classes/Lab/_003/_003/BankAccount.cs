namespace _003
{
    public class BankAccount
    {
        private int id;
        private decimal balance;

        public int Id { get; set; }

        public decimal Balance { get; set; }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }

        public override string ToString()
        {
            return $"Account ID{this.Id}, balance {this.Balance:F2}";
        }
    }
}