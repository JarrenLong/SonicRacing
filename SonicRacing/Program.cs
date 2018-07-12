using System;
using System.Windows.Forms;

namespace SonicRacing
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Ok, so we're gonna launch the splash screen first, since it's
            //not tied to the main app in any way (it's completely standalone)
            Application.Run(new SplashForm());

            //Now, start the app
            Application.Run(new GameForm());
        }
    }
}
