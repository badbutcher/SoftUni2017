namespace _007
{
    using System;
    using System.Collections.Generic;

    public class Box<T>
        where T : IComparable
    {
        public Box()
        {
            this.List = new List<T>();
        }

        public IList<T> List { get; set; }

        public void AddValue(T value)
        {
            this.List.Add(value);
        }

        public int Compare(T itemToCompare)
        {
            int count = 0;

            foreach (var item in List)
            {
                if (item.CompareTo(itemToCompare) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
