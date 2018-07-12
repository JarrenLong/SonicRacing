using System;
using System.Drawing;
using System.Windows.Forms;

namespace SonicRacing
{
    public partial class RaceControl : UserControl
    {
        //This is the callback delegate we'll use when the player finishes his race
        //We'll assign this to a function in the main app that will figure out who
        //the winner is and handle wins/track times/payouts/etc.
        public delegate bool FinishEvent(ref RaceObject player, TimeSpan time);
        public FinishEvent OnFinish;
        //Private fields for this class
        private bool m_bAutoRun = true;
        private DateTime m_startTime;
        private Random m_random;
        private RaceObject m_player;

        #region Public Properties
        //Is this the computer controlling this player?
        public bool Autorun
        {
            get { return m_bAutoRun; }
            set { m_bAutoRun = value; }
        }

        public RaceObject PlayerData
        {
            get { return m_player; }
            set {
                m_player = value;
                //Set the player's tooltip
                string tip = "Name: " + m_player.Name + "\r\n";
                tip += "Money: " + m_player.Money.ToString("c") + "\r\n";
                tip += "Odds: " + m_player.Odds.ToString("p");
                m_toolTip.SetToolTip(this.m_pictureBox, tip);
            }
        }
        #endregion

        /// <summary>
        /// The default constructor
        /// </summary>
        public RaceControl()
        {
            InitializeComponent();

            //Assign default values
            m_bAutoRun = true;
            m_random = new Random();
            m_player = new RaceObject();

            //Set to starting animation and start updating the frames
            m_animationTimer.Enabled = true;
            m_animationTimer.Start();
        }
        /*
        //Borrowed (and tweaked) from: http://msdn.microsoft.com/en-us/library/aa457087.aspx
        public void SetBackgroundImage(Image srcBitmap, Rectangle section)
        {
            try
            {
                //Create the new bitmap and associated graphics object
                Bitmap bmp = new Bitmap(section.Width, section.Height);
                Graphics g = Graphics.FromImage(bmp);
                // Draw the specified section of the source bitmap to the new one
                g.DrawImage(srcBitmap, 0, 0, section, GraphicsUnit.Pixel);
                //Cleanup
                g.Dispose();
                //And draw the new image to the background of this control
                this.BackgroundImage = bmp;
            }
            catch { }
        }
        */
        /// <summary>
        /// We'll call this when we start the race
        /// </summary>
        public void Start()
        {
            Reset();

            //Move to "running" animation
            m_player.ActiveAnimation = 1;

            //Set the start time and seed the random number generator
            m_startTime = DateTime.Now;
            //Because this function is called back-to-back for each player,
            //we'll add a (pseudo)random number to the start time to try to
            //get more variance in the random numbers generated. (Otherwise,
            //we'll only see a difference of 1-2 ticks between each object's seed value)
            m_random = new Random((int)m_startTime.Ticks + (new Random().Next(1, 10000)));

            if (m_bAutoRun)
            {
                //And start the timer (auto mode only)
                m_moveTimer.Enabled = true;
                m_moveTimer.Start();
            }
        }

        public void Reset()
        {
            //Move back to animation 0, frame 0
            m_player.ActiveAnimation = 0;

            //Reset image to beginning of control
            m_pictureBox.SetBounds(0, 0, 128, 128);

            //Update the player's tooltip text
            string tip = "Name: " + m_player.Name + "\r\n";
            tip += "Money: " + m_player.Money.ToString("c") + "\r\n";
            tip += "Odds: " + m_player.Odds.ToString("p");
            m_toolTip.SetToolTip(this.m_pictureBox, tip);

            //Force redraw this control
            this.Refresh();
        }

        //This is an internal function that will be called when this player finishes the race
        //Inside, the timer will be stopped, and the assigned OnFinish() delegate will be executed
        //to see if we won or not
        private void Stop()
        {
            if (m_bAutoRun)
            {
                //Stop the timer
                m_moveTimer.Stop();
                m_moveTimer.Enabled = false;
            }

            //call the OnFinish callback
            if (OnFinish != null)
            {
                //Pass by reference so we can tweak the player bound to this control
                //from the external callback function
                if (OnFinish(ref m_player, DateTime.Now - m_startTime))
                {
                    //Player won! Show the winning animation
                    m_player.ActiveAnimation = 3;
                }
                else
                {
                    //Show "losing" animation
                    m_player.ActiveAnimation = 2;
                }
            }
        }

        /// <summary>
        /// This function will handle the autopilot player's advancement across the track.
        /// All we need to do is update the player's position every time the timer ticks.
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdatePosition();
        }

        /// <summary>
        /// This function handles the sprite animations. This just grabs the next
        /// frame to display every time the timer fires.
        /// </summary>
        private void animationTimer_Tick(object sender, EventArgs e)
        {
            //Update the currently-displayed sprite
            try
            {
                this.m_pictureBox.Image = m_player.Frame;
            }
            catch { }
        }

        /// <summary>
        /// Players can move anywhere from 1-10px per timer interval. When the player
        /// reaches the end of the track, we'll Stop() the player. This method will be
        /// called by timer1_Tick() for autopilot players, and manually from the game form
        /// for regular players.
        /// </summary>
        public void UpdatePosition()
        {
            int pos = m_random.Next(1, 10);
            Rectangle rect = m_pictureBox.Bounds;

            if (rect.X + pos < (this.Width - m_pictureBox.Image.Width))
            {
                //Move forward 1-10px/tick
                m_pictureBox.SetBounds(rect.X + pos, 0, m_pictureBox.Image.Width, m_pictureBox.Image.Height);
            }
            else
            {
                //Player has finished the race, line up image at end of track and Stop()
                //Race isn't considered finished until THE ENTIRE image crosses the finish line
                //(I.E. image X-coord >= finish line X-coord)
                //The RaceControls have been strategically positioned on the main form so it looks
                //like the player is just entering the checkered line when they are marked as done :P
                m_pictureBox.SetBounds(this.Width - m_pictureBox.Image.Width, 0, m_pictureBox.Image.Width, m_pictureBox.Image.Height);
                Stop();
            }
        }

    }
}
