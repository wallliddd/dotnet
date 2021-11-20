using NUnit.Framework;
using TicTacToeLib;

namespace TicTacToeLibTests
{
    /// <summary>
    /// Tests for the TicTacToeEngine
    /// 
    /// When all tests pass, we can (probably) assume TicTacToe works correctly.
    ///
    /// Note: Do NOT modify!
    /// </summary>
    public class TicTacToeEngineTest
    {
        private const string InitialBoardRepresentation =
            "-------------\n| 1 | 2 | 3 |\n-------------\n| 4 | 5 | 6 |\n-------------\n| 7 | 8 | 9 |\n-------------";

        private const string BoardRepresentationO1 =
            "-------------\n| O | 2 | 3 |\n-------------\n| 4 | 5 | 6 |\n-------------\n| 7 | 8 | 9 |\n-------------";

        private const string BoardRepresentationO2 =
            "-------------\n| 1 | O | 3 |\n-------------\n| 4 | 5 | 6 |\n-------------\n| 7 | 8 | 9 |\n-------------";

        private const string BoardRepresentationO3 =
            "-------------\n| 1 | 2 | O |\n-------------\n| 4 | 5 | 6 |\n-------------\n| 7 | 8 | 9 |\n-------------";

        private const string BoardRepresentationO4 =
            "-------------\n| 1 | 2 | 3 |\n-------------\n| O | 5 | 6 |\n-------------\n| 7 | 8 | 9 |\n-------------";

        private const string BoardRepresentationO5 =
            "-------------\n| 1 | 2 | 3 |\n-------------\n| 4 | O | 6 |\n-------------\n| 7 | 8 | 9 |\n-------------";

        private const string BoardRepresentationO6 =
            "-------------\n| 1 | 2 | 3 |\n-------------\n| 4 | 5 | O |\n-------------\n| 7 | 8 | 9 |\n-------------";

        private const string BoardRepresentationO7 =
            "-------------\n| 1 | 2 | 3 |\n-------------\n| 4 | 5 | 6 |\n-------------\n| O | 8 | 9 |\n-------------";

        private const string BoardRepresentationO8 =
            "-------------\n| 1 | 2 | 3 |\n-------------\n| 4 | 5 | 6 |\n-------------\n| 7 | O | 9 |\n-------------";

        private const string BoardRepresentationO9 =
            "-------------\n| 1 | 2 | 3 |\n-------------\n| 4 | 5 | 6 |\n-------------\n| 7 | 8 | O |\n-------------";

        private const string BoardRepresentationX1 =
            "-------------\n| X | O | 3 |\n-------------\n| 4 | 5 | 6 |\n-------------\n| 7 | 8 | 9 |\n-------------";

        private const string BoardRepresentationX2 =
            "-------------\n| O | X | 3 |\n-------------\n| 4 | 5 | 6 |\n-------------\n| 7 | 8 | 9 |\n-------------";

        private const string BoardRepresentationX3 =
            "-------------\n| O | 2 | X |\n-------------\n| 4 | 5 | 6 |\n-------------\n| 7 | 8 | 9 |\n-------------";

        private const string BoardRepresentationX4 =
            "-------------\n| O | 2 | 3 |\n-------------\n| X | 5 | 6 |\n-------------\n| 7 | 8 | 9 |\n-------------";

        private const string BoardRepresentationX5 =
            "-------------\n| O | 2 | 3 |\n-------------\n| 4 | X | 6 |\n-------------\n| 7 | 8 | 9 |\n-------------";

        private const string BoardRepresentationX6 =
            "-------------\n| O | 2 | 3 |\n-------------\n| 4 | 5 | X |\n-------------\n| 7 | 8 | 9 |\n-------------";

        private const string BoardRepresentationX7 =
            "-------------\n| O | 2 | 3 |\n-------------\n| 4 | 5 | 6 |\n-------------\n| X | 8 | 9 |\n-------------";

        private const string BoardRepresentationX8 =
            "-------------\n| O | 2 | 3 |\n-------------\n| 4 | 5 | 6 |\n-------------\n| 7 | X | 9 |\n-------------";

        private const string BoardRepresentationX9 =
            "-------------\n| O | 2 | 3 |\n-------------\n| 4 | 5 | 6 |\n-------------\n| 7 | 8 | X |\n-------------";

        private TicTacToeEngine _engine;

        [SetUp]
        public void Setup()
        {
            _engine = new TicTacToeEngine();
        }

        [Test]
        public void ShouldShowTheCorrectInitialBoardRepresentation()
        {
            Assert.AreEqual(InitialBoardRepresentation, _engine.Board());
        }

        [TestCase(new[] {1}, BoardRepresentationO1)]
        [TestCase(new[] {2}, BoardRepresentationO2)]
        [TestCase(new[] {3}, BoardRepresentationO3)]
        [TestCase(new[] {4}, BoardRepresentationO4)]
        [TestCase(new[] {5}, BoardRepresentationO5)]
        [TestCase(new[] {6}, BoardRepresentationO6)]
        [TestCase(new[] {7}, BoardRepresentationO7)]
        [TestCase(new[] {8}, BoardRepresentationO8)]
        [TestCase(new[] {9}, BoardRepresentationO9)]
        [TestCase(new[] {2, 1}, BoardRepresentationX1)]
        [TestCase(new[] {1, 2}, BoardRepresentationX2)]
        [TestCase(new[] {1, 3}, BoardRepresentationX3)]
        [TestCase(new[] {1, 4}, BoardRepresentationX4)]
        [TestCase(new[] {1, 5}, BoardRepresentationX5)]
        [TestCase(new[] {1, 6}, BoardRepresentationX6)]
        [TestCase(new[] {1, 7}, BoardRepresentationX7)]
        [TestCase(new[] {1, 8}, BoardRepresentationX8)]
        [TestCase(new[] {1, 9}, BoardRepresentationX9)]
        public void ShouldShowTheCorrectBoardRepresentationBasedOnPlayerSelection(int[] cells, string expected)
        {
            ChooseCells(cells);

            Assert.AreEqual(expected, _engine.Board());
        }

        private void ChooseCells(int[] cells)
        {
            foreach (var cell in cells)
            {
                _engine.ChooseCell(cell);
            }
        }

        // All horizontal combinations (both player O and X):
        [TestCase(new[] {1, 4, 2, 5, 3}, GameStatus.PlayerOWins)]
        [TestCase(new[] {4, 1, 5, 2, 6}, GameStatus.PlayerOWins)]
        [TestCase(new[] {7, 1, 8, 2, 9}, GameStatus.PlayerOWins)]
        [TestCase(new[] {4, 1, 5, 2, 7, 3}, GameStatus.PlayerXWins)]
        [TestCase(new[] {1, 4, 2, 5, 7, 6}, GameStatus.PlayerXWins)]
        [TestCase(new[] {1, 7, 2, 8, 4, 9}, GameStatus.PlayerXWins)]
        // All vertical combinations (both player O and X):
        [TestCase(new[] {1, 2, 4, 5, 7}, GameStatus.PlayerOWins)]
        [TestCase(new[] {2, 1, 5, 4, 8}, GameStatus.PlayerOWins)]
        [TestCase(new[] {3, 1, 6, 4, 9}, GameStatus.PlayerOWins)]
        [TestCase(new[] {2, 1, 3, 4, 5, 7}, GameStatus.PlayerXWins)]
        [TestCase(new[] {1, 2, 3, 5, 6, 8}, GameStatus.PlayerXWins)]
        [TestCase(new[] {2, 3, 5, 6, 1, 9}, GameStatus.PlayerXWins)]
        // All diagonal combinations (both player O and X):
        [TestCase(new[] {1, 2, 5, 4, 9}, GameStatus.PlayerOWins)]
        [TestCase(new[] {3, 2, 5, 4, 7}, GameStatus.PlayerOWins)]
        [TestCase(new[] {2, 1, 3, 5, 6, 9}, GameStatus.PlayerXWins)]
        [TestCase(new[] {1, 3, 2, 5, 4, 7}, GameStatus.PlayerXWins)]
        // Equal test cases
        [TestCase(new[] {1, 2, 3, 5, 4, 6, 8, 7, 9}, GameStatus.Equal)]
        [TestCase(new[] {1, 3, 2, 4, 6, 5, 7, 9, 8}, GameStatus.Equal)]
        // Turn test cases
        [TestCase(new int[0], GameStatus.PlayerOPlays)]
        [TestCase(new[] {1}, GameStatus.PlayerXPlays)]
        [TestCase(new[] {1, 2}, GameStatus.PlayerOPlays)]
        public void ShouldHaveTheCorrectGameStatusAfterPlaying(int[] cells, GameStatus expected)
        {
            ChooseCells(cells);

            Assert.AreEqual(expected, _engine.Status);
        }

        [Test]
        public void ShouldResetBoardCorrectly()
        {
            for (var i = 0; i < 8; i++)
            {
                // Doing this will eventually let playerO win:
                // -------------
                // | O | X | O |
                // -------------
                // | X | O | X |
                // -------------
                // | O | 8 | 9 |
                // -------------
                _engine.ChooseCell(i);
            }

            _engine.ChooseCell(1);
            _engine.Reset();

            // We want to test both the GameStatus and the representation of the board after resetting
            Assert.AreEqual(GameStatus.PlayerOPlays, _engine.Status);
            Assert.AreEqual(InitialBoardRepresentation, _engine.Board());
        }

        [Test]
        public void ShouldReturnFalseWhenChoosingACellThatIsAlreadyOccupied()
        {
            // Player O's turn
            _engine.ChooseCell(1);
            // Player X's turn, but chooses an occupied cell
            Assert.False(_engine.ChooseCell(1));
        }

        [Test]
        public void ShouldRetainTurnWhenChoosingAWrongCell()
        {
            ChooseCells(new[] {1, 1});

            // Retain the turn after choosing occupied cell
            Assert.AreEqual(GameStatus.PlayerXPlays, _engine.Status);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(10)]
        public void ShouldReturnFalseWhenChoosingAnInvalidCell(int value)
        {
            Assert.False(_engine.ChooseCell(value));
        }
    }
}