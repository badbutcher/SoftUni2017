namespace DungeonsAndCodeWizards.Models.Items
{
    using DungeonsAndCodeWizards.Models.Characters;
    using System;

    public class PoisonPotion : Item
    {
        public PoisonPotion()
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
                character.Health -= 20;

                if (character.Health <= 0)
                {
                    character.Health = 0;
                    character.IsAlive = false;
                }
            }
        }
    }
}