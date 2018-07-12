using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace SonicRacing
{
    /// <summary>
    /// This is my super-duper fancy (gave me something to do for a half hour) splash screen.
    /// All it does is fade into the Sega(tm) logo, play the Sega sound, fade out the logo,
    /// and close. The whole process takes about 7 seconds, and uses one timer and one PictureBox.
    /// </summary>
    public partial class SplashForm : Form
    {
        private bool m_fadeIn = true;
        private int m_fadeAlpha = 256;

        public SplashForm()
        {
            InitializeComponent();
        }

        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            //Fade the image into view
            if (m_fadeIn)
            {
                m_fadeAlpha--;
                if (m_fadeAlpha > 0)
                {
                    SetImageWithAlpha(Properties.Resources.splash, m_fadeAlpha);
                    if (m_fadeAlpha == 32)
                    {
                        SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.sega1);
                        simpleSound.Play();
                    }
                }
                else
                {
                    m_fadeIn = false;
                }
            }
            else //Fade out
            {
                if (m_fadeAlpha == 0)
                {
                    System.Threading.Thread.Sleep(1500);//Give the logo 1.5s before we fade out
                }

                m_fadeAlpha += 2;
                if (m_fadeAlpha <= 256)
                {
                    SetImageWithAlpha(Properties.Resources.splash, m_fadeAlpha);
                }
                else
                {
                    //Close up shop
                    this.Close();
                }
            }
        }

        //This just takes the specified image, adjusts the alpha value, and sends the result to the pictureBox
        private void SetImageWithAlpha(Image img, int alpha)
        {
            using (Graphics g = Graphics.FromImage(img))
            {
                Pen pen = new Pen(Color.FromArgb(alpha%256, 255, 255, 255), img.Width);
                g.DrawLine(pen, -1, -1, img.Width, img.Height);
                g.Save();
            }
            pictureBox1.Image = img;
        }
    }
}
