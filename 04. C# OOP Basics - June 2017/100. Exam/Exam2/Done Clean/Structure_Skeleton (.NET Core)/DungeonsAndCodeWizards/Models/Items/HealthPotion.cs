namespace DungeonsAndCodeWizards.Models.Items
{
    using DungeonsAndCodeWizards.Models.Characters;
    using System;

    public class HealthPotion : Item
    {
        public HealthPotion()
            : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(Constants.mustBeAliveMessage);
            }
            else
            {
                character.Health += 20;

                if (character.Health > character.BaseHealth)
                {
                    character.Health = character.BaseHealth;
                }
            }
        }
    }
}