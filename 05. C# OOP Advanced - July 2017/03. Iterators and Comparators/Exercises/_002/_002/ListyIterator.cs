namespace _002
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class ListyIterator<T> : IEnumerable<T>
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
            if (this.List.Count <= 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(this.List[Index]);
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

        public void PrintAll()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in List)
            {
                sb.Append(item + " ");
            }

            Console.WriteLine(sb.ToString().Trim());
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.List.Count; i++)
            {
                yield return List[i];
            }

            //foreach (var item in this.List)
            //{
            //    yield return item;
            //}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}