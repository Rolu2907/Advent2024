using System.Collections;
using System.Numerics;
using System.Xml.XPath;

namespace Advent2024
{
    public class Day9
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
            foreach (string line in input)
            {
                //Console.WriteLine("Inicial:");
                //foreach (var item in line) Console.Write(item);
                //Console.WriteLine();

                long total = 0;
                List<string> disk = [];
                for (int i = 0, id = 0; i < line.Length; i++)
                {
                    if(int.TryParse(line[i].ToString(), out int n))
                    {
                        disk.AddRange(Enumerable.Repeat(i % 2 == 0 ? id.ToString() : ".", n).ToList()); 
                        id = i % 2 == 0 ? id + 1 : id;
                    }
                }

                //Console.WriteLine("Descomprimido:");
                //foreach (var item in disk) Console.Write(item);
                //Console.WriteLine();

                for (int i = disk.Count - 1; i >= 0; i--)
                {
                    if (disk[i] != ".")
                    {
                        int listIndex = disk.IndexOf(".");
                        if(listIndex != -1 && listIndex < i)
                        {
                            disk[listIndex] = disk[i];
                            disk[i] = ".";

                            //Console.Write("Cambio: ");
                            //foreach (var item in disk) Console.Write(item);
                            //Console.WriteLine();
                        }
                    }
                }

                //Console.WriteLine("Ordenado:");
                //foreach (var item in disk) Console.Write(item);
                //Console.WriteLine();

                for (int i = 0; i < disk.Count; i++)
                {
                    if (disk[i] != ".")total += i * Convert.ToInt32(disk[i]);
                }

                Console.WriteLine("Total: " + total);
            }
        }
        static void P2(string[] input)
        {

        }
    }
}