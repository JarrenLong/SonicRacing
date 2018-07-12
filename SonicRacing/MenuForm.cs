using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace SonicRacing
{
    public partial class MenuForm : Form
    {
        private int m_menuPos = 0;
        private static Label[] m_opt;

        /// <summary>
        /// Get the user-selected game mode
        /// </summary>
        public int GameMode
        {
            get { return m_menuPos; }
        }

        public MenuForm()
        {
            InitializeComponent();
            //switch/case and if/else blocks are overkill for how these labels will be used
            m_opt = new Label[5] { m_autoLabel, m_p1Label, m_p2Label, m_aboutLabel, m_quitLabel };
        }

        private void MenuForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //Move up one menuitem
                case Keys.Up:
                    //Wrap to bottom
                    if (m_menuPos == 0)
                    {
                        m_menuPos = 4;
                    }
                    else
                    {
                        m_menuPos--;
                    }

                    UpdateSelectedItem();
                    break;
                //Move down one menuitem
                case Keys.Down:
                    //Wrap to top
                    if (m_menuPos == 4)
                    {
                        m_menuPos = 0;
                    }
                    else
                    {
                        m_menuPos++;
                    }

                    UpdateSelectedItem();
                    break;
                //User made selection, close form
                case Keys.Enter:
                    {
                        //Play "select" sound async
                        SoundPlayer sp = new SoundPlayer(Properties.Resources.select);
                        sp.Play();

                        //But pause this thread for a second to make it match the form load times
                        System.Threading.Thread.Sleep(500);

                        //Launch the AboutBox if it's selected
                        if (m_menuPos == 3)
                        {
                            AboutForm about = new AboutForm();
                            about.ShowDialog();
                        }
                        else
                        {
                            //Else close up and move on to the main game
                            this.Close();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        //Highlight the currently selected menuitem
        private void UpdateSelectedItem()
        {
            for (int i = 0; i < 5; i++)
            {
                if (i == m_menuPos)
                {
                    //Make the selected item bold and blue
                    m_opt[i].ForeColor = Color.RoyalBlue;
                    m_opt[i].Font = new Font("Cambria", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
                }
                else
                {
                    //Make the rest of the items normal and white
                    m_opt[i].ForeColor = Color.White;
                    m_opt[i].Font = new Font("Cambria", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
                }
            }
        }
    }
}
