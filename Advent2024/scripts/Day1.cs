namespace Advent2024
{
    public class Day1
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
            List<int> leftList = [];
            List<int> rigthList = [];
            int total = 0;

            foreach (string line in input)
            {
                leftList.Add(Convert.ToInt32(line.Split(" ").Where(line => line != "").ToList()[0]));
                rigthList.Add(Convert.ToInt32(line.Split(" ").Where(line => line != "").ToList()[1]));
            }

            leftList.Sort();
            rigthList.Sort();

            for (int i = 0; i < leftList.Count; i++) total += Math.Abs(leftList[i] - rigthList[i]);

            Console.WriteLine("Total: " + total);
        }
        static void P2(string[] input)
        {
            List<int> leftList = [];
            List<int> rigthList = [];
            int total = 0;

            foreach (string line in input)
            {
                leftList.Add(Convert.ToInt32(line.Split(" ").Where(line => line != "").ToList()[0]));
                rigthList.Add(Convert.ToInt32(line.Split(" ").Where(line => line != "").ToList()[1]));
            }

            leftList.Sort();
            rigthList.Sort();

            for (int i = 0; i < leftList.Count; i++)
            {
                total += leftList[i] * rigthList.Where(num => num == leftList[i]).Count();
            }

            Console.WriteLine("Total: " + total);
        }
    }
}