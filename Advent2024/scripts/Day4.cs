using System.Diagnostics;

namespace Advent_Of_Code_2023
{
    public class Day4
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
            int total = 0;
            char[,] input2 = new char[input.Length, input[0].Length];

            for (int i = 0; i < input2.GetLength(0); i++)
            {
                for (int j = 0; j < input2.GetLength(1); j++)
                {
                    input2[i, j] = '.';
                }
            }
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    for (int d = 1; d < 9; d++)
                    {
                        if (CheckXMAS(input, i, j, d, ref input2)) total++;
                    }
                }
            }
            for (int i = 0; i < input2.GetLength(0); i++)
            {
                for (int j = 0; j < input2.GetLength(1); j++)
                {
                    Console.Write(input2[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Total: " + total);
        }
        static void P2(string[] input)
        {
            int total = 0;
            char[,] input2 = new char[input.Length, input[0].Length];

            for (int i = 0; i < input2.GetLength(0); i++)
            {
                for (int j = 0; j < input2.GetLength(1); j++)
                {
                    input2[i, j] = '.';
                }
            }
            for (int i = 1; i < input.Length - 1; i++)
            {
                for (int j = 1; j < input[i].Length - 1; j++)
                {
                    if (CheckX_MAS(input, i, j, ref input2)) total++;
                }
            }
            for (int i = 0; i < input2.GetLength(0); i++)
            {
                for (int j = 0; j < input2.GetLength(1); j++)
                {
                    Console.Write(input2[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Total: " + total);
        }
        static bool CheckXMAS(string[] input, int line, int index, int direction, ref char[,] input2)
        {
            if(input[line][index] != 'X') return false;
            switch (direction)
            {
                case 1: // Up Left
                    if (line >= 3 && index >= 3)
                    {
                        string result = $"{input[line][index]}"
                        + $"{input[line - 1][index - 1]}"
                        + $"{input[line - 2][index - 2]}"
                        + $"{input[line - 3][index - 3]}";

                        if (result == "XMAS")
                        {
                            input2[line, index] = input[line][index];
                            input2[line - 1, index - 1] = input[line - 1][index - 1];
                            input2[line - 2, index - 2] = input[line - 2][index - 2];
                            input2[line - 3, index - 3] = input[line - 3][index - 3];
                            return true;
                        }
                    }
                    break;
                case 2: // Up
                     if (line >= 3)
                     {
                        string result = $"{input[line][index]}"
                        + $"{input[line - 1][index]}"
                        + $"{input[line - 2][index]}"
                        + $"{input[line - 3][index]}";

                        if (result == "XMAS")
                        {
                            input2[line, index] = input[line][index];
                            input2[line - 1, index] = input[line - 1][index];
                            input2[line - 2, index] = input[line - 2][index];
                            input2[line - 3, index] = input[line - 3][index];
                            return true;
                        }
                     }
                    break;
                case 3: // Up Right
                    if (line >= 3 && index < input[0].Length - 3)
                    {
                        string result = $"{input[line][index]}"
                        + $"{input[line - 1][index + 1]}"
                        + $"{input[line - 2][index + 2]}"
                        + $"{input[line - 3][index + 3]}";

                        if (result == "XMAS")
                        {
                            input2[line, index] = input[line][index];
                            input2[line - 1, index + 1] = input[line - 1][index + 1];
                            input2[line - 2, index + 2] = input[line - 2][index + 2];
                            input2[line - 3, index + 3] = input[line - 3][index + 3];
                            return true;
                        }
                    }
                    break;
                case 4: // Right
                    if (index < input[0].Length - 3)
                    {
                        string result = $"{input[line][index]}"
                        + $"{input[line][index + 1]}"
                        + $"{input[line][index + 2]}"
                        + $"{input[line][index + 3]}";

                        if (result == "XMAS")
                        {
                            input2[line, index] = input[line][index];
                            input2[line, index + 1] = input[line][index + 1];
                            input2[line, index + 2] = input[line][index + 2];
                            input2[line, index + 3] = input[line][index + 3];
                            return true;
                        }
                    }
                    break;
                case 5: // Down Right
                    if (line < input.Length - 3 && index < input[0].Length - 3)
                    {
                        string result = $"{input[line][index]}"
                        + $"{input[line + 1][index + 1]}"
                        + $"{input[line + 2][index + 2]}"
                        + $"{input[line + 3][index + 3]}";

                        if (result == "XMAS")
                        {
                            input2[line, index] = input[line][index];
                            input2[line + 1, index + 1] = input[line + 1][index + 1];
                            input2[line + 2, index + 2] = input[line + 2][index + 2];
                            input2[line + 3, index + 3] = input[line + 3][index + 3];
                            return true;
                        }
                    }
                    break;
                case 6: // Down
                    if (line < input.Length - 3)
                    {
                        string result = $"{input[line][index]}"
                        + $"{input[line + 1][index]}"
                        + $"{input[line + 2][index]}"
                        + $"{input[line + 3][index]}";

                        if (result == "XMAS")
                        {
                            input2[line, index] = input[line][index];
                            input2[line + 1, index] = input[line + 1][index];
                            input2[line + 2, index] = input[line + 2][index];
                            input2[line + 3, index] = input[line + 3][index];
                            return true;
                        }
                    }
                    break;
                case 7: // Down Left
                    if (line < input.Length - 3 && index >= 3)
                    {
                        string result = $"{input[line][index]}"
                        + $"{input[line + 1][index - 1]}"
                        + $"{input[line + 2][index - 2]}"
                        + $"{input[line + 3][index - 3]}";

                        if (result == "XMAS")
                        {
                            input2[line, index] = input[line][index];
                            input2[line + 1, index - 1] = input[line + 1][index - 1];
                            input2[line + 2, index - 2] = input[line + 2][index - 2];
                            input2[line + 3, index - 3] = input[line + 3][index - 3];
                            return true;
                        }
                    }
                    break;
                case 8: // Left
                    if (index >= 3)
                    {
                        string result = $"{input[line][index]}"
                        + $"{input[line][index - 1]}"
                        + $"{input[line][index - 2]}"
                        + $"{input[line][index - 3]}";

                        if (result == "XMAS")
                        {
                            input2[line, index] = input[line][index];
                            input2[line, index - 1] = input[line][index - 1];
                            input2[line, index - 2] = input[line][index - 2];
                            input2[line, index - 3] = input[line][index - 3];
                            return true;
                        }
                    }
                    break;
            }
            return false;
        }
        static bool CheckX_MAS(string[] input, int line, int index, ref char[,] input2)
        {
            if (input[line][index] != 'A') return false;

            char[] diag1 = [input[line - 1][index - 1], input[line + 1][index + 1]];
            char[] diag2 = [input[line - 1][index + 1], input[line + 1][index - 1]];

            input2[line, index] = input[line][index];

            if (diag1.Contains('S') && diag1.Contains('M') && diag2.Contains('S') && diag2.Contains('M'))
            {
                input2[line - 1, index - 1] = input[line - 1][index - 1];
                input2[line + 1, index + 1] = input[line + 1][index + 1];
                input2[line - 1, index + 1] = input[line - 1][index + 1];
                input2[line + 1, index - 1] = input[line + 1][index - 1];

                return true;
            }

            return false;
        }
    }
}