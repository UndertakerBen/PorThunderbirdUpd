using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.IO;

namespace Thunderbird_Stable_x64_Launcher
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
            if (File.Exists(applicationPath + "\\Thunderbird Stable x64\\Thunderbird.exe"))
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
                if (!File.Exists(applicationPath + "\\Thunderbird Stable x64\\updates\\Profile.txt"))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                    String Arguments = File.ReadAllText(applicationPath + "\\Thunderbird Stable x64\\updates\\Profile.txt");
                    if (Arguments.Contains("-profile \"Thunderbird"))
                    {
                        string[] Arguments2 = Arguments.Split(new char[] { '"' }, 3);
                        string Arguments3 = Arguments2[0].Replace("-no-remote ", "") + "\"" + applicationPath + "\\" + Arguments2[1] + "\"" + Arguments2[2];
                        Process.Start(applicationPath + "\\Thunderbird Stable x64\\Thunderbird.exe", Arguments3 + sb.ToString());
                    }
                    else if (Arguments.Contains("-profile \"profile"))
                    {
                        string[] Arguments2 = Arguments.Split(new char[] { '"' }, 3);
                        string Arguments3 = Arguments2[0].Replace("-no-remote ", "") + "\"" + applicationPath + "\\" + Arguments2[1] + "\"" + Arguments2[2];
                        Process.Start(applicationPath + "\\Thunderbird Stable x64\\Thunderbird.exe", Arguments3 + sb.ToString());
                    }
                    else
                    {
                        Process.Start(applicationPath + "\\Thunderbird Stable x64\\Thunderbird.exe", Arguments + sb.ToString());
                    }
                }
                else
                {
                    String Arguments = File.ReadAllText(applicationPath + "\\Thunderbird Stable x64\\updates\\Profile.txt");
                    if (File.Exists(applicationPath + "\\Thunderbird Stable x64\\profile\\extensions.json"))
                    {
                        File.Delete(applicationPath + "\\Thunderbird Stable x64\\profile\\extensions.json");
                        if (Arguments.Contains("-profile \"Thunderbird"))
                        {
                            string[] Arguments2 = Arguments.Split(new char[] { '"' }, 3);
                            string Arguments3 = Arguments2[0].Replace("-no-remote ", "") + "\"" + applicationPath + "\\" + Arguments2[1] + "\"" + Arguments2[2];
                            Process.Start(applicationPath + "\\Thunderbird Stable x64\\Thunderbird.exe", Arguments3 + sb.ToString());
                        }
                        else
                        {
                            Process.Start(applicationPath + "\\Thunderbird Stable x64\\Thunderbird.exe", Arguments + sb.ToString());
                        }
                    }
                    else if (File.Exists(applicationPath + "\\profile\\extensions.json"))
                    {
                        File.Delete(applicationPath + "\\profile\\extensions.json");
                        if (Arguments.Contains("-profile \"profile"))
                        {
                            string[] Arguments2 = Arguments.Split(new char[] { '"' }, 3);
                            string Arguments3 = Arguments2[0].Replace("-no-remote ", "") + "\"" + applicationPath + "\\" + Arguments2[1] + "\"" + Arguments2[2];
                            Process.Start(applicationPath + "\\Thunderbird Stable x64\\Thunderbird.exe", Arguments3 + sb.ToString());
                        }
                        else
                        {
                            Process.Start(applicationPath + "\\Thunderbird Stable x64\\Thunderbird.exe", Arguments + sb.ToString());
                        }
                    }
                    else
                    {
                        if (Arguments.Contains("-profile \"Thunderbird"))
                        {
                            string[] Arguments2 = Arguments.Split(new char[] { '"' }, 3);
                            string Arguments3 = Arguments2[0].Replace("-no-remote ", "") + "\"" + applicationPath + "\\" + Arguments2[1] + "\"" + Arguments2[2];
                            Process.Start(applicationPath + "\\Thunderbird Stable x64\\Thunderbird.exe", Arguments3 + sb.ToString());
                        }
                        else if (Arguments.Contains("-profile \"profile"))
                        {
                            string[] Arguments2 = Arguments.Split(new char[] { '"' }, 3);
                            string Arguments3 = Arguments2[0].Replace("-no-remote ", "") + "\"" + applicationPath + "\\" + Arguments2[1] + "\"" + Arguments2[2];
                            Process.Start(applicationPath + "\\Thunderbird Stable x64\\Thunderbird.exe", Arguments3 + sb.ToString());
                        }
                        else if (Arguments.Contains("-profile \""))
                        {
                            string[] Arguments2 = Arguments.Split(new char[] { '"' }, 3);
                            string Arguments3 = Arguments2[0].Replace("-no-remote ", "") + "\"" + Arguments2[1] + "\"" + Arguments2[2];
                            Process.Start(applicationPath + "\\Thunderbird Stable x64\\Thunderbird.exe", Arguments3 + sb.ToString());
                        }
                        else
                        {
                            Process.Start(applicationPath + "\\Thunderbird Stable x64\\Thunderbird.exe", Arguments);
                        }
                    }
                }
            }
            else if (culture1.TwoLetterISOLanguageName == "de")
            {
                NewMethod(applicationPath, "Thunderbird Stable x64 ist nicht installiert");
            }
            else if (culture1.TwoLetterISOLanguageName == "ru")
            {
                NewMethod(applicationPath, "Mozilla Thunderbird Stable x64 не найден");
            }
            else
            {
                NewMethod(applicationPath, "Thunderbird Stable x64 is not installed");
            }
        }
        private static void NewMethod(string applicationPath, string message)
        {
            if (File.Exists(applicationPath + "\\Thunderbird Stable x64 Launcher.exe"))
            {
                FileVersionInfo launcherVersion = FileVersionInfo.GetVersionInfo(applicationPath + "\\Thunderbird Stable x64 Launcher.exe");
                MessageBox.Show(message + Environment.NewLine + "Launcher Version " + launcherVersion.FileVersion, "Thunderbird Stable x64 Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show(message, "Thunderbird Stable x64 Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
