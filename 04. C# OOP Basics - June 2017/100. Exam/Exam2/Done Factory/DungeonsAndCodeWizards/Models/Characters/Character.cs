namespace DungeonsAndCodeWizards.Models.Characters
{
    using DungeonsAndCodeWizards.Enums;
    using DungeonsAndCodeWizards.Models.Bags;
    using DungeonsAndCodeWizards.Models.Items;
    using System;

    public abstract class Character
    {
        private string name;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health { get; set; }

        public double BaseArmor { get; private set; }

        public double Armor { get; set; }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get; private set; }

        public Faction Faction { get; set; }

        public bool IsAlive { get; set; } = true;

        public double RestHealMultiplier { get; set; } = 0.2;

        public void TakeDamage(double hitPoints)
        {
            double hitPointsLeft = 0;
            if (this.IsAlive)
            {
                this.Armor -= hitPoints;

                if (this.Armor < 0)
                {
                    hitPointsLeft = this.Armor * -1;
                    this.Armor = 0;
                }

                this.Health -= hitPointsLeft;

                if (this.Health <= 0)
                {
                    this.IsAlive = false;
                    this.Health = 0;
                }
            }
            else
            {
                throw new InvalidOperationException(Constants.mustBeAliveMessage);
            }
        }

        public void Rest()
        {
            if (this.IsAlive)
            {
                this.Health = this.Health + (this.BaseHealth * this.RestHealMultiplier);

                if (this.Health > this.BaseHealth)
                {
                    this.Health = this.BaseHealth;
                }
            }
            else
            {
                throw new InvalidOperationException(Constants.mustBeAliveMessage);
            }
        }

        public void UseItem(Item item)
        {
            if (this.IsAlive)
            {
                item.AffectCharacter(this);
            }
            else
            {
                throw new InvalidOperationException(Constants.mustBeAliveMessage);
            }
        }

        public void UseItemOn(Item item, Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                item.AffectCharacter(character);
            }
            else
            {
                throw new InvalidOperationException(Constants.mustBeAliveMessage);
            }
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                character.Bag.AddItem(item);
            }
            else
            {
                throw new InvalidOperationException(Constants.mustBeAliveMessage);
            }
        }

        public void ReceiveItem(Item item)
        {
            if (this.IsAlive)
            {
                this.Bag.AddItem(item);
            }
            else
            {
                throw new InvalidOperationException(Constants.mustBeAliveMessage);
            }
        }
    }
}