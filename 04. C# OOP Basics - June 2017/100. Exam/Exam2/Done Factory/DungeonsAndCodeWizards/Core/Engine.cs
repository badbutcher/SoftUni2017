namespace DungeonsAndCodeWizards.Core
{
    using System;
    using System.Linq;

    public class Engine
    {
        private DungeonMaster manager;
        private bool exit;
        private bool gameOver;

        public Engine()
        {
            this.manager = new DungeonMaster();
            this.exit = false;
            this.gameOver = false;
        }

        public void Run()
        {
            while (!exit && !gameOver)
            {
                try
                {
                    string input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input))
                    {
                        exit = true;
                        break;
                    }

                    string[] cmdArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string command = cmdArgs[0];
                    cmdArgs = cmdArgs.Skip(1).ToArray();

                    switch (command)
                    {
                        case "JoinParty":
                            Console.WriteLine(manager.JoinParty(cmdArgs));
                            break;
                        case "AddItemToPool":
                            Console.WriteLine(manager.AddItemToPool(cmdArgs));
                            break;
                        case "PickUpItem":
                            Console.WriteLine(manager.PickUpItem(cmdArgs));
                            break;
                        case "UseItem":
                            Console.WriteLine(manager.UseItem(cmdArgs));
                            break;
                        case "UseItemOn":
                            Console.WriteLine(manager.UseItemOn(cmdArgs));
                            break;
                        case "GiveCharacterItem":
                            Console.WriteLine(manager.GiveCharacterItem(cmdArgs));
                            break;
                        case "Attack":
                            Console.WriteLine(manager.Attack(cmdArgs));
                            break;
                        case "Heal":
                            Console.WriteLine(manager.Heal(cmdArgs));
                            break;
                        case "EndTurn":
                            Console.WriteLine(manager.EndTurn(cmdArgs));
                            break;
                        case "GetStats":
                            Console.WriteLine(manager.GetStats());
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Parameter Error: " + ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Invalid Operation: " + ex.Message);
                }

                gameOver = manager.IsGameOver();
            }

            if (gameOver || exit)
            {
                Console.WriteLine("Final stats:");
                Console.WriteLine(manager.GetStats());
            }
        }
    }
}