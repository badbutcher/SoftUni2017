//namespace _004.Models
//{
using System.Collections.Generic;

public class BookComparator : IComparer<Book>
{
    public int Compare(Book x, Book y)
    {
        //if (x.Title.CompareTo(y.Title) > 0)
        //{
        //    return x.Title.CompareTo(y.Title);
        //}

        //if (y.Year.CompareTo(x.Year) > 0)
        //{
        //    return y.Year.CompareTo(x.Year);
        //}

        //return 0;

        int result = x.Title.CompareTo(y.Title);
        if (result == 0)
        {
            result = y.Year.CompareTo(x.Year);
        }

        return result;
    }
}

//}