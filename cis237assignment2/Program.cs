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
    class Program
    {
        /// <summary>
        /// This is the main entry point for the program.
        /// You are free to add anything else you would like to this program,
        /// however the maze solving part needs to occur in the MazeSolver class.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /// <summary>
            /// Starting Coordinates.
            /// </summary>
            const int X_START = 1;
            const int Y_START = 1;

            ///<summary>
            /// The first maze that needs to be solved.
            /// Note: You may want to make a smaller version to test and debug with.
            /// You don't have to, but it might make your life easier.
            /// </summary>
            char[,] maze1 = 
            { 
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
                { '#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '#' },
                { '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '.', '#' },
                { '#', '#', '#', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
                { '#', '.', '.', '.', '.', '#', '#', '#', '.', '#', '.', '.' },
                { '#', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
                { '#', '.', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
                { '#', '#', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
                { '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#' },
                { '#', '#', '#', '#', '#', '#', '.', '#', '#', '#', '.', '#' },
                { '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#' },
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
            };

            /// <summary>
            /// Create a new instance of a mazeSolver.
            /// </summary>
            MazeSolver mazeSolver = new MazeSolver();

            //Create the second maze by transposing the first maze
            char[,] maze2 = transposeMaze(maze1);

            //Call the menu method to find out which maze to solve
            Menu(maze1, maze2, X_START, Y_START, mazeSolver);

        }
        /// <summary>
        /// This method will take in a 2 dimensional char array and return
        /// a char array maze that is flipped along the diagonal, or in mathematical
        /// terms, transposed.
        /// ie. if the array looks like 1, 2, 3
        ///                             4, 5, 6
        ///                             7, 8, 9
        /// The returned result will be:
        ///                             1, 4, 7
        ///                             2, 5, 8
        ///                             3, 6, 9
        /// The current return statement is just a placeholder so the program
        /// doesn't complain about no return value.
        /// </summary>
        /// <param name="mazeToTranspose"></param>
        /// <returns>transposedMaze</returns>
        static char[,] transposeMaze(char[,] mazeToTranspose)
        {
            char[,] maze2 = new char[mazeToTranspose.GetLength(1),mazeToTranspose.GetLength(0)];
            for (int y = 0; y < mazeToTranspose.GetLength(1); y++)
            {
                for (int x = 0; x < mazeToTranspose.GetLength(0); x++)
                {
                    maze2[y, x] = mazeToTranspose[x, y];
                }
            }
                    return maze2;
        }
        /// <summary>
        /// Method to print a menu for the user to choose 1 of the built in mazes to solve, showing the steps used.
        /// Is also called recursively to keep the program open until the user chooses to exit.
        /// </summary>
        /// <param name="maze1">The Default maze</param>
        /// <param name="maze2">The transposed maze</param>
        /// <param name="X_START">The hard coded initial x coordinate</param>
        /// <param name="Y_START">The hard coded initial y coordinate</param>
        /// <param name="mazeSolver">The instance of the MazeSolver method from the MazeSolver class</param>
        static void Menu(char[,] maze1, char[,] maze2, int X_START, int Y_START, MazeSolver mazeSolver)
        {
            Console.WriteLine("Choose which maze you would like to solve:");
            Console.WriteLine("1. Standard Maze");
            Console.WriteLine("2. Transposed Maze");
            Console.WriteLine("3. Exit");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    //Tell the instance to solve the first maze with the passed maze, and start coordinates.
                    mazeSolver.SolveMaze(maze1, X_START, Y_START);
                    break;
                case "2":
                    //Solve the transposed maze.
                    mazeSolver.SolveMaze(maze2, X_START, Y_START);
                    break;
                case "3":
                    //Call the Pause method to display an exit prompt
                    Pause();
                    break;
                default:
                    Console.WriteLine("Error, you must select from the available options");
                    Console.Clear();
                    Menu(maze1,maze2,X_START,Y_START,mazeSolver);
                    break;
            }
            Menu(maze1, maze2, X_START, Y_START, mazeSolver);
        }
        /// <summary>
        /// Method to pause the program prior to exit so the user can review the steps on screen
        /// </summary>
        static void Pause()
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
