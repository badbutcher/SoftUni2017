using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003
{
    class Program
    {
        static void Main()
        {
            Queue<string> playerOne = new Queue<string>(Console.ReadLine().Split());
            Queue<string> playerTwo = new Queue<string>(Console.ReadLine().Split());

            Queue<string> playerOneDraw = new Queue<string>();
            Queue<string> playerTwoDraw = new Queue<string>();

            bool isDraw = false;

            int turns = 0;
            while (playerOne.Count > 0 && playerTwo.Count > 0)
            {
                string playerOneCard = playerOne.Peek();
                string playerTwoCard = playerTwo.Peek();
                int pOneNumber = int.Parse(playerOneCard.Substring(0, playerOneCard.Length - 1));
                int pTwoNumber = int.Parse(playerTwoCard.Substring(0, playerTwoCard.Length - 1));
                
                turns++;
                if (pOneNumber > pTwoNumber)
                {
                    playerOne.Enqueue(playerOne.Dequeue());
                    playerOne.Enqueue(playerTwo.Dequeue());
                }
                else if (pOneNumber < pTwoNumber)
                {
                    playerTwo.Enqueue(playerTwo.Dequeue());
                    playerTwo.Enqueue(playerOne.Dequeue());
                }
                else if (pOneNumber == pTwoNumber)
                {
                    int leftSum = 0;
                    int rightSum = 0;
                    while (leftSum == rightSum && playerOne.Count > 0 && playerTwo.Count > 0)
                    {
                        if (!isDraw)
                        {
                            playerOneDraw.Enqueue(playerOne.Dequeue());
                            playerTwoDraw.Enqueue(playerTwo.Dequeue());
                        }

                        int cardsLeft = playerOne.Count;

                        if (cardsLeft > 3)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                playerOneCard = playerOne.Dequeue();
                                playerTwoCard = playerTwo.Dequeue();
                                char pOneChar = playerOneCard.Last();
                                char pTwoChar = playerTwoCard.Last();
                                playerOneDraw.Enqueue(playerOneCard);
                                playerTwoDraw.Enqueue(playerTwoCard);
                                leftSum += pOneChar;
                                rightSum += pTwoChar;
                            }
                        }
                        else
                        {
                            for (int i = 0; i < cardsLeft; i++)
                            {
                                playerOneCard = playerOne.Dequeue();
                                playerTwoCard = playerTwo.Dequeue();
                                char pOneChar = playerOneCard.Last();
                                char pTwoChar = playerTwoCard.Last();
                                playerOneDraw.Enqueue(playerOneCard);
                                playerTwoDraw.Enqueue(playerTwoCard);
                                leftSum += pOneChar;
                                rightSum += pTwoChar;
                            }
                        }

                        

                        if (leftSum == rightSum)
                        {
                            isDraw = true;
                            continue;
                        }
                        else
                        {
                            isDraw = false;
                            if (leftSum > rightSum)
                            {
                                Queue<string> sortOne = new Queue<string>(playerOneDraw.OrderByDescending(a => int.Parse(a.Substring(0, a.Length - 1))).ThenByDescending(c => c.Last()));
                                foreach (var item in sortOne)
                                {
                                    playerOne.Enqueue(item);
                                }
                                Queue<string> sortTwo = new Queue<string>(playerTwoDraw.OrderByDescending(a => int.Parse(a.Substring(0, a.Length - 1))).ThenByDescending(c => c.Last()));
                                foreach (var item in sortTwo)
                                {
                                    playerOne.Enqueue(item);
                                }
                            }
                            else if (leftSum < rightSum)
                            {
                                Queue<string> sortTwo = new Queue<string>(playerTwoDraw.OrderByDescending(a => int.Parse(a.Substring(0, a.Length - 1))).ThenByDescending(c => c.Last()));
                                foreach (var item in sortTwo)
                                {
                                    playerOne.Enqueue(item);
                                }

                                Queue<string> sortOne = new Queue<string>(playerOneDraw.OrderByDescending(a => int.Parse(a.Substring(0, a.Length - 1))).ThenByDescending(c => c.Last()));
                                foreach (var item in sortOne)
                                {
                                    playerOne.Enqueue(item);
                                }
                            }

                            break;
                        }
                    }       
                }
                else if (turns >= 1000000)
                {
                    break;
                }
            }

            if (isDraw)
            {
                Console.WriteLine($"Draw after {turns} turns");
            }
            else if (playerOne.Count > 0)
            {
                Console.WriteLine($"First player wins after {turns} turns");
            }
            else if (playerTwo.Count > 0)
            {
                Console.WriteLine($"Second player wins after {turns} turns");
            }
        }
    }
}