using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race
{
    private int lenght;
    private string route;
    private int prizePool;
    private Dictionary<int, Car> participants;

    public Race(int lenght, string route, int prizePool, Dictionary<int, Car> participants)
    {
        this.Lenght = lenght;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = participants;
    }

    public int Lenght
    {
        get
        {
            return this.lenght;
        }
        set
        {
            this.lenght = value;
        }
    }

    public string Route
    {
        get
        {
            return this.route;
        }
        set
        {
            this.route = value;
        }
    }

    public int PrizePool
    {
        get
        {
            return this.prizePool;
        }
        set
        {
            this.prizePool = value;
        }
    }

    public Dictionary<int, Car> Participants
    {
        get
        {
            return this.participants;
        }
        set
        {
            this.participants = value;
        }
    }

    public abstract int GetPP(int carId);

    private Dictionary<int, Car> TopCars()
    {
        var sort = participants.OrderByDescending(a => GetPP(a.Key)).Take(3).ToDictionary(c => c.Key, d => d.Value);

        return sort;
    }

    private List<int> Prizes()
    {
        List<int> result = new List<int>();
        result.Add((this.PrizePool * 50) / 100);
        result.Add((this.PrizePool * 30) / 100);
        result.Add((this.PrizePool * 20) / 100);
        return result;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{Route} - {Lenght}");

        var winners = TopCars();
        var prizes = Prizes();

        for (int i = 0; i < winners.Count; i++)
        {
            var car = winners.ElementAt(i);

            sb.AppendLine($"{i + 1}. {car.Value.Brand} {car.Value.Model} {GetPP(car.Key)}PP - ${prizes[i]}");
        }
        

        return sb.ToString().Trim();
    }
}