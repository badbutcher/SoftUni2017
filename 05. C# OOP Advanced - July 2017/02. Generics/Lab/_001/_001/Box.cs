//namespace _001
//{
    using System.Collections.Generic;
    using System.Linq;

    public class Box<T>
    {
        private List<T> elements = new List<T>();

        public int Count => this.elements.Count;

        public void Add(T element)
        {
            this.elements.Add(element);
        }

        public T Remove()
        {
            var ele = this.elements.Last();
            elements.RemoveAt(this.elements.Count - 1);
            return ele;
        }
    }
//}