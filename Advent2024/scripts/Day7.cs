using System.Collections;
using System.Xml.XPath;

namespace Advent2024
{
    public class Day7
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
            long total = 0;
            foreach(string line in input)
            {
                Console.WriteLine(line.Split(':')[0]);
                long goal = Convert.ToInt64(line.Split(':')[0]);
                List<long> nums = [];
                long result = 0;

                foreach(string item in line.Split(':')[1].Split(' '))
                {
                    if(long.TryParse(item, out long n)) nums.Add(n);
                }
                bool[] operators = new bool[nums.Count - 1];
                bool end = false;
                do
                {
                    result = nums[0];
                    end = false;
                    for(int i = 1; i < nums.Count; i++)
                    {
                        if(operators[i-1]) result *= nums[i];
                        else result += nums[i];
                    }
                    if(result == goal)
                    {
                        end = true;
                        total += result;
                    }
                    end = result == goal;
                    if(operators.Any(item => !item)) AddToOperators(ref operators, 0);
                    else end = true;
                } while(!end);
            }
            Console.WriteLine("Total: " + total);
        }
        static void AddToOperators(ref bool[] operators, int index)
        {
            if(index >= operators.Length) return;
            operators[index] = !operators[index];
            if(!operators[index]) AddToOperators(ref operators, index + 1);
        }
        static void P2(string[] input)
        {     

        }
    }
}