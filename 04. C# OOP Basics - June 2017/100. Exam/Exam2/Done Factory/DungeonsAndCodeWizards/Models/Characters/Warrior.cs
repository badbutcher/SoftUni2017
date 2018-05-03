namespace DungeonsAndCodeWizards.Models.Characters
{
    using DungeonsAndCodeWizards.Enums;
    using DungeonsAndCodeWizards.Interfaces;
    using DungeonsAndCodeWizards.Models.Bags;
    using System;

    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction)
            : base(name, 100, 50, 40, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (this.Name == character.Name)
                {
                    throw new InvalidOperationException("Cannot attack self!");
                }
                else if (this.Faction == character.Faction)
                {
                    throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
                }
                else
                {
                    character.TakeDamage(this.AbilityPoints);
                }
            }
            else
            {
                throw new InvalidOperationException(Constants.mustBeAliveMessage);
            }
        }
    }
}