namespace Advent2024
{
    public class Day6
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
            char[,] matrix = new char[input.Length,input[0].Length];
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    matrix[i,j] = input[i][j];
                }
            }
            while(Forward(ref matrix)) {
                //Thread.Sleep(200);
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }

            int total = 0;
            foreach (var pos in matrix)
            {
                if(pos == 'X') total++;
            }
            Console.WriteLine("Total positions: " + total);
        }
        static void P2(string[] input)
        {      
            int totalLoops = 0;      
            char[,] matrix = new char[input.Length,input[0].Length];
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    matrix[i,j] = input[i][j];
                }
            }
            while(Forward2(ref matrix, out int loops)) {
                totalLoops += loops;
                if(loops > 0) Console.WriteLine("+" + loops + " loops");
                //Thread.Sleep(200);
            }

            int total = 0;
            foreach (var pos in matrix)
            {
                if(pos == 'X') total++;
            }
            Console.WriteLine("Total positions: " + total);
            Console.WriteLine("Total loops: " + totalLoops);
        }
        static bool Forward(ref char[,] input) {

            //PrintMatrix(input);
            int[] loc = FindGuard(input);

            switch(input[loc[0],loc[1]])
            {
                case '^':
                    for (int i = loc[0]; i >= 0; i--)
                    {
                        if(input[i,loc[1]] == '#') {
                            input[i + 1,loc[1]] = '>';
                            return true;
                        }
                        input[i,loc[1]] = 'X';
                    }
                break;
                case '>':
                    for (int i = loc[1]; i < input.GetLength(1); i++)
                    {
                        if(input[loc[0],i] == '#') {
                            input[loc[0],i - 1] = 'v';
                            return true;
                        }
                        input[loc[0],i] = 'X';
                    }
                break;
                case '<':
                    for (int i = loc[1]; i >= 0; i--)
                    {
                        if(input[loc[0],i] == '#') {
                            input[loc[0],i + 1] = '^';
                            return true;
                        }
                        input[loc[0],i] = 'X';
                    }
                break;
                case 'v':
                    for (int i = loc[0]; i < input.GetLength(0); i++)
                    {
                        if(input[i,loc[1]] == '#') {
                            input[i - 1,loc[1]] = '<';
                            return true;
                        }
                        input[i,loc[1]] = 'X';
                    }
                break;
            }
            return false;
        }
        static bool Forward2(ref char[,] input, out int loops) {

            int[] loc = FindGuard(input);
            loops = 0;

            switch(input[loc[0],loc[1]])
            {
                case '^':
                    for (int i = loc[0]; i >= 0; i--)
                    {
                        if(input[i,loc[1]] == '#') {
                            input[i + 1,loc[1]] = '>';
                            return true;
                        }
                        if(CheckLoop(input, '>', [i,loc[1]])) loops++;
                        input[i,loc[1]] = 'X';
                    }
                break;
                case '>':
                    for (int i = loc[1]; i < input.GetLength(1); i++)
                    {
                        if(input[loc[0],i] == '#') {
                            input[loc[0],i - 1] = 'v';
                            return true;
                        }
                        if(CheckLoop(input, 'v', [loc[0],i])) loops++;
                        input[loc[0],i] = 'X';
                    }
                break;
                case '<':
                    for (int i = loc[1]; i >= 0; i--)
                    {
                        if(input[loc[0],i] == '#') {
                            input[loc[0],i + 1] = '^';
                            return true;
                        }
                        if(CheckLoop(input, '^', [loc[0],i])) loops++;
                        input[loc[0],i] = 'X';
                    }
                break;
                case 'v':
                    for (int i = loc[0]; i < input.GetLength(0); i++)
                    {
                        if(input[i,loc[1]] == '#') {
                            input[i - 1,loc[1]] = '<';
                            return true;
                        }
                        if(CheckLoop(input, '<', [i,loc[1]])) loops++;
                        input[i,loc[1]] = 'X';
                    }
                break;
            }
            return false;
        }
        static bool CheckLoop(char[,] input, char direction, int[] loc) {
            char[,] tempInput = new char[input.GetLength(0),input.GetLength(1)];

            for(int i = 0; i < input.GetLength(0); i++)
            {
                for(int j = 0; j < input.GetLength(0); j++)
                {
                    tempInput[i,j] = input[i,j];
                }   
            }
            
            //char[,] tempInput = input;

            int[] loc2 = FindGuard(tempInput);
            if(loc2 != null) tempInput[loc2[0],loc2[1]] = '.';
            tempInput[loc[0],loc[1]] = direction;
            switch(direction)
            {
                case '^':
                if(loc[1] - 1 >= 0) tempInput[loc[0],loc[1] - 1] = '#';                
                break;
                case '>':
                if(loc[0] - 1 >= 0) tempInput[loc[0] - 1,loc[1]] = '#';                
                break;
                case '<':
                if(loc[0] + 1 < tempInput.GetLength(0)) tempInput[loc[0] + 1,loc[1]] = '#';                
                break;
                case 'v':
                if(loc[1] + 1 < tempInput.GetLength(1)) tempInput[loc[0],loc[1] + 1] = '#';                
                break;
            }
            
            int index = 1;
            while(Forward(ref tempInput) && index < 500)
            {
                Console.WriteLine("CheckLoop Step" + index);
                int[] finalLoc = FindGuard(tempInput);
                if(loc[0] == finalLoc[0] && loc[1] == finalLoc[1]) return true;
                index++;
            }
            return false;
            // for(int i = 0; i < 4; i++)
            // {
            // }
            // int[] finalLoc = FindGuard(tempInput);

            // Console.WriteLine("Step4, comparando final: ");
            // Console.WriteLine($"Posicion inicial: {finalLoc[0]},{finalLoc[1]}");
            // Console.WriteLine($"Posicion final: {loc[0]},{loc[1]}");
            // Console.WriteLine("Resultado: " + (loc[0] == finalLoc[0] && loc[1] == finalLoc[1]));
            // return loc[0] == finalLoc[0] && loc[1] == finalLoc[1];
        }
        static int[] FindGuard(char[,] input) {
            char[] possibles = ['^','>','<','v'];
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    if(possibles.Contains(input[i,j])) {
                        return [i,j];
                    }
                }
            }
            return null;
        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}