//namespace _004
//{
using System;
using System.Collections;

public class RandomList : ArrayList
{
    private ArrayList list;

    public ArrayList List
    {
        get
        {
            return this.list;
        }
        set
        {
            this.list = value;
        }
    }

    public string RandomString()
    {
        Random r = new Random();
        list.RemoveAt(r.Next(0, list.Count));
        Console.WriteLine(list[r.Next(0, list.Count)]);
        return list[r.Next(0, list.Count)].ToString();
    }
}

//}