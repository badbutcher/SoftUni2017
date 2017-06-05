using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _010
{
    class Program
    {
        private const int ChamberSize = 15;
        private const int CloudDamage = 3500;
        private const int EruptionDamage = 6000;
        private const double PlayerHealth = 18500;
        private const double HeiganHealth = 3000000;

        static void Main()
        {
            var playerPos = new int[] { ChamberSize / 2, ChamberSize / 2 };
            var heiganPoints = HeiganHealth;
            var playerPoints = PlayerHealth;

            var isHeiganDead = false;
            var isPlayerDead = false;
            var hasCloud = false;
            var deathCause = string.Empty;

            var damageToHeigan = double.Parse(Console.ReadLine());

            while (true)
            {
                var spellToken = Console.ReadLine().Split();
                var spell = spellToken[0];
                var spellRow = int.Parse(spellToken[1]);
                var spellCol = int.Parse(spellToken[2]);

                heiganPoints -= damageToHeigan;
                isHeiganDead = heiganPoints <= 0;

                if (hasCloud)
                {
                    playerPoints -= CloudDamage;
                    hasCloud = false;
                    isPlayerDead = playerPoints <= 0;
                }

                if (isHeiganDead || isPlayerDead)
                {
                    break;
                }

                if (IsPlayerInDamageZone(playerPos, spellRow, spellCol))
                {
                    if (!PlayerTryEscape(playerPos, spellCol, spellRow))
                    {
                        switch (spell)
                        {
                            case "Cloud":
                                playerPoints -= CloudDamage;
                                hasCloud = true;
                                deathCause = "Plague Cloud";
                                break;
                            case "Eruption":
                                playerPoints -= EruptionDamage;
                                deathCause = spell;
                                break;
                            default:
                                break;
                        }
                    }
                }

                isPlayerDead = playerPoints <= 0;
                if (isPlayerDead)
                {
                    break;
                }
            }

            PrintResult(playerPos, heiganPoints, playerPoints, deathCause);
        }

        private static void PrintResult(int[] playerPos, double heiganPoints, double playerPoints, string deathCause)
        {
            if (heiganPoints <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganPoints:F2}");
            }

            if (playerPoints <= 0)
            {
                Console.WriteLine($"Player: Killed by {deathCause}");
            }
            else
            {
                Console.WriteLine($"Player: {playerPoints}");
            }

            Console.WriteLine($"Final position: {playerPos[0]}, {playerPos[1]}");
        }

        private static bool PlayerTryEscape(int[] playrtPos, int spellCol, int spellRow)
        {
            if (playrtPos[0] - 1 >= 0 && playrtPos[0] - 1 < spellRow - 1)
            {
                playrtPos[0]--;
                return true;
            }
            else if (playrtPos[1] + 1 < ChamberSize && playrtPos[1] + 1 > spellCol + 1)
            {
                playrtPos[1]++;
                return true;
            }
            else if (playrtPos[0] + 1 < ChamberSize && playrtPos[0] + 1 > spellRow + 1)
            {
                playrtPos[0]++;
                return true;
            }
            else if (playrtPos[1] - 1 >= 0 && playrtPos[1] - 1 < spellCol - 1)
            {
                playrtPos[1]--;
                return true;
            }

            return false;
        }

        private static bool IsPlayerInDamageZone(int[] playrtPos, int spellRow, int spellCol)
        {
            bool isHitRow = playrtPos[0] >= spellRow - 1 && playrtPos[0] <= spellRow + 1;

            bool isHirCol = playrtPos[1] >= spellCol - 1 && playrtPos[1] <= spellCol + 1;

            return isHirCol && isHitRow;
        }
    }
}