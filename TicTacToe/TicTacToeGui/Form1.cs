using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeLib;


namespace TicTacToe_Gui
{
    public partial class Form1 : Form
    {
        
        public TicTacToeEngine engine;
        public Form1(TicTacToeEngine engine)
        {
            this.engine = engine;
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            try
            {
                int cellNumber = Convert.ToInt32(btn.Name.Substring(btn.Name.Length - 1));
                int buttonText = cellNumber - 1;
                engine.ChooseCell(cellNumber);
                btn.Text = engine.cellNumbers1[buttonText];
                SetResult(engine.Status);
            }
            catch (FormatException)
            {
                Console.WriteLine("Input string is invalid.");
            }
        }

        private void ResetButtons()
        {
            engine.Reset();
            Button[] array = { button1, button2, button3 , button4, button5, button6, button7, button8, button9 };
            foreach (Button button in array)
            {
                button.Text = "";
            }
            this.label2.Text = "Player O begin!";
        }

        /* This method sets the text of the results to the label
         */
        private void SetResult(GameStatus status)
        {
            if (status == GameStatus.PlayerOPlays)
            {
               this.label2.Text = "Player O, it's your turn!";
            }
            else
            {
                this.label2.Text = "Player X, it's your turn!";
            }

            if (status == GameStatus.PlayerOWins)
            {
                this.label2.Text = "Congratulations, player O won!";
                System.Windows.Forms.MessageBox.Show("Congratulations, player O won!");
                ResetButtons();
            }
            else if (status == GameStatus.PlayerXWins)
            {
                this.label2.Text = "Congratulations, player X won!";
                System.Windows.Forms.MessageBox.Show("Congratulations, player X won!");
                ResetButtons();
            }
            else if (status == GameStatus.Equal)
            {
                this.label2.Text = "Tie!";
                System.Windows.Forms.MessageBox.Show("Tie!");
                ResetButtons();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}