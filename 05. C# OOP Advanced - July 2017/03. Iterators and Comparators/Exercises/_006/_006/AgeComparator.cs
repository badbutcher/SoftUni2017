namespace _006
{
    using System.Collections.Generic;

    public class AgeComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Age.CompareTo(y.Age) > 0)
            {
                return x.Age - y.Age;
            }
            else if (y.Age.CompareTo(x.Age) > 0)
            {
                return x.Age - y.Age;
            }

            return 0;
        }
    }
}