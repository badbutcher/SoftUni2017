namespace DungeonsAndCodeWizards.Factories
{
    using DungeonsAndCodeWizards.Enums;
    using DungeonsAndCodeWizards.Models.Characters;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string type, string name)
        {
            if (!Enum.IsDefined(typeof(Faction), faction))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            Faction parsedFaction = (Faction)Enum.Parse(typeof(Faction), faction);
            Character character;
            switch (type)
            {
                case "Warrior":
                    character = new Warrior(name, parsedFaction);
                    break;
                case "Cleric":
                    character = new Cleric(name, parsedFaction);
                    break;
                default:
                    throw new ArgumentException($"Invalid character type \"{type}\"!");
            }

            return character;
        }
    }
}
