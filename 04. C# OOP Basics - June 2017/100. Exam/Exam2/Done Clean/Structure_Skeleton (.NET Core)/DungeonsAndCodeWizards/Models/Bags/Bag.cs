namespace DungeonsAndCodeWizards.Models.Bags
{
    using DungeonsAndCodeWizards.Models.Items;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Bag
    {
        private List<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; private set; }

        public int Load => this.items.Sum(a => a.Weight);

        public IReadOnlyCollection<Item> Items
        {
            get
            {
                return this.items.AsReadOnly();
            }
        }

        public void AddItem(Item item)
        {
            if (item.Weight + this.Load > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            else
            {
                this.items.Add(item);
            }
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            else if (!this.items.Any(a => a.GetType().Name == name))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            else
            {
                Item item = this.items.FirstOrDefault(a => a.GetType().Name == name);

                this.items.Remove(item);

                return item;
            }
        }
    }
}