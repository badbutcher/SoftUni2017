namespace _003
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyStack<T> : IEnumerable<T>
    {
        public MyStack()
        {
            this.List = new List<T>();
        }

        public List<T> List { get; private set; }

        public void Push(T[] elements)
        {
            List<T> newList = new List<T>();
            for (int i = elements.Length - 1; i >= 0; i--)
            {
                newList.Add(elements[i]);
            }

            this.List.InsertRange(0, newList);
        }

        public void Pop()
        {
            if (this.List.Count > 0)
            {
                this.List.RemoveAt(0);
            }
            else
            {
                throw new ArgumentException("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < this.List.Count; i++)
                {
                    yield return List[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}