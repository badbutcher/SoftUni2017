//namespace _005
//{
using System.Collections.Generic;
using System.Linq;

public class StackOfStrings
{
    private List<string> data;

    public void Push(string item)
    {
        this.data.Add(item);
    }

    public string Pop()
    {
        string item = this.data.Last();
        this.data.Remove(item);
        return item;
    }

    public string Peek()
    {
        string item = this.data.Last();
        return item;
    }

    public bool IsEmpty()
    {
        if (this.data.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

//}