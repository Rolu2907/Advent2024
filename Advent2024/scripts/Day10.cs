using System.Collections;
using System.Numerics;
using System.Xml.XPath;

namespace Advent2024
{
    public class Day10
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
            int[,] matrix = new int[input.Length, input[0].Length];

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    matrix[i,j] = int.Parse(input[i][j].ToString());
                }
            }

            List<int[]> hikingTrails = new List<int[]>();
            string[,] matrixVisual = new string[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrixVisual[i, j] = ".";
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    //Console.WriteLine("Explorando: " + i + ", " + j);
                    if (matrix[i, j] == 0) Explore(matrix, [i,j], [i,j], ref hikingTrails, matrixVisual);
                }
            }

            //foreach (var item in hikingTrails)
            //{
            //    Console.WriteLine($"{item[0]}, {item[1]} a {item[2]}, {item[3]}");
            //}
            Console.WriteLine("Total: " + hikingTrails.Count);
        }
        static void Explore(int[,] matrix, int[] trailhead, int[] pos, ref List<int[]> hikingTrails, string[,] matrixVisual)
        {
            bool acabado = true;

            string[,] newMatrixVisual = new string[matrixVisual.GetLength(0), matrixVisual.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newMatrixVisual[i,j] = matrixVisual[i,j];
                }
            }

            newMatrixVisual[pos[0], pos[1]] = matrix[pos[0], pos[1]].ToString();

            if (pos[0] + 1 < matrix.GetLength(0)
                && matrix[pos[0] + 1, pos[1]] - matrix[pos[0], pos[1]] == 1)
            {
                acabado = false;
                if(matrix[pos[0], pos[1]] == 8)
                {
                    int[] newTrail = [trailhead[0], trailhead[1], pos[0] + 1, pos[1]];
                    if(!hikingTrails.Any(item => item[0] == newTrail[0] && item[1] == newTrail[1] && item[2] == newTrail[2] && item[3] == newTrail[3]))
                    {
                        hikingTrails.Add(newTrail);
                        newMatrixVisual[newTrail[2], newTrail[3]] = matrix[newTrail[2], newTrail[3]].ToString();
                        PrintMatrix(newMatrixVisual);
                    }
                }
                else Explore(matrix, trailhead, [pos[0] + 1, pos[1]], ref hikingTrails, newMatrixVisual);
            }
            if (pos[0] - 1 >= 0
                && matrix[pos[0] - 1, pos[1]] - matrix[pos[0], pos[1]] == 1)
            {
                acabado = false;
                if(matrix[pos[0], pos[1]] == 8)
                {
                    int[] newTrail = [trailhead[0], trailhead[1], pos[0] - 1, pos[1]];
                    if(!hikingTrails.Any(item => item[0] == newTrail[0] && item[1] == newTrail[1] && item[2] == newTrail[2] && item[3] == newTrail[3]))
                    {
                        hikingTrails.Add(newTrail);
                        newMatrixVisual[newTrail[2], newTrail[3]] = matrix[newTrail[2], newTrail[3]].ToString();
                        PrintMatrix(newMatrixVisual);
                    }
                }
                else Explore(matrix, trailhead, [pos[0] - 1, pos[1]], ref hikingTrails, newMatrixVisual);
            }

            //if(matrix[pos[0], pos[1]] == 0) Console.WriteLine($"Derecha? {pos[1] + 1 < matrix.GetLength(1)} && {matrix[pos[0], pos[1] + 1] - matrix[pos[0], pos[1]] == 1}");
            //if (pos[1] + 1 < matrix.GetLength(1) && matrix[pos[0], pos[1]] == 0) Console.WriteLine($"Derecha {matrix[pos[0], pos[1]]} en {pos[0]}, {pos[1]} a {matrix[pos[0], pos[1] + 1]} en {pos[0]}, {pos[1] + 1}");

            if (pos[1] + 1 < matrix.GetLength(1)
                && matrix[pos[0], pos[1] + 1] - matrix[pos[0], pos[1]] == 1)
            {
                acabado = false;
                if(matrix[pos[0], pos[1]] == 8)
                {
                    int[] newTrail = [trailhead[0], trailhead[1], pos[0], pos[1] + 1];
                    if(!hikingTrails.Any(item => item[0] == newTrail[0] && item[1] == newTrail[1] && item[2] == newTrail[2] && item[3] == newTrail[3]))
                    {
                        hikingTrails.Add(newTrail);
                        newMatrixVisual[newTrail[2], newTrail[3]] = matrix[newTrail[2], newTrail[3]].ToString();
                        PrintMatrix(newMatrixVisual);
                    }
                }
                else Explore(matrix, trailhead, [pos[0], pos[1] + 1], ref hikingTrails, newMatrixVisual);
            }
            if (pos[1] - 1 >= 0
                && matrix[pos[0], pos[1] - 1] - matrix[pos[0], pos[1]] == 1)
            {
                acabado = false;
                if(matrix[pos[0], pos[1]] == 8)
                {
                    int[] newTrail = [trailhead[0], trailhead[1], pos[0], pos[1] - 1];
                    if (!hikingTrails.Any(item => item[0] == newTrail[0] && item[1] == newTrail[1] && item[2] == newTrail[2] && item[3] == newTrail[3]))
                    {
                        hikingTrails.Add(newTrail);
                        newMatrixVisual[newTrail[2], newTrail[3]] = matrix[newTrail[2], newTrail[3]].ToString();
                        PrintMatrix(newMatrixVisual);
                    }
                }
                else Explore(matrix, trailhead, [pos[0], pos[1] - 1], ref hikingTrails, newMatrixVisual);
            }
            //if(acabado) PrintMatrix(matrixVisual);
        }
        static void PrintMatrix(string[,] matrix)
        {
            return;
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
        static void P2(string[] input)
        {
            int[,] matrix = new int[input.Length, input[0].Length];

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[0].Length; j++)
                {
                    matrix[i, j] = int.Parse(input[i][j].ToString());
                }
            }

            List<int[]> hikingTrails = new List<int[]>();
            string[,] matrixVisual = new string[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrixVisual[i, j] = ".";
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    //Console.WriteLine("Explorando: " + i + ", " + j);
                    if (matrix[i, j] == 0) Explore2(matrix, [i, j], [i, j], ref hikingTrails, matrixVisual);
                }
            }

            //foreach (var item in hikingTrails)
            //{
            //    Console.WriteLine($"{item[0]}, {item[1]} a {item[2]}, {item[3]}");
            //}
            Console.WriteLine("Total: " + hikingTrails.Count);
        }
        static void Explore2(int[,] matrix, int[] trailhead, int[] pos, ref List<int[]> hikingTrails, string[,] matrixVisual)
        {
            bool acabado = true;

            string[,] newMatrixVisual = new string[matrixVisual.GetLength(0), matrixVisual.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newMatrixVisual[i, j] = matrixVisual[i, j];
                }
            }

            newMatrixVisual[pos[0], pos[1]] = matrix[pos[0], pos[1]].ToString();

            if (pos[0] + 1 < matrix.GetLength(0)
                && matrix[pos[0] + 1, pos[1]] - matrix[pos[0], pos[1]] == 1)
            {
                acabado = false;
                if (matrix[pos[0], pos[1]] == 8)
                {
                    int[] newTrail = [trailhead[0], trailhead[1], pos[0] + 1, pos[1]];
                    hikingTrails.Add(newTrail);
                    newMatrixVisual[newTrail[2], newTrail[3]] = matrix[newTrail[2], newTrail[3]].ToString();
                    PrintMatrix(newMatrixVisual);
                }
                else Explore2(matrix, trailhead, [pos[0] + 1, pos[1]], ref hikingTrails, newMatrixVisual);
            }
            if (pos[0] - 1 >= 0
                && matrix[pos[0] - 1, pos[1]] - matrix[pos[0], pos[1]] == 1)
            {
                acabado = false;
                if (matrix[pos[0], pos[1]] == 8)
                {
                    int[] newTrail = [trailhead[0], trailhead[1], pos[0] - 1, pos[1]];
                    hikingTrails.Add(newTrail);
                    newMatrixVisual[newTrail[2], newTrail[3]] = matrix[newTrail[2], newTrail[3]].ToString();
                    PrintMatrix(newMatrixVisual);
                }
                else Explore2(matrix, trailhead, [pos[0] - 1, pos[1]], ref hikingTrails, newMatrixVisual);
            }

            //if(matrix[pos[0], pos[1]] == 0) Console.WriteLine($"Derecha? {pos[1] + 1 < matrix.GetLength(1)} && {matrix[pos[0], pos[1] + 1] - matrix[pos[0], pos[1]] == 1}");
            //if (pos[1] + 1 < matrix.GetLength(1) && matrix[pos[0], pos[1]] == 0) Console.WriteLine($"Derecha {matrix[pos[0], pos[1]]} en {pos[0]}, {pos[1]} a {matrix[pos[0], pos[1] + 1]} en {pos[0]}, {pos[1] + 1}");

            if (pos[1] + 1 < matrix.GetLength(1)
                && matrix[pos[0], pos[1] + 1] - matrix[pos[0], pos[1]] == 1)
            {
                acabado = false;
                if (matrix[pos[0], pos[1]] == 8)
                {
                    int[] newTrail = [trailhead[0], trailhead[1], pos[0], pos[1] + 1];
                    hikingTrails.Add(newTrail);
                    newMatrixVisual[newTrail[2], newTrail[3]] = matrix[newTrail[2], newTrail[3]].ToString();
                    PrintMatrix(newMatrixVisual);
                }
                else Explore2(matrix, trailhead, [pos[0], pos[1] + 1], ref hikingTrails, newMatrixVisual);
            }
            if (pos[1] - 1 >= 0
                && matrix[pos[0], pos[1] - 1] - matrix[pos[0], pos[1]] == 1)
            {
                acabado = false;
                if (matrix[pos[0], pos[1]] == 8)
                {
                    int[] newTrail = [trailhead[0], trailhead[1], pos[0], pos[1] - 1];
                    hikingTrails.Add(newTrail);
                    newMatrixVisual[newTrail[2], newTrail[3]] = matrix[newTrail[2], newTrail[3]].ToString();
                    PrintMatrix(newMatrixVisual);
                }
                else Explore2(matrix, trailhead, [pos[0], pos[1] - 1], ref hikingTrails, newMatrixVisual);
            }
            //if(acabado) PrintMatrix(matrixVisual);
        }
    }
}