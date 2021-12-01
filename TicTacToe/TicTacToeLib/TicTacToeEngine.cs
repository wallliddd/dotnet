using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TicTacToeLib
{
    public class TicTacToeEngine
    {

        public TicTacToeEngine()
        {
            this.Status = GameStatus.PlayerOPlays;
        }

        public GameStatus Status { get; private set; }


        public string[] cellNumbers1 = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };


        public string Board()
        {
            Console.WriteLine("Type a number from 1 to 9.");
            Console.WriteLine("Status: " + Status);
            string board = string.Format("-------------\n" +
                                         "| {0} | {1} | {2} |\n" +
                                         "-------------\n" +
                                         "| {3} | {4} | {5} |\n" +
                                         "-------------\n" +
                                         "| {6} | {7} | {8} |\n" +
                                         "-------------",
                                         cellNumbers1[0], cellNumbers1[1], cellNumbers1[2],
                                         cellNumbers1[3], cellNumbers1[4], cellNumbers1[5],
                                         cellNumbers1[6], cellNumbers1[7], cellNumbers1[8]);

            return board;
        }



        public bool ChooseCell(int cellNumber)
        {
         
            int indexer = cellNumber - 1;

            try
            {
               
                if (Equals(cellNumbers1[indexer], "O") || Equals(cellNumbers1[indexer], "X"))
                {
                    Console.WriteLine("Invalid choice.");
                    return false;
                }

                // Update the cell and status
                switch (Status)
                {
                    case GameStatus.PlayerOPlays:
                        cellNumbers1[indexer] = "O";
                        Status = GameStatus.PlayerXPlays;
                        break;
                    case GameStatus.PlayerXPlays:
                        cellNumbers1[indexer] = "X";
                        Status = GameStatus.PlayerOPlays;
                        break;
                }

                bool DecideWinner(string cell1, string cell2, string cell3)
                {
                    if (Equals(cell1, cell2) && Equals(cell1, cell3) && !Equals(cell1, ""))
                    {
                        switch (cell1)
                        {
                            case "O":
                                Status = GameStatus.PlayerOWins;
                                break;
                            case "X":
                                Status = GameStatus.PlayerXWins;
                                break;
                        }
                    }

                    return false;
                }

                string[] cellNumbers2 = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

                if (!(DecideWinner(cellNumbers1[0], cellNumbers1[1], cellNumbers1[2]) ||
                      DecideWinner(cellNumbers1[3], cellNumbers1[4], cellNumbers1[5]) ||
                      DecideWinner(cellNumbers1[6], cellNumbers1[7], cellNumbers1[8]) ||

                      DecideWinner(cellNumbers1[0], cellNumbers1[4], cellNumbers1[8]) ||
                      DecideWinner(cellNumbers1[2], cellNumbers1[4], cellNumbers1[6]) ||

                      DecideWinner(cellNumbers1[0], cellNumbers1[3], cellNumbers1[6]) ||
                      DecideWinner(cellNumbers1[1], cellNumbers1[4], cellNumbers1[7]) ||
                      DecideWinner(cellNumbers1[2], cellNumbers1[5], cellNumbers1[8])) &&
                      !cellNumbers2.Any(cellNumbers1.Contains))
                {
                    Status = GameStatus.Equal;
                }
            }
            catch (IndexOutOfRangeException )
            {
                Console.WriteLine("Invalid choice.");
                return false;
            }

            return true;
        }


        public void CheckInputConsole()
        {
            string nextSet = Console.ReadLine();

           
            switch (nextSet)
            {

                case "new":
                    Reset();
                    break;
                case "quit":
                    Environment.Exit(0);
                    break;
                default:
                    try
                    {
                        Int32.TryParse(nextSet, out int cell);
                        ChooseCell(cell);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
            }
        }



        public void UpdateStatusConsole()
        {
            // Update the status with a switch case
            switch (Status)
            {
                case (GameStatus.PlayerOWins):
                    Console.WriteLine("Congratulations, player O won!");
                    Console.WriteLine(Board());
                    Console.WriteLine(".............................. NEW GAME ..............................");
                    Reset();
                    break;
                case (GameStatus.PlayerXWins):
                    Console.WriteLine("Congratulations, player X won!");
                    Console.WriteLine(Board());
                    Console.WriteLine(".............................. NEW GAME ..............................");
                    Reset();
                    break;
                case (GameStatus.Equal):
                    Console.WriteLine("Tie!");
                    Console.WriteLine(Board());
                    Console.WriteLine(".............................. NEW GAME ..............................");
                    Reset();
                    break;
            }
        }


       
        public void Reset()
        {
            string[] reset = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            cellNumbers1 = reset;
            Status = GameStatus.PlayerOPlays;
        }


        
    }
}