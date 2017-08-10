namespace _001
{
    using System;

    public class DataBaseClass
    {
        public DataBaseClass()
        {
            this.Index = 0;
            this.Items = new int[15];
        }

        public int Index { get; set; }

        public int[] Items { get; set; }

        public void Add(int item)
        {
            if (this.Index >= 15)
            {
                throw new InvalidOperationException("Array is bigger than 16.");
            }

            this.Items[this.Index] = item;
            this.Index++;
        }

        public void Remove()
        {
            if (this.Index <= 0)
            {
                throw new InvalidOperationException("Index is less than 0.");
            }

            this.Index--;
            this.Items[this.Index] = 0;
        }

        public int[] FetchAll()
        {
            return this.Items;
        }
    }
}