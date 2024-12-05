using System.Diagnostics;

namespace Advent_Of_Code_2023
{
    public class Day5
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
            List<int[]> order = [];
            int total = 0;

            foreach(string line in input)
            {
                List<int> list = [];
                bool correct = false;
                if(line.Contains('|'))
                {
                    int[] nums = [Convert.ToInt32(line.Split('|')[0]), Convert.ToInt32(line.Split('|')[1])];
                    order.Add(nums);
                }
                else if(line.Contains(','))
                {
                    correct = true;
                    list = [];
                    
                    Console.WriteLine("Line: " + line);

                    foreach (string num in line.Split(',')) list.Add(Convert.ToInt32(num));
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine("Numero: " + list[i]);
                        foreach (int[] pair in order.Where(item => item.Contains(list[i]) && list.Contains(item[0]) && list.Contains(item[1])))
                        {
                            if(!(list[i] == pair[0] && i < list.IndexOf(pair[1]))
                            && !(list[i] == pair[1] && i > list.IndexOf(pair[0]))) 
                            {
                                correct = false;
                                Console.WriteLine($"Incorrect Line!!! pair: {pair[0]}, {pair[1]}");
                            }
                        }
                    }
                }
                if(correct) total += list[list.Count / 2];
            }
            Console.WriteLine("Total: " + total);
        }
        static void P2(string[] input)
        {

        }
    }
}