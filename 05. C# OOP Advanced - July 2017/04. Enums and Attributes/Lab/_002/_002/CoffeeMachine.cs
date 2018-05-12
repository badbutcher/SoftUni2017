//namespace _002
//{
using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    private List<CoffeeType> coffeesType;

    public CoffeeMachine()
    {
        this.coffeesType = new List<CoffeeType>();
        this.Money = 0;
    }

    public int Money { get; set; }

    public CoffeePrice CoffeePrice { get; private set; }

    public Coin Coin { get; private set; }

    public IEnumerable<CoffeeType> CoffeesSold
    {
        get
        {
            return this.coffeesType;
        }
    }

    public void BuyCoffee(string size, string type)
    {
        CoffeeType cType = (CoffeeType)Enum.Parse(typeof(CoffeeType), type);
        CoffeePrice cSize = (CoffeePrice)Enum.Parse(typeof(CoffeePrice), size);

        if (Money >= (int)cSize)
        {
            Money = 0;
            coffeesType.Add(cType);
        }
    }

    public void InsertCoin(string coin)
    {
        Coin c = (Coin)Enum.Parse(typeof(Coin), coin);
        this.Money += (int)c;
    }
}

//}