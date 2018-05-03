namespace DungeonsAndCodeWizards.Core
{
    using DungeonsAndCodeWizards.Enums;
    using DungeonsAndCodeWizards.Interfaces;
    using DungeonsAndCodeWizards.Models.Characters;
    using DungeonsAndCodeWizards.Models.Items;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DungeonMaster
    {
        private List<Character> characters;
        private Stack<Item> items;
        private int rounds;

        public DungeonMaster()
        {
            this.characters = new List<Character>();
            this.items = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string type = args[1];
            string name = args[2];

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

            this.characters.Add(character);
            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string name = args[0];

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

            this.items.Push(item);
            return $"{name} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = FindCharacter(characterName);

            if (this.items.Count == 0)
            {
                throw new InvalidOperationException($"No items left in pool!");
            }

            string itemName = items.Peek().GetType().Name;

            character.Bag.AddItem(items.Pop());

            return $"{characterName} picked up {itemName}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = FindCharacter(characterName);

            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = FindCharacter(giverName);
            Character receiver = FindCharacter(receiverName);

            Item item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = FindCharacter(giverName);
            Character receiver = FindCharacter(receiverName);

            Item item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            var sort = this.characters.OrderByDescending(a => a.IsAlive)
                .ThenByDescending(a => a.Health);

            foreach (var c in sort)
            {
                string isAlive = c.IsAlive ? "Alive" : "Dead";
                sb.AppendLine($"{c.Name} - HP: {c.Health}/{c.BaseHealth}, AP: {c.Armor}/{c.BaseArmor}, Status: {isAlive}");
            }

            return sb.ToString().Trim('\n', '\r');
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = FindCharacter(attackerName);
            Character receiver = FindCharacter(receiverName);

            if (!(attacker is IAttackable attackable))
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }

            attackable.Attack(receiver);

            string result = $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

            StringBuilder sb = new StringBuilder();
            sb.Append(result);

            if (!receiver.IsAlive)
            {
                sb.Append($"\n{receiver.Name} is dead!");
            }

            return sb.ToString();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];

            Character healer = FindCharacter(healerName);
            Character receiver = FindCharacter(receiverName);

            if (!(healer is IHealable healable))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            healable.Heal(receiver);

            string result = $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";

            return result;
        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            Character[] aliveCharacters = characters.Where(c => c.IsAlive).ToArray();
            foreach (var character in aliveCharacters)
            {
                double characterOldHealth = character.Health;

                character.Rest();
                sb.AppendLine($"{character.Name} rests ({characterOldHealth} => {character.Health})");
            }

            if (aliveCharacters.Length <= 1)
            {
                this.rounds++;
            }

            return sb.ToString().Trim('\n', '\r');
        }

        public bool IsGameOver()
        {
            if (this.rounds > 1 && this.characters.Count(a => a.IsAlive) <= 1)
            {
                return true;
            }

            return false;
        }

        private Character FindCharacter(string name)
        {
            Character character = this.characters.FirstOrDefault(e => e.Name == name);

            if (character == null)
            {
                throw new ArgumentException($"Character {name} not found!");
            }

            return character;
        }
    }
}