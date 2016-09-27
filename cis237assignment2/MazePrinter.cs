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
            //Console.Clear();
            for(int x = 0; x < maze.GetLength(0); x++)
            {
                for(int y = 0; y < maze.GetLength(1); y++)
                {
                    switch (maze[x, y])
                    {
                        case ('X'):
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case ('O'):
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    };
                    Console.Write(maze[x,y]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
