namespace Advent_Of_Code_2023
{
    internal class Advent
    {
        static readonly string baseLoc = "";//Path.Join("..", "..", "..");
        static void Main()
        {
            string day, part;
            bool example;

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("-----Advent Of Code 2021-------------\n\n Introduce el día: ");
            day = "5";//Console.ReadLine();

            Console.Write("\n Introduce la parte: ");
            part =  "1";//Console.ReadLine();
            Console.Clear();

            Console.Write("\n ¿Hacer la prueba? (Y/Any)");

            example = false;//new char[] { 'Y', 'y' }.Contains(Console.ReadKey().KeyChar);
            Console.Clear();
            Console.Write($"Día {day} - Parte {part} ---------------->\n\n");

            Day(day, part, example);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n Pulsa cualquier tecla para salir...");
            //Console.ReadKey(true);
        }
        static void Day(string day, string part, bool example)
        {
            string[] input;

            
            input = File.ReadAllLines(Path.Join(baseLoc, "inputs", "day" + day, (example ? "example" + (part == "1" ? "" : "2") : "normal") + ".txt"));
            

            switch (day)
            {
                case "1":
                    Day1.Main(part, input);
                    break;
                case "2":
                    Day2.Main(part, input);
                    break;
                case "3":
                    Day3.Main(part, input);
                    break;
                case "4":
                   Day4.Main(part, input);
                   break;
                case "5":
                    Day5.Main(part, input);
                    break;
                    //case "6":
                    //    Day6.Main(part, input);
                    //    break;
                    //case "7":
                    //    Day7.Main(part, input);
                    //    break;
                    //case "8":
                    //    Day8.Main(part, input);
                    //    break;
                    //case "9":
                    //    Day9.Main(part, input);
                    //    break;
                    //case "10":
                    //    Day10.Main(part, input);
                    //    break;
                    //case "11":
                    //    Day11.Main(part, input);
                    //    break;
                    //case "12":
                    //    Day12.Main(part, input);
                    //    break;
                    //case "13":
                    //    Day13.Main(part, input);
                    //    break;
                    //case "14":
                    //    Day14.Main(part, input);
                    //    break;
                    //case "15":
                    //    Day15.Main(part, input);
                    //    break;
            }
        }
    }
}
