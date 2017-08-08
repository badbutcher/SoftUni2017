using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001
{
    public class DatabaseClass
    {
        public DatabaseClass()
        {
            this.Id = 1;
            this.Items = new int[16];
        }

        public int Id { get; }

        public int Index { get; set; }

        public int[] Items { get; }

        public void Add(int item)
        {
            if (Index >= 16)
            {
                throw new InvalidOperationException("Database size is bigger than 16");
            }

            this.Items[this.Index] = item;
            this.Index++;
        }

        public void Remove()
        {
            if (Index <= 0)
            {
                throw new InvalidOperationException("Database is empty");
            }

            this.Index--;
            this.Items[this.Index] = 0;          
        }

        public int[] FetchAll()
        {
            int[] newItems = new int[this.Items.Where(a=>a != 0).Count()];
            for (int i = 0; i < newItems.Length; i++)
            {
                newItems[i] = this.Items[i];
            }

            return newItems;
        }
    }
}