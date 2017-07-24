namespace _010
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MyList<T> : IEnumerable<T>
        where T : IComparable
    {
        public MyList()
        {
            this.List = new List<T>();
        }

        public IList<T> List { get; private set; }

        public void Add(T item)
        {
            this.List.Add(item);
        }

        public T Remove(int index)
        {
            var value = this.List.ElementAt(index);
            this.List.RemoveAt(index);
            return value;
        }

        public bool Contains(T element)
        {
            if (this.List.Contains(element))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Swap(int indexOne, int indexTwo)
        {
            T tmp = List[indexOne];
            List[indexOne] = List[indexTwo];
            List[indexTwo] = tmp;
        }

        public int CountGreaterThan(T element)
        {
            int count = 0;

            foreach (var item in this.List)
            {
                if (item.ToString().CompareTo(element.ToString()) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public T Max()
        {
            return this.List.Max();
        }

        public T Min()
        {
            return this.List.Min();
        }

        public void Sort()
        {
            this.List = this.List.OrderBy(a => a).ToList();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in List)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}