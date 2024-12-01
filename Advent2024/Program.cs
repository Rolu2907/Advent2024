namespace Advent_Of_Code_2023
{
    internal class Adviento
    {
        static readonly string baseLoc = @"..\..\..";
        static void Main()
        {
            string day, part;
            bool example;

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("-----Advent Of Code 2021-------------\n\n Introduce el día: ");
            day = Console.ReadLine();

            Console.Write("\n Introduce la parte: ");
            part = Console.ReadLine();
            Console.Clear();

            Console.Write("\n ¿Hacer la prueba? (Y/Any)");

            example = new char[] { 'Y', 'y' }.Contains(Console.ReadKey().KeyChar);
            Console.Clear();
            Console.Write($"Día {day} - Parte {part} ---------------->\n\n");

            Day(day, part, example);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n Pulsa cualquier tecla para salir...");
            Console.ReadKey(true);
        }
        static void Day(string day, string part, bool example)
        {
            string[] input;

            if (example)
            {
                if (part == "1") input = File.ReadAllLines(@$"{baseLoc}\inputs\day{day}_prueba.txt");
                else input = File.ReadAllLines(@$"{baseLoc}\inputs\day{day}_prueba2.txt");
            }
            else input = File.ReadAllLines(@$"{baseLoc}\inputs\day{day}.txt");


            switch ($"{day}_{part}")
            {
                case "1_1":
                    Day1.P1(input);
                    break;
                //case "1_2":
                //    Day1.P2(input);
                //    break;
                //case "2_1":
                //    Day2_1(input);
                //    break;
                //case "2_2":
                //    Day2_2(input);
                //    break;
                //case "3_1":
                //    Day3_1(input);
                //    break;
                //case "3_2":
                //    Day3_2(input);
                //    break;
                //case "4_1":
                //    Day4_1(input);
                //    break;
                //case "4_2":
                //    Day4_2(input);
                //    break;
                //case "5_1":
                //    Day5_1(input);
                //    break;
                //case "5_2":
                //    Day5_2(input);
                //    break;
                //case "6_1":
                //    Day6_1(input);
                //    break;
                //case "6_2":
                //    Day6_2(input);
                //    break;
                //case "7_1":
                //    Day7_1(input);
                //    break;
                //case "7_2":
                //    Day7_2(input);
                //    break;
                //case "8_1":
                //    Day8_1(input);
                //    break;
                //case "8_2":
                //    Day8_2(input);
                //    break;
                //case "9_1":
                //    Day9_1(input);
                //    break;
                //case "9_2":
                //    Day9_2(input);
                //    break;
                //case "10_1":
                //    Day10_1(input);
                //    break;
                //case "10_2":
                //    Day10_2(input);
                //    break;
                //case "11_1":
                //    Day11_1(input);
                //    break;
                //case "11_2":
                //    Day11_2(input);
                //    break;
                //case "12_1":
                //    Day12_1(input);
                //    break;
                //case "12_2":
                //    Day12_2(input);
                //    break;
                //case "13_1":
                //    Day13_1(input);
                //    break;
                //case "13_2":
                //    Day13_2(input);
                //    break;
                //case "14_1":
                //    Day14_1(input);
                //    break;
                //case "14_2":
                //    Day14_2(input);
                //    break;
                //case "15_1":
                //    Day15_1(input);
                //    break;
                //case "15_2":
                //    Day15_2(input);
                //    break;
            }
        }
    }
}
