using System.Diagnostics;

namespace Advent_Of_Code_2023
{
    public class Day3
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
            int x, y, total = 0;
            foreach (string line in input)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == 'm' && i + 7 < line.Length && line[i..(i+4)] == "mul(")
                    {
                        string[] splitCom = line[(i + 4)..].Split(",");
                        if (splitCom.Length > 0 && int.TryParse(splitCom[0], out x))
                        {
                            if (int.TryParse(splitCom[1].Split(")")[0], out y) && splitCom.Length > 1)
                            {
                                //Console.WriteLine($"Total= {total} + {x} * {y} = {total + x*y}");
                                total += x * y;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Total: " + total);
        }
        static void P2(string[] input)
        {
            bool canDo = true;
            int x, y, total = 0;
            foreach (string line in input)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == 'd')
                    {
                        if (i + 4 < line.Length && line[i..(i + 4)] == "do()") canDo = true;
                        if (i + 7 < line.Length && line[i..(i + 7)] == "don't()") canDo = false;
                    }
                    if (line[i] == 'm' && i + 7 < line.Length && line[i..(i + 4)] == "mul(")
                    {
                        string[] splitCom = line[(i + 4)..].Split(",");
                        if (splitCom.Length > 0 && int.TryParse(splitCom[0], out x))
                        {
                            if (int.TryParse(splitCom[1].Split(")")[0], out y) && splitCom.Length > 1)
                            {
                                if (canDo)
                                {
                                    //Console.WriteLine($"Total= {total} + {x} * {y} = {total + x * y}");
                                    total += x * y;
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