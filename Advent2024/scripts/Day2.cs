namespace Advent2024
{
    public class Day2
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
            int totalSafes = 0;

            foreach (string line in input)
            {
                bool increase, safe;
                List<int> nums = [];

                foreach (string num in line.Split(' ')) nums.Add(Convert.ToInt32(num));

                if (IsSafe(nums)) totalSafes++;
            }
            Console.WriteLine("Total Safe Reports: " + totalSafes);
        }
        static void P2(string[] input)
        {
            int totalSafes = 0;

            foreach (string line in input)
            {
                bool safe = false;
                List<int> nums = [];

                foreach (string num in line.Split(' ')) nums.Add(Convert.ToInt32(num));


                if (!IsSafe(nums))
                {
                    for (int i = 0; i < nums.Count; i++)
                    {
                        List<int> newNums = nums.Take(i).ToList();
                        newNums.AddRange(nums.Skip(i + 1));
                        if (IsSafe(newNums)) safe = true;
                    }
                }
                else safe = true;

                if (safe) totalSafes++;
            }
            Console.WriteLine("Total Safe Reports: " + totalSafes);
        }
        static public bool IsSafe(List<int> nums)
        {
            bool safe = true, increase = nums[0] < nums[1];
            for (int i = 1; i < nums.Count && safe; i++)
            {
                safe = (increase ? nums[i - 1] < nums[i] : nums[i - 1] > nums[i])
                    && Math.Abs(nums[i - 1] - nums[i]) >= 1
                    && Math.Abs(nums[i - 1] - nums[i]) <= 3;
            }
            return safe;
        }
    }
}