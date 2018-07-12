using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SonicRacing
{
    public class RaceObject : IDisposable
    {
        private float m_money;
        private int m_bet;
        private int m_activeSpriteX;
        private int m_activeSpriteY;
        private int[] m_tileMap;
        private bool[] m_loopMap;
        private string m_name;
        private Keys m_moveKey;
        private Image m_spriteMap = null;
        private Bitmap m_lastImage = null;
        private List<TrackRecord> m_recordList = null;

        #region Properties
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public float Money
        {
            get { return m_money; }
            set { m_money = value; }
        }

        public int Bet
        {
            get { return m_bet; }
            set { m_bet = value; }
        }

        public float Odds
        {
            get
            {
                if (m_recordList.Count > 0)
                {
                    //Count number of wins for this player
                    int wins = 0;
                    foreach (TrackRecord tr in m_recordList)
                    {
                        if (tr.Won)
                        {
                            wins++;
                        }
                    }
                    // wins/races = win percentage (odds)
                    return (float)wins / m_recordList.Count;
                }
                //We have no records
                return 0;
            }
        }

        public Keys MoveKey
        {
            get { return m_moveKey; }
            set { m_moveKey = value; }
        }

        public int ActiveAnimation
        {
            get { return m_activeSpriteY; }
            set { m_activeSpriteY = value; m_activeSpriteX = 0; }
        }

        public Bitmap Frame
        {
            get {
                //Quick bounds check to avoid IndexOutOfRange exception on restart
                if (m_activeSpriteY >= m_loopMap.Length)
                {
                    m_activeSpriteY = 0;
                }

                //If this is a looping animation, rollback to first frame when we get to the end
                if (m_loopMap[m_activeSpriteY])
                {
                    m_activeSpriteX++;
                    if (m_activeSpriteX == m_tileMap[m_activeSpriteY])
                    {
                        m_activeSpriteX = 0;
                    }
                }
                else
                {
                    //Else stop at the last frame
                    if (m_activeSpriteX < m_tileMap[m_activeSpriteY])
                    {
                        m_activeSpriteX++;
                    }
                }
                //Memory saver for non-loping animations, just return the last frame
                //if we're at the end of the list
                if (m_activeSpriteX == m_tileMap[m_activeSpriteY])
                {
                    return m_lastImage;
                }

                //Extract the next frame from the sprite map and return it as a Bitmap
                m_lastImage = new Bitmap(128, 128);

                // Draw the specified section of the source bitmap to the new one
                //This is the same code as SetBackgroundImage() in the RaceControl class
                Graphics g = Graphics.FromImage(m_lastImage);
                g.DrawImage(m_spriteMap, 0, 0,
                    new Rectangle(m_activeSpriteX*128, m_activeSpriteY*128, 128, 128),
                    GraphicsUnit.Pixel);
                g.Dispose();

                return m_lastImage;
            }
        }
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public RaceObject()
        {
            m_money = 0;
            m_activeSpriteX = 0;
            m_activeSpriteY = 0;
            m_tileMap = new int[8];
            m_loopMap = new bool[8];
            m_name = "";
            m_moveKey = Keys.None;
            m_spriteMap = Properties.Resources.sonic_map;
            m_recordList = new List<TrackRecord>();
        }

        //Specify what sprite map this object will use for animation
        public void SetSpriteMap(Image map, int[] frames, bool[] looping)
        {
            m_activeSpriteX = 0;
            m_activeSpriteY = 0;
            m_spriteMap = map;
            m_tileMap = frames;
            m_loopMap = looping;
        }

        //Add new track record to our object
        public void Add(bool wonRace, TimeSpan trackTime)
        {
            m_recordList.Add(new TrackRecord(wonRace, trackTime));
            //Odds will be recalculated when the Odds property is requested

            //Coincidentally, this only gets called when the player finishes
            //the race, so this is a good place to reset our frame counters
            //back to default
            m_activeSpriteX = 0;
            m_activeSpriteY = 0;
        }

        //For use later: Use for storing object data in a text file
        //This could be tweaked to use serialized object data, XML files,
        //databases, or ____ data storage methods, so long as the result is
        //returned as a string.
        public override string ToString()
        {
            string ret = "";

            ret += m_name + ",";
            ret += m_money + ",";
            ret += m_moveKey + ",";
            ret += m_activeSpriteX + ",";
            ret += m_activeSpriteY + ",";
            ret += m_spriteMap + ",";
            ret += m_tileMap + ",";

            foreach (TrackRecord tr in m_recordList)
            {
                ret += tr.ToString() + "-";
            }

            return ret;
        }

        //Perform a deep copy clone of this object
        public RaceObject MyClone()
        {
            //Copy all primitive types into the new object
            RaceObject clone = (RaceObject)this.MemberwiseClone();
            //Copy our object data across (don't clone, that causes null reference problems)
            clone.m_spriteMap = (Image)this.m_spriteMap;
            clone.m_lastImage = (Bitmap)this.m_lastImage;
            clone.m_moveKey = (Keys)this.m_moveKey;

            //Copy the list into the new object
            foreach(TrackRecord tr in this.m_recordList) {
                clone.Add(tr.Won, tr.Time);
            }

            //Return the clone of this object
            return clone;
        }

        //Make sure we cleanup on disposal
        public void Dispose()
        {
            if (m_recordList != null)
            {
                m_recordList.Clear();
                m_recordList = null;
            }
        }

        /// <summary>
        /// This class will just keep track of player wins/losses
        /// and track times for each race.
        /// </summary>
        internal class TrackRecord
        {
            private bool m_win;
            private TimeSpan m_time;

            #region Properties
            public bool Won
            {
                get { return m_win; }
            }

            public TimeSpan Time
            {
                get { return m_time; }
                set { m_time = value; }
            }
            #endregion

            #region Constructors
            public TrackRecord()
            {
                m_win = false;
            }

            public TrackRecord(bool win, TimeSpan time)
            {
                m_win = win;
                m_time = time;
            }
            #endregion

            public override string ToString()
            {
                return (m_win.ToString() + ":" + m_time.ToString());
            }

            public void FromString(string data)
            {
                string[] buf = data.Split(new char[] { ':' });
                m_win = bool.Parse(buf[0]);
                m_time = TimeSpan.Parse(buf[1]);
            }
        };
    }
}
