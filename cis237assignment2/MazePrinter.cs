using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class MazePrinter
    {
        public static void PrintMaze(char[,] maze)
        {
            Console.Clear();
            for(int y = 0; y < maze.GetLength(1); y++)
            {
                for(int x = 0; x < maze.GetLength(0); x++)
                {
                    Console.Write(maze[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}
