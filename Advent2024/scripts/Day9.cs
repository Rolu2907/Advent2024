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
            foreach (string line in input)
            {
                //Console.WriteLine("Inicial:");
                //foreach (var item in line) Console.Write(item);
                //Console.WriteLine();

                long total = 0;
                List<string> disk = [];
                for (int i = 0, id = 0; i < line.Length; i++)
                {
                    if (int.TryParse(line[i].ToString(), out int n))
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
                        int[] fileIndex = [disk.IndexOf(disk[i]),i];
                        int fileSize = fileIndex[1] - fileIndex[0] + 1;
                        int[] freeSpaceIndex = new int[2];
                        bool canMove = false;

                        for (int j = 0; j + fileSize < disk.Count && !canMove; j++)
                        {
                            //Console.WriteLine("Comprobando de: " + j + " a " + (j + fileSize));
                            //foreach (var item in disk.GetRange(j, fileSize)) Console.Write(item);
                            //Console.WriteLine("? " + (disk.GetRange(j, fileSize).All(item => item == ".")));
                            if (disk.GetRange(j, fileSize).All(item => item == "."))
                            {
                                freeSpaceIndex = [j,j + fileSize];
                                canMove = true;
                            }
                        }
                        if(canMove && freeSpaceIndex[0] < fileIndex[0])
                        {
                            //Console.WriteLine($"Para: {disk[fileIndex[0]]} de tamaño {fileSize} encontrado hueco de {freeSpaceIndex[0]} a {freeSpaceIndex[1]}");
                            for (int j = 0; j < fileSize; j++)
                            {
                                disk[freeSpaceIndex[0] + j] = disk[fileIndex[0] + j];
                                disk[fileIndex[0] + j] = ".";
                            }

                            //Console.Write("Cambio: ");
                            //foreach (var item in disk) Console.Write(item);
                            //Console.WriteLine();
                        }
                        i = fileIndex[0];
                    }
                }

                //Console.WriteLine("Ordenado:");
                //foreach (var item in disk) Console.Write(item);
                //Console.WriteLine();

                for (int i = 0; i < disk.Count; i++)
                {
                    if (int.TryParse(disk[i], out int n)) total += i * n;
                }

                Console.WriteLine("Total: " + total);
            }
        }
    }
}