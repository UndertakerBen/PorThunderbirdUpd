using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.IO;

namespace Thunderbird_Beta_x64_Launcher
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
            string applicationPath = Application.StartupPath;
            if (File.Exists(applicationPath + "\\Thunderbird Beta x64\\Thunderbird.exe"))
            {
                var sb = new System.Text.StringBuilder();
                string[] CommandLineArgs = Environment.GetCommandLineArgs();
                for (int i = 1; i < CommandLineArgs.Length; i++)
                {
                    if (CommandLineArgs[i].Contains("="))
                    {
                        string[] test = CommandLineArgs[i].Split(new char[] { '=' }, 2);
                        sb.Append(" " + test[0] + "=\"" + test[1] + "\"");
                    }
                    else if (CommandLineArgs[i].Contains(".eml"))
                    {
                        sb.Append(" " + "\"" + CommandLineArgs[i] + "\"");
                    }
                    else if (CommandLineArgs[i].Contains(".wdseml"))
                    {
                        sb.Append(" " + "\"" + CommandLineArgs[i] + "\"");
                    }
                    else
                    {
                        sb.Append(" " + CommandLineArgs[i]);
                    }
                }
                if (!File.Exists(applicationPath + "\\Thunderbird Beta x64\\updates\\Profile.txt"))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                    String Arguments = File.ReadAllText(applicationPath + "\\Thunderbird Beta x64\\updates\\Profile.txt") + sb.ToString();
                    if (Arguments.Contains("-profile \"Thunderbird"))
                    {
                        string[] Arguments2 = Arguments.Split(new char[] { '"' }, 3);
                        string Arguments3 = Arguments2[0].Replace("-no-remote ", "") + "\"" + applicationPath + "\\" + Arguments2[1] + "\"" + Arguments2[2];
                        Process.Start(applicationPath + "\\Thunderbird Beta x64\\Thunderbird.exe", Arguments3);
                    }
                    else
                    {
                        Process.Start(applicationPath + "\\Thunderbird Beta x64\\Thunderbird.exe", Arguments);
                    }
                }
                else
                {
                    String Arguments = File.ReadAllText(applicationPath + "\\Thunderbird Beta x64\\updates\\Profile.txt") + sb.ToString();
                    if (File.Exists(applicationPath + "\\Thunderbird Beta x64\\profile\\extensions.json"))
                    {
                        File.Delete(applicationPath + "\\Thunderbird Beta x64\\profile\\extensions.json");
                        if (Arguments.Contains("-profile \"Thunderbird"))
                        {
                            string[] Arguments2 = Arguments.Split(new char[] { '"' }, 3);
                            string Arguments3 = Arguments2[0].Replace("-no-remote ", "") + "\"" + applicationPath + "\\" + Arguments2[1] + "\"" + Arguments2[2];
                            Process.Start(applicationPath + "\\Thunderbird Beta x64\\Thunderbird.exe", Arguments3);
                        }
                        else
                        {
                            Process.Start(applicationPath + "\\Thunderbird Beta x64\\Thunderbird.exe", Arguments);
                        }
                    }
                    else if (File.Exists(applicationPath + "\\profile\\extensions.json"))
                    {
                        File.Delete(applicationPath + "\\profile\\extensions.json");
                        if (Arguments.Contains("-profile \"Thunderbird"))
                        {
                            string[] Arguments2 = Arguments.Split(new char[] { '"' }, 3);
                            string Arguments3 = Arguments2[0].Replace("-no-remote ", "") + "\"" + applicationPath + "\\" + Arguments2[1] + "\"" + Arguments2[2];
                            Process.Start(applicationPath + "\\Thunderbird Beta x64\\Thunderbird.exe", Arguments3);
                        }
                        else
                        {
                            Process.Start(applicationPath + "\\Thunderbird Beta x64\\Thunderbird.exe", Arguments);
                        }
                    }
                    else
                    {
                        if (Arguments.Contains("-profile \"Thunderbird"))
                        {
                            string[] Arguments2 = Arguments.Split(new char[] { '"' }, 3);
                            string Arguments3 = Arguments2[0].Replace("-no-remote ", "") + "\"" + applicationPath + "\\" + Arguments2[1] + "\"" + Arguments2[2];
                            Process.Start(applicationPath + "\\Thunderbird Beta x64\\Thunderbird.exe", Arguments3);
                        }
                        else
                        {
                            Process.Start(applicationPath + "\\Thunderbird Beta x64\\Thunderbird.exe", Arguments);
                        }
                    }
                }
            }
            else if (culture1.TwoLetterISOLanguageName == "de")
            {
                MessageBox.Show("Thunderbird Beta x64 ist nicht installiert", "Thunderbird Beta x64 Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (culture1.TwoLetterISOLanguageName == "ru")
            {
                MessageBox.Show("Mozilla Thunderbird Beta x64 не найден", "Thunderbird Beta x64 Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Thunderbird Beta x64 is not installed", "Thunderbird Beta x64 Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
