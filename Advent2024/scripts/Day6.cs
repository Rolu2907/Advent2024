using System.Diagnostics;
using System.Globalization;
using System.Numerics;

namespace Advent_Of_Code_2023
{
    public class Day6
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
            char[,] matrix = new char[input.Length,input[0].Length];
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    matrix[i,j] = input[i][j];
                }
            }
            while(Forward(ref matrix)) {
                //Thread.Sleep(200);
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }

            int total = 0;
            foreach (var pos in matrix)
            {
                if(pos == 'X') total++;
            }
            Console.WriteLine("Total positions: " + total);
        }
        static void P2(string[] input)
        {

        }
        static bool Forward(ref char[,] input) {
            bool located = false;
            bool end = false;
            int[] loc = [];
            char[] possibles = {'^','>','<','v'};

            for (int i = 0; i < input.GetLength(0) && !located; i++)
            {
                for (int j = 0; j < input.GetLength(1) && !located; j++)
                {
                    if(possibles.Contains(input[i,j])) {
                        loc = [i,j];
                        located = true;
                    }
                }
            }

            switch(input[loc[0],loc[1]])
            {
                case '^':
                    for (int i = loc[0]; i >= 0 && !end; i--)
                    {
                        if(input[i,loc[1]] == '#') {
                            input[i + 1,loc[1]] = '>';
                            end = true;
                        }
                        if(!end)input[i,loc[1]] = 'X';
                    }
                break;
                case '>':
                    for (int i = loc[1]; i < input.GetLength(1) && !end; i++)
                    {
                        if(input[loc[0],i] == '#') {
                            input[loc[0],i - 1] = 'v';
                            end = true;
                        }
                        if(!end)input[loc[0],i] = 'X';
                    }
                break;
                case '<':
                    for (int i = loc[1]; i >= 0 && !end; i--)
                    {
                        if(input[loc[0],i] == '#') {
                            input[loc[0],i + 1] = '^';
                            end = true;
                        }
                        if(!end)input[loc[0],i] = 'X';
                    }
                break;
                case 'v':
                    for (int i = loc[0]; i < input.GetLength(0) && !end; i++)
                    {
                        if(input[i,loc[1]] == '#') {
                            input[i - 1,loc[1]] = '<';
                            end = true;
                        }
                        if(!end)input[i,loc[1]] = 'X';
                    }
                break;
            }
            return end;
        }
    }
}