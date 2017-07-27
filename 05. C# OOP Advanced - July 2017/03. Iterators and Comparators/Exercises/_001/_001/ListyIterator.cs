namespace _001
{
    using System;
    using System.Collections.Generic;

    public class ListyIterator<T>
    {
        public ListyIterator()
        {
            this.List = new List<T>();
            this.Index = 0;
        }

        public IList<T> List { get; private set; }

        public int Index { get; private set; }

        public bool Move()
        {
            if (this.Index < this.List.Count - 1)
            {
                this.Index++;
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (this.List.Count <= Index)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(List[Index]);
            }
        }

        public void Create(params T[] elements)
        {
            foreach (var item in elements)
            {
                this.List.Add(item);
            }
        }

        public bool HasNext()
        {
            return this.Index + 1 < this.List.Count;
        }
    }
}