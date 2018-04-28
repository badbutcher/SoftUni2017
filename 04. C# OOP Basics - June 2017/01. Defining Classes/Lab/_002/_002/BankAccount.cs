//namespace _002
//{
public class BankAccount
{
    private int id;
    private decimal balance;

    public int Id { get; set; }

    public decimal Balance { get; set; }

    public void Deposit(decimal amount)
    {
        this.balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        this.balance -= amount;
    }

    public override string ToString()
    {
        return $"Account {this.id}, balance {this.balance}";
    }
}

//}