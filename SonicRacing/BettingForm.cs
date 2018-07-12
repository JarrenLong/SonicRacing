using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SonicRacing
{
    /// <summary>
    /// Plain and simple: Ask users for values, parse them, make sure they're
    /// all multiples of 10, and close this dialog with a DialogResult.OK
    /// return value. If the user clicks Cancel, return Cancel and do nothing.
    /// </summary>
    public partial class BettingForm : Form
    {
        private int[] m_bet;

        public BettingForm()
        {
            InitializeComponent();
            m_bet = new int[3]{0,0,0};
        }

        public void ConfigForm(GameForm owner) {
            RaceObject buf = owner.GetPlayer(0);
            m_player1NameLabel.Text = buf.Name;
            m_player1OddsLabel.Text = buf.Odds.ToString("p");
            m_player1WagerTextBox.Text = buf.Bet.ToString();

            buf = owner.GetPlayer(1);
            m_player2NameLabel.Text = buf.Name;
            m_player2OddsLabel.Text = buf.Odds.ToString("p");
            m_player2WagerTextBox.Text = buf.Bet.ToString();

            buf = owner.GetPlayer(2);
            m_player3NameLabel.Text = buf.Name;
            m_player3OddsLabel.Text = buf.Odds.ToString("p");
            m_player3WagerTextBox.Text = buf.Bet.ToString();
        }

        public int[] Bet
        {
            get { return m_bet; }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            bool canClose = true;
            TextBox[] tmp = { m_player1WagerTextBox, m_player2WagerTextBox, m_player3WagerTextBox };

            //Parse all textbox values and check to make sure values are all multiples of 10
            for (int i=0; i < tmp.Length; i++)
            {
                try
                {
                    m_bet[i] = int.Parse(tmp[i].Text);
                    if (m_bet[i] % 10 != 0)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    MessageBox.Show("Player " + (i+1) + "'s bet must be a multiple of 10");
                    canClose = false;
                }
            }

            //If all fields are valid, close up shop
            if (canClose)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            //Just close, don't worry about grabbing values
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
