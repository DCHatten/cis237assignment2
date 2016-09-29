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
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Class level memeber variable for the mazesolver class
        /// </summary>
        char[,] maze;
        int xStart;
        int yStart;
        bool foundExit = false;
        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        {}
        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class. 
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;
            this.foundExit = false;

            //Calling the recursive maze traversal method
            this.mazeTraversal(xStart, yStart);
        }
        /// <summary>
        /// This method takes in start positions for the maze, then makes a recursive call
        /// to step through the possible moves in the maze, backtracks as necessary, and
        /// check for an exit
        /// </summary>
        private void mazeTraversal(int xStart, int yStart)
        {
            if (!foundExit)
            {
                if (maze[xStart, yStart] == '.')
                {
                    maze[xStart, yStart] = 'X';
                    MazePrinter.PrintMaze(maze);

                    if (xStart == maze.GetLength(1) - 1 || yStart == maze.GetLength(0) - 1 || xStart == 0 || yStart == 0)
                    {
                        foundExit = true;
                    }
                    else
                    {
                        mazeTraversal(xStart + 1, yStart);
                        mazeTraversal(xStart, yStart + 1);
                        mazeTraversal(xStart - 1, yStart);
                        mazeTraversal(xStart, yStart - 1);
                    }
                    if (!foundExit)
                    {
                        maze[xStart, yStart] = 'O';
                        MazePrinter.PrintMaze(maze);
                    }
                }
            }
        }
    }
}
