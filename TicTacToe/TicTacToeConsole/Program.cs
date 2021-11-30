using System;
using TicTacToeLib;

namespace TicTacToeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeEngine t = new TicTacToeEngine();

            Console.WriteLine("Hello player O and player X.");

            /* While the Console application keeps running, call the methods
             * and play the game
             */
            while (true)
            {
                Console.WriteLine(t.Board());
                t.CheckInputConsole();
                t.UpdateStatusConsole();
            }
        }
    }
}