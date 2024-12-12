namespace Advent2024
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
                            if(!IsCorrect(list[i], pair, list))
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
            List<int[]> order = [];
            int total = 0;

            foreach(string line in input)
            {
                bool reordered = false;
                List<int> list = [];
                if(line.Contains('|'))
                {
                    int[] nums = [Convert.ToInt32(line.Split('|')[0]), Convert.ToInt32(line.Split('|')[1])];
                    order.Add(nums);
                }
                else if(line.Contains(','))
                {
                    list = [];
                    
                    Console.WriteLine("Line: " + line);

                    foreach (string num in line.Split(',')) list.Add(Convert.ToInt32(num));
                    for (int i = 0, j = 0; i < list.Count; i++)
                    {
                        foreach (int[] pair in order.Where(item => item.Contains(list[i]) && list.Contains(item[0]) && list.Contains(item[1])))
                        {
                            if(!IsCorrect(list[i], pair, list)) 
                            {
                                reordered = true;
                                int temp = list[i];
                                list.Remove(list[i]);
                                switch(Array.IndexOf(pair, temp))
                                {
                                    case 0:
                                        list.Insert(j, temp);
                                    break;
                                    case 1:
                                        list.Insert(list.Count - j, temp);
                                    break;
                                }
                                j++;
                                i = -1;
                                Console.Write("Trying: ");
                                foreach(int num in list) Console.Write(num + ",");
                                Console.WriteLine();
                                break;
                            }
                            j = 0;
                        }
                    }
                }
                if(reordered) {
                    Console.Write("Reordered to: ");
                    foreach(int num in list) Console.Write(num + ",");
                    Console.WriteLine();
                    total += list[list.Count / 2];
                }
            }
            Console.WriteLine("Total: " + total);
        }
        static bool IsCorrect(int n, int[] pair, List<int> list)        
        {
            return n == pair[0] && list.IndexOf(n) < list.IndexOf(pair[1]) || n == pair[1] && list.IndexOf(n) > list.IndexOf(pair[0]);
        }
    }
}