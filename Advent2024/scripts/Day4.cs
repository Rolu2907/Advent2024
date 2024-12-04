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
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    for (int d = 1; d < 9; d++)
                    {
                        CheckXMAS(input, i, j, d);
                    }
                }
            }
            CheckXMAS(input, 3, 9, 2);
        }
        static void P2(string[] input)                   
        {

        }
        static void CheckXMAS(string[] input, int line, int index, int direction)
        {//<>
        Console.WriteLine($"Comprobando linea {line} puesto {index} dir {direction} ");
            char[,] input2 = new char[input.Length,input[0].Length];

            for (int i = 0; i < input2.GetLength(0); i++)
            {
                for (int j = 0; j < input2.GetLength(1); j++)
                {
                    input2[i,j] = '.';
                }
            }
            if(input[line][index] != 'X') return;
            switch (direction)
            {
                case 1: // Up Left
                break;
                case 2: // Up
                    //Forward
                    // if(line >= charIndex && line - charIndex + 3 < input.Length && charIndex != -1)
                    // {
                    //     string result = $"{input[line][index]}"
                    //     + $"{input[line + 1][index]}"
                    //     + $"{input[line + 2][index]}"
                    //     + $"{input[line + 3][index]}";
                    //     if(result == "XMAS")
                    //     {
                    //         input2[line,index] = input[line][index];
                    //         input2[line + 1,index] = input[line + 1][index];
                    //         input2[line + 2,index] = input[line + 2][index];
                    //         input2[line + 3,index] = input[line + 3][index];
                    //     }
                    // }
                break;
                case 3: // Up Right
                break;
                case 4: // Right
                break;
                case 5: // Down Right
                break;
                case 6: // Down
                break;
                case 7: // Down Left
                break;
                case 8: // Left
                break;
            }
            for (int i = 0; i < input2.GetLength(0); i++)
            {
                for (int j = 0; j < input2.GetLength(1); j++)
                {
                    Console.Write(input2[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}