﻿using System;
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
            string applicationPath = Application.StartupPath;
            if (File.Exists(applicationPath + "\\Thunderbird\\Thunderbird.exe"))
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
                        sb.Append(" " + CommandLineArgs[i] );
                    }
                }
                if (!File.Exists(applicationPath + "\\Thunderbird\\updates\\Profile.txt"))
                {

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                    String Arguments = File.ReadAllText(applicationPath + "\\Thunderbird\\updates\\Profile.txt") + sb.ToString();
                    if (Arguments.Contains("-profile \"Thunderbird"))
                    {
                        string[] Arguments2 = Arguments.Split(new char[] { '"' }, 3);
                        string Arguments3 = Arguments2[0].Replace("-no-remote ", "") + "\"" + applicationPath + "\\" + Arguments2[1] + "\"" + Arguments2[2];
                        Process.Start(applicationPath + "\\Thunderbird\\Thunderbird.exe", Arguments3);
                    }
                    else
                    {
                        Process.Start(applicationPath + "\\Thunderbird\\Thunderbird.exe", Arguments);
                    }
                }
                else
                {
                    String Arguments = File.ReadAllText(applicationPath + "\\Thunderbird\\updates\\Profile.txt") + sb.ToString();
                    if (File.Exists(applicationPath + "\\Thunderbird\\profile\\extensions.json"))
                    {
                        File.Delete(applicationPath + "\\Thunderbird\\profile\\extensions.json");
                        if (Arguments.Contains("-profile \"Thunderbird"))
                        {
                            string[] Arguments2 = Arguments.Split(new char[] { '"' }, 3);
                            string Arguments3 = Arguments2[0].Replace("-no-remote ", "") + "\"" + applicationPath + "\\" + Arguments2[1] + "\"" + Arguments2[2];
                            Process.Start(applicationPath + "\\Thunderbird\\Thunderbird.exe", Arguments3);
                        }
                        else
                        {
                            Process.Start(applicationPath + "\\Thunderbird\\Thunderbird.exe", Arguments);
                        }
                    }
                    else if (File.Exists(applicationPath + "\\profile\\extensions.json"))
                    {
                        File.Delete(applicationPath + "\\profile\\extensions.json");
                        if (Arguments.Contains("-profile \"Thunderbird"))
                        {
                            string[] Arguments2 = Arguments.Split(new char[] { '"' }, 3);
                            string Arguments3 = Arguments2[0].Replace("-no-remote ", "") + "\"" + applicationPath + "\\" + Arguments2[1] + "\"" + Arguments2[2];
                            Process.Start(applicationPath + "\\Thunderbird\\Thunderbird.exe", Arguments3);
                        }
                        else
                        {
                            Process.Start(applicationPath + "\\Thunderbird\\Thunderbird.exe", Arguments);
                        }
                    }
                    else
                    {
                        if (Arguments.Contains("-profile \"Thunderbird"))
                        {
                            string[] Arguments2 = Arguments.Split(new char[] { '"' }, 3);
                            string Arguments3 = Arguments2[0].Replace("-no-remote ", "") + "\"" + applicationPath + "\\" + Arguments2[1] + "\"" + Arguments2[2];
                            Process.Start(applicationPath + "\\Thunderbird\\Thunderbird.exe", Arguments3);
                        }
                        else
                        {
                            Process.Start(applicationPath + "\\Thunderbird\\Thunderbird.exe", Arguments);
                        }
                    }
                }
            }
            else if (culture1.TwoLetterISOLanguageName == "de")
            {
                 MessageBox.Show("Thunderbird ist nicht installiert", "Thunderbird Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (culture1.TwoLetterISOLanguageName == "ru")
            {
                MessageBox.Show("Mozilla Thunderbird не найден", "Thunderbird Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Thunderbird is not installed", "Thunderbird Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
