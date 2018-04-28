﻿//namespace _004
//{
using System.Collections.Generic;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public Team(string name)
    {
        this.name = name;
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
    }

    public void AddPlayer(Person person)
    {
        if (person.Age < 40)
        {
            firstTeam.Add(person);
        }
        else
        {
            reserveTeam.Add(person);
        }
    }

    public IList<Person> FirstTeam
    {
        get { return this.firstTeam; }
    }

    public IList<Person> ReserveTeam
    {
        get { return this.reserveTeam; }
    }
}

//}