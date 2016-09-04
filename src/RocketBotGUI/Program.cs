using System;
using System.Windows.Forms;

namespace PokemonGo.RocketAPI.Window
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0].ToLower() == "pokerocket://update/")
                    Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\Hen-Ku.DC\\PokémonGO Rocket", "AutoUpdate", true);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm(args));
            }
            //Client client = new Client(new MySettings(), new ApiFailureStrategy());
            //Console.write
            //client.Login.DoLogin();

            //Console.ReadLine();
        }
    }
}