using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.IO;

namespace Thunderbird_Beta_x86_Launcher
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
            if (File.Exists(@"Thunderbird Beta x86\Thunderbird.exe"))
            {
                if (!File.Exists(@"Thunderbird Beta x86\updates\Profile.txt"))
                {
                    if (culture1.Name == "de-DE")
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Form1());
                        String Arguments = File.ReadAllText(@"Thunderbird Beta x86\updates\Profile.txt");
                        _ = Process.Start(@"Thunderbird Beta x86\Thunderbird.exe", Arguments);
                    }
                    else
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Form2());
                        String Arguments = File.ReadAllText(@"Thunderbird Beta x86\updates\Profile.txt");
                        _ = Process.Start(@"Thunderbird Beta x86\Thunderbird.exe", Arguments);
                    }
                }
                else
                {
                    String Arguments = File.ReadAllText(@"Thunderbird Beta x86\updates\Profile.txt");
                    if (File.Exists(@"Thunderbird Beta x86\profile\extensions.json"))
                    {
                        File.Delete(@"Thunderbird Beta x86\profile\extensions.json");
                        Process.Start(@"Thunderbird Beta x86\Thunderbird.exe", Arguments);
                    }
                    else if (File.Exists(@"profile\extensions.json"))
                    {
                        File.Delete(@"profile\extensions.json");
                        Process.Start(@"Thunderbird Beta x86\Thunderbird.exe", Arguments);
                    }
                    else
                    {
                        Process.Start(@"Thunderbird Beta x86\Thunderbird.exe", Arguments);
                    }
                }
            }
            else if (culture1.Name == "de-DE")
            {
                string message = "Thunderbird Beta x86 ist nicht installiert";
                _ = MessageBox.Show(message, "Thunderbird Beta x86 Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string message = "Thunderbird Beta x86 is not installed";
                _ = MessageBox.Show(message, "Thunderbird Beta x86 Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
