using System;
using System.Windows.Forms;

namespace TicTacToeGui
{
    public partial class Form1 : Form
    {

        private int beurt = 0;
        private string plaatje = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (beurt % 2 == 1)
            {
                plaatje = "X";
            }
            else
            {
                plaatje = "O";
            }
            beurt++;
            button.Text = plaatje;

            if(!(bepaalWinnaar(button1, button5, button9) ||
            bepaalWinnaar(button1, button4, button7) ||
            bepaalWinnaar(button1, button2, button3) ||
            bepaalWinnaar(button2, button5, button8) ||
            bepaalWinnaar(button3, button6, button9) ||
            bepaalWinnaar(button4, button5, button6) ||
            bepaalWinnaar(button7, button8, button9) ||
            bepaalWinnaar(button3, button5, button7)) && beurt == 9) {
                System.Windows.Forms.MessageBox.Show("Er is geen Winnaar! ", "Jammer! Niemand wint! ");
                maakLeeg();
            }

                
                
        }
        public bool bepaalWinnaar(Button a, Button b, Button c)
        {
            if(a.Text == b.Text &&  a.Text == c.Text && a.Text != "")
            {
                System.Windows.Forms.MessageBox.Show("De winnaar is " + plaatje, "Er is een Winnaar! ");
                maakLeeg();
                return true;
              
            }
            return false; 
        }

        public void maakLeeg()
        {
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            beurt = 0;
        }

    }
}
