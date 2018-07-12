using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace SonicRacing
{
    public partial class GameForm : Form
    {
        //We'll use this to track wins/losses, and player finish order for each race
        private SoundPlayer m_soundPlayer = null; //Our sound effect player
        private int m_players = -1; //0-Autorun, 1-2 = X players, 3 = main menu (handled by MenuForm), 4 = exit
        private int m_finishCount = 0; //Used to track PlayerFinish callback count
        private bool m_isRunning = false; //Is game running?
        private MenuForm m_menu = null;
        private RaceObject m_p1, m_p2, m_p3;

        public GameForm()
        {
            InitializeComponent();

            //Configure the players
            m_p1 = new RaceObject();
            m_p1.Money = 100;
            m_p1.Bet = 10;
            m_p1.Name = "Sonic";
            m_p1.SetSpriteMap(Properties.Resources.sonic_map,
                new int[] { 3, 4, 4, 14 },
                new bool[] { false, true, false, false });

            m_p2 = new RaceObject();
            m_p2.Money = 100;
            m_p2.Bet = 10;
            m_p2.Name = "Tails";
            m_p2.SetSpriteMap(Properties.Resources.tails_map,
                new int[] { 11, 11, 5, 7 },
                new bool[] { false, true, false, false });

            m_p3 = new RaceObject();
            m_p3.Money = 100;
            m_p3.Bet = 10;
            m_p3.Name = "Knuckles";
            m_p3.SetSpriteMap(Properties.Resources.knuckles_map,
                new int[] { 5, 7, 4, 14 },
                new bool[] { false, true, false, false });

            //Prep our fancy main menu form
            m_menu = new MenuForm();
            //When we close, init the main game form
            m_menu.FormClosed += new FormClosedEventHandler(StartGame);
            //And show it
            m_menu.Show();
        }

        private void StartGame(object sender, FormClosedEventArgs e)
        {
            //Get our menu selection
            m_players = m_menu.GameMode;
            if (m_players == 4)
            {
                //Close up shop
                this.Close();
            }
            else
            {
                //Hide the menu
                m_menu.Hide();

                //Make the game window visible
                this.Show();
                this.BackgroundImage = Properties.Resources.track;
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;

                //Player 1
                if (m_players >= 1)
                {
                    if (m_p1RaceControl.PlayerData == null)
                    {
                        m_p1.MoveKey = Keys.A;
                    }
                    else
                    {
                        m_p1RaceControl.PlayerData.MoveKey = Keys.A;
                    }
                    m_p1RaceControl.Autorun = false;
                }
                else
                {
                    m_p1RaceControl.Autorun = true;
                }
                m_p1RaceControl.OnFinish = PlayerFinish;

                //Player 2
                if (m_players >= 2)
                {
                    if (m_p1RaceControl.PlayerData == null)
                    {
                        m_p2.MoveKey = Keys.L;
                    }
                    else
                    {
                        m_p2RaceControl.PlayerData.MoveKey = Keys.L;
                    }
                    m_p2RaceControl.Autorun = false;
                }
                else
                {
                    m_p2RaceControl.Autorun = true;
                }
                m_p2RaceControl.OnFinish = PlayerFinish;

                //Player 3 (always on AutoPilot)
                m_p3RaceControl.OnFinish = PlayerFinish;

                //Pass copies of our player objects to the controls. This is
                //the last time we'll touch m_p1-3 (the RaceControls will
                //handle all data manipulation), so we can dispose of them
                //We have to check for nulls in the m_pX objects, because
                //if we call the menu after the GameForm loads, they will be
                //invalid, so we can't pass them back to the controls without
                //screwing things up.
                if (m_p1 != null)
                {
                    m_p1RaceControl.PlayerData = m_p1.MyClone();
                    m_p1.Dispose();
                    m_p1 = null;
                }
                if (m_p2 != null)
                {
                    m_p2RaceControl.PlayerData = m_p2.MyClone();
                    m_p2.Dispose();
                    m_p2 = null;
                }
                if(m_p3 != null) {
                    m_p3RaceControl.PlayerData = m_p3.MyClone();
                    m_p3.Dispose();
                    m_p3 = null;
                }
            }
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            //Make sure we can't accidentally restart the race or
            //change bets while the players are running
            m_goButton.Enabled = false;
            m_resetButton.Enabled = false;
            m_betButton.Enabled = false;

            //Reset player finish counter
            m_finishCount = 0;

            //Play starting music on this thread (sync)
            m_soundPlayer = new SoundPlayer(Properties.Resources.start_music);
            m_soundPlayer.PlaySync();

            //Start the race!
            m_p1RaceControl.Start();
            m_p2RaceControl.Start();
            m_p3RaceControl.Start();

            //Mark game as running
            m_isRunning = true;

            //Play running music on seperate thread (async)
            m_soundPlayer = new SoundPlayer(Properties.Resources.running_music);
            m_soundPlayer.Play();
        }

        //When each player finishes, this will be called
        public bool PlayerFinish(ref RaceObject player, TimeSpan time)
        {
            //Increment player finish counter
            m_finishCount++;

            //First player to finish is the winner
            bool ret = false;
            if(m_finishCount == 1)
            {
                //Unlock the control buttons
                m_goButton.Enabled = true;
                m_resetButton.Enabled = true;
                m_betButton.Enabled = true;

                //Play the ending music
                m_soundPlayer = new SoundPlayer(Properties.Resources.ending_music);
                m_soundPlayer.Play();

                //Figure out which player has the best odds
                float highOdds = m_p1RaceControl.PlayerData.Odds;
                if (m_p2RaceControl.PlayerData.Odds > highOdds)
                {
                    highOdds = m_p2RaceControl.PlayerData.Odds;
                }
                if (m_p3RaceControl.PlayerData.Odds > highOdds)
                {
                    highOdds = m_p3RaceControl.PlayerData.Odds;
                }

                //And pay the winner based on their odds
                player.Money += (1 + (highOdds - player.Odds)) * player.Bet;
                ret = true;
            }
            else
            {
                //Player lost :( take their bet
                player.Money -= player.Bet;
                if (player.Money <= 0)
                {
                    player.Money = 0;
                    MessageBox.Show(player.Name + " went broke and is out of the race!");
                }
            }


            if (m_finishCount == 3)
            {
                //Mark game as not running
                m_isRunning = false;
            }

            //Update player's track record
            player.Add(ret, time);

            return ret;
        }

        //Retrieve the player data from the RaceControls (for the BettingForm)
        public RaceObject GetPlayer(int playerID)
        {
            if (playerID == 0)
            {
                return m_p1RaceControl.PlayerData;
            } else if (playerID == 1)
            {
                return m_p2RaceControl.PlayerData;
            } else
            {
                return m_p3RaceControl.PlayerData;
            }
        }

        private void RaceForm_Shown(object sender, EventArgs e)
        {
            //Keep our game window from flashing before we select a menu option
            if (m_players == -1)
            {
                this.Hide();
            }
        }

        private void betButton_Click(object sender, EventArgs e)
        {
            //Setup and display the betting form
            BettingForm bf = new BettingForm();
            bf.ConfigForm(this);

            if (bf.ShowDialog() == DialogResult.OK)
            {
                //On OK, retrieve the new bet values
                m_p1RaceControl.PlayerData.Bet = bf.Bet[0];
                m_p2RaceControl.PlayerData.Bet = bf.Bet[1];
                m_p3RaceControl.PlayerData.Bet = bf.Bet[2];
            }
        }

        private void keyForwardButton_KeyUp(object sender, KeyEventArgs e)
        {
            //This hidden button will forward all key events to the proper controls
            //so we can have multiple keys controlling multiple players without
            //worrying about which control has focus
            if (m_isRunning)
            {
                if (e.KeyCode == m_p1RaceControl.PlayerData.MoveKey) //Player 1 is moving
                {
                    m_p1RaceControl.UpdatePosition();
                }
                if (e.KeyCode == m_p2RaceControl.PlayerData.MoveKey) //Player 2 is moving
                {
                    m_p2RaceControl.UpdatePosition();
                }
            }
            else
            {
                if (e.KeyCode == Keys.F1) //F1 = Show main menu
                {
                    this.Hide();
                    //Make sure we start with a fresh menu
                    if (!m_menu.IsDisposed)
                    {
                        m_menu.Dispose();
                        m_menu = null;
                    }
                    //Build a new menu
                    m_menu = new MenuForm();
                    m_menu.FormClosed += new FormClosedEventHandler(StartGame);
                    m_menu.Show();
                }
            }
        }

        private void keyForwardButton_Leave(object sender, EventArgs e)
        {
            //Make sure this button always has focus!!!
            m_keyForwardButton.Focus();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            //Reset the RaceControls, move player back to the beginning
            m_p1RaceControl.Reset();
            m_p2RaceControl.Reset();
            m_p3RaceControl.Reset();
        }
    }
}
