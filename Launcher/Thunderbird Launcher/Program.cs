using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.IO;

namespace Thunderbird_Launcher
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CultureInfo culture1 = CultureInfo.CurrentUICulture;
            if (File.Exists(@"Thunderbird\Thunderbird.exe"))
            {
                if (!File.Exists(@"Thunderbird\updates\Profile.txt"))
                {
                    if (culture1.Name == "de-DE")
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Form1());
                        String Arguments = File.ReadAllText(@"Thunderbird\updates\Profile.txt");
                        Process.Start(@"Thunderbird\Thunderbird.exe", Arguments);
                    }
                    else
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Form2());
                        String Arguments = File.ReadAllText(@"Thunderbird\updates\Profile.txt");
                        Process.Start(@"Thunderbird\Thunderbird.exe", Arguments);
                    }
                }
                else
                {
                    String Arguments = File.ReadAllText(@"Thunderbird\updates\Profile.txt");
                    if (File.Exists(@"Thunderbird\profile\extensions.json"))
                    {
                        File.Delete(@"Thunderbird\profile\extensions.json");
                        Process.Start(@"Thunderbird\Thunderbird.exe", Arguments);
                    }
                    else if (File.Exists(@"profile\extensions.json"))
                    {
                        File.Delete(@"profile\extensions.json");
                        Process.Start(@"Thunderbird\Thunderbird.exe", Arguments);
                    }
                    else
                    {
                        Process.Start(@"Thunderbird\Thunderbird.exe", Arguments);
                    }
                }
            }
            else if (culture1.Name == "de-DE")
            {
                string message = "Thunderbird ist nicht installiert";
                MessageBox.Show(message, "Thunderbird Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string message = "Thunderbird is not installed";
                 MessageBox.Show(message, "Thunderbird Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
