namespace DungeonsAndCodeWizards.Models.Items
{
    using DungeonsAndCodeWizards.Models.Characters;
    using System;

    public class ArmorRepairKit : Item
    {
        public ArmorRepairKit()
            : base(10)
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
                character.Armor = character.BaseArmor;
            }
        }
    }
}