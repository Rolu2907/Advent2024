using System.Collections;
using System.Numerics;
using System.Xml.XPath;

namespace Advent2024
{
    public class Day8
    {
        static public void Main(string part, string[] input)
        {
            switch (part)
            {
                case "1":
                    P1(input);
                    break;
                case "2":
                    P2(input);
                    break;
            }
        }
        static void P1(string[] input)
        {
            char[,] matrix = new char[input.Length, input[0].Length];
            List<int[]> antinodes = [];

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    matrix[i, j] = input[i][j];
                }
            }

            int total = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] != '.')
                    {
                        for (int x = 0; x < matrix.GetLength(0); x++)
                        {
                            for (int y = 0; y < matrix.GetLength(1); y++)
                            {
                                if (matrix[i,j] == matrix[x, y] && !(i == x && j == y))
                                {
                                    int a = i - (x - i);
                                    int b = j - (y - j);
                                    if (a >= 0 && a < matrix.GetLength(0) && b >= 0 && b < matrix.GetLength(1))
                                    {
                                        if(!antinodes.Any(item => item[0] == a && item[1] == b))
                                        {
                                            antinodes.Add([a, b]);
                                            total++;
                                        }
                                    }

                                    a = x - (i - x);
                                    b = y - (j - y);
                                    if (a >= 0 && a < matrix.GetLength(0) && b >= 0 && b < matrix.GetLength(1))
                                    {
                                        if (!antinodes.Any(item => item[0] == a && item[1] == b))
                                        {
                                            antinodes.Add([a, b]);
                                            total++;;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Total: " + total);
        }
        static void P2(string[] input)
        {
            char[,] matrix = new char[input.Length, input[0].Length];
            char[,] matrixTest = new char[input.Length, input[0].Length];
            List<int[]> antinodes = [];

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    matrix[i, j] = input[i][j];
                }
            }

            int total = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != '.')
                    {
                        for (int x = 0; x < matrix.GetLength(0); x++)
                        {
                            for (int y = 0; y < matrix.GetLength(1); y++)
                            {
                                if (matrix[i, j] == matrix[x, y] && !(i == x && j == y))
                                {
                                    int a = i;
                                    int b = j;
                                    while (a >= 0 && a < matrix.GetLength(0) && b >= 0 && b < matrix.GetLength(1))
                                    {
                                        if (!antinodes.Any(item => item[0] == a && item[1] == b))
                                        {
                                            antinodes.Add([a, b]);
                                            total++;
                                        }
                                        a -= x - i;
                                        b -= y - j;
                                    }

                                    a = x;
                                    b = y;
                                    while (a >= 0 && a < matrix.GetLength(0) && b >= 0 && b < matrix.GetLength(1))
                                    {
                                        if (!antinodes.Any(item => item[0] == a && item[1] == b))
                                        {
                                            antinodes.Add([a, b]);
                                            total++;
                                        }
                                        a -= i - x;
                                        b -= j - y;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Total: " + total);
        }
    }
}