namespace _004
{
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
    {
        public Box()
        {
            this.List = new List<T>();
        }

        public List<T> List { get; set; }

        public void Swap(int indexOne, int indexTwo)
        {
            T tmp = List[indexOne];
            List[indexOne] = List[indexTwo];
            List[indexTwo] = tmp;
        }

        public void AddValue(T value)
        {
            this.List.Add(value);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in List)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString().Trim();
        }
    }
}