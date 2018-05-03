namespace DungeonsAndCodeWizards.Factories
{
    using DungeonsAndCodeWizards.Models.Items;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ItemFactory
    {
        public Item CreateItem(string name)
        {
            Item item;
            switch (name)
            {
                case "HealthPotion":
                    item = new HealthPotion();
                    break;
                case "PoisonPotion":
                    item = new PoisonPotion();
                    break;
                case "ArmorRepairKit":
                    item = new ArmorRepairKit();
                    break;
                default:
                    throw new ArgumentException($"Invalid item \"{name}\"!");
            }

            return item;
        }
    }
}
