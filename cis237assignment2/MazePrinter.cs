using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// David Hatten
/// </summary>
namespace cis237assignment2
{
    /// <summary>
    /// The class which contains the method for printing the maze solution, one step at a time
    /// </summary>
    class MazePrinter
    {
        /// <summary>
        /// A Method for printing the various steps taken to solve the maze
        /// </summary>
        /// <param name="maze"></param>
        public static void PrintMaze(char[,] maze)
        {
            //Console.Clear();
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    //Switch method for changing the on screen color to increase readability
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
                    Console.Write(maze[x, y] + " ");
                }
                Console.WriteLine();
            }
            //Task to delay the printing of the next step, *borrowed* from the Visual Tower of Hanoi solution
            Task.Delay(500).Wait();
            Console.WriteLine();
        }
    }
}
