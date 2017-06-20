namespace _002CubicsRube
{
    using System;
    using System.Numerics;

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[][][] cube = new int[n][][];

            for (int i = 0; i < cube.Length; i++)
            {
                cube[i] = new int[n][];

                for (int j = 0; j < cube[i].Length; j++)
                {
                    cube[i][j] = new int[n];
                }
            }

            BigInteger count = 0;
            BigInteger notChanged = n * n * n;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Analyze")
                {
                    break;
                }
                else
                {
                    string[] data = input.Trim().Split();
                    long x = long.Parse(data[0]);
                    long y = long.Parse(data[1]);
                    long z = long.Parse(data[2]);
                    long bomb = long.Parse(data[3]);

                    //for (int mX = 0; mX < n; mX++)
                    //{
                    //    for (int mY = 0; mY < n; mY++)
                    //    {
                    //        for (int mZ = 0; mZ < n; mZ++)
                    //        {
                    //            if (mX == x && mY == y && mZ == z)
                    //            {
                    //                if (cube[mX][mY][mZ] == 0)
                    //                {
                    //                    cube[mX][mY][mZ] = 1;
                    //                    count += bomb;
                    //                    notChanged--;
                    //                    break;
                    //                }
                    //            }
                    //        }
                    //    }
                    //}

                    if (x >= 0 && x < n && y >= 0 && y < n && z >= 0 && z < n)
                    {
                        if (bomb > 0)
                        {
                            count += bomb;
                            notChanged--;
                        }
                    }
                }
            }

            Console.WriteLine(count);
            Console.WriteLine(notChanged);
        }
    }
}