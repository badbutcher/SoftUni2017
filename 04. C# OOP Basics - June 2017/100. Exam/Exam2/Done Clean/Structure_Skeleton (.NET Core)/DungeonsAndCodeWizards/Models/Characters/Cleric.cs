namespace DungeonsAndCodeWizards.Models.Characters
{
    using DungeonsAndCodeWizards.Enums;
    using DungeonsAndCodeWizards.Interfaces;
    using DungeonsAndCodeWizards.Models.Bags;
    using System;

    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction)
            : base(name, 50, 25, 40, new Backpack(), faction)
        {
            this.RestHealMultiplier = 0.5;
        }

        public void Heal(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (this.Faction != character.Faction)
                {
                    throw new InvalidOperationException($"Cannot heal enemy character!");
                }
                else
                {
                    character.Health += this.AbilityPoints;

                    if (character.Health > character.BaseHealth)
                    {
                        character.Health = character.BaseHealth;
                    }
                }
            }
            else
            {
                throw new InvalidOperationException(Constants.mustBeAliveMessage);
            }
        }
    }
}