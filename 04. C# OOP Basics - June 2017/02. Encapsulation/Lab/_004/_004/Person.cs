﻿//namespace _004
//{
using System;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        private set
        {
            if (value.Length < 3)
            {
                Console.WriteLine("First name cannot be less than 3 symbols");
                throw new ArgumentException("First name cannot be less than 3 symbols");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        private set
        {
            if (value.Length < 3)
            {
                Console.WriteLine("Last name cannot be less than 3 symbols");
                throw new ArgumentException("Last name cannot be less than 3 symbols");
            }

            this.lastName = value;
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        private set
        {
            if (value <= 0)
            {
                Console.WriteLine("Age cannot be zero or negative integer");
                throw new ArgumentException("Age cannot be zero or negative integer");
            }

            this.age = value;
        }
    }

    public decimal Salary
    {
        get
        {
            return this.salary;
        }
        private set
        {
            if (value < 460)
            {
                Console.WriteLine("Salary cannot be less than 460 leva");
                throw new ArgumentException("Salary cannot be less than 460 leva");
            }

            this.salary = value;
        }
    }
}

//}