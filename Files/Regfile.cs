using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thunderbird_Updater.Files
{
    public partial class Regfile
    {
        public static void RegCreate(string applicationPath, string instDir)
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\ThunderbirdMAILTO.PORTABLE");
            key.SetValue(default, "Thunderbird URL");
            key.SetValue("FriendlyTypeName", "Thunderbird URL");
            key.SetValue("EditFlags", 2, Microsoft.Win32.RegistryValueKind.DWord);
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\ThunderbirdMAILTO.PORTABLE\\DefaultIcon");
            key.SetValue(default, applicationPath + @"\" + instDir + @"\thunderbird.exe,0");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\ThunderbirdMAILTO.PORTABLE\\shell\\open\\command");
            key.SetValue(default, "\"" + applicationPath + @"\" + instDir + @" Launcher.exe"" -compose ""%1""");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\ThunderbirdEML.PORTABLE");
            key.SetValue(default, "Thunderbird Document");
            key.SetValue("FriendlyTypeName", "Thunderbird Document");
            key.SetValue("EditFlags", 2, Microsoft.Win32.RegistryValueKind.DWord);
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\ThunderbirdEML.PORTABLE\\DefaultIcon");
            key.SetValue(default, applicationPath + @"\" + instDir + @"\thunderbird.exe,1");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\ThunderbirdEML.PORTABLE\\shell\\open\\command");
            key.SetValue(default, "\"" + applicationPath + @"\" + instDir + @" Launcher.exe"" ""%1""");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\RegisteredApplications");
            key.SetValue("Mozilla Thunderbird.PORTABLE", @"Software\Clients\Mail\Mozilla Thunderbird Portable\Capabilities");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.eml");
            key.SetValue(default, "ThunderbirdEML.PORTABLE");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.eml\\OpenWithProgids");
            key.SetValue("ThunderbirdEML.PORTABLE", "");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\Mail\\Mozilla Thunderbird Portable");
            key.SetValue(default, "Mozilla " + instDir + " Portable");
            key.SetValue("DLLPath", applicationPath + @"\" + instDir + @"\mozMapi32.dll");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\Mail\\Mozilla Thunderbird Portable\\Capabilities");
            key.SetValue("ApplicationDescription", "Thunderbird ist eine komplett ausgestattete E-Mail-Anwendung. Thunderbird unterstützt die IMAP- und POP-Mail-Protokolle ebenso wie HTML-Formatierung. Ein integrierter Junk-Filter, RSS-Unterstützung, leistungsstarke Suchfunktionen, Sofort-Rechtschreibprüfung, Globaler Posteingang und fortgeschrittene Filterfunktionen runden den modernen Funktionsumfang von Thunderbird ab.");
            key.SetValue("ApplicationIcon", applicationPath + @"\" + instDir + @"\thunderbird.exe,0");
            key.SetValue("ApplicationName", instDir + "Portable");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\Mail\\Mozilla Thunderbird Portable\\Capabilities\\FileAssociations");
            key.SetValue(".eml", "ThunderbirdEML.PORTABLE");
            key.SetValue(".wdseml", "ThunderbirdEML.PORTABLE");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\Mail\\Mozilla Thunderbird Portable\\Capabilities\\StartMenu");
            key.SetValue("Mail", "Mozilla Thunderbird Portable");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\Mail\\Mozilla Thunderbird Portable\\Capabilities\\URLAssociations");
            key.SetValue("mailto", "ThunderbirdMAILTO.PORTABLE");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\Mail\\Mozilla Thunderbird Portable\\DefaultIcon");
            key.SetValue(default, applicationPath + @"\" + instDir + @"\thunderbird.exe, 0");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\Mail\\Mozilla Thunderbird Portable\\Protocols\\mailto");
            key.SetValue(default, "Thunderbird URL");
            key.SetValue("FriendlyTypeName", "Thunderbird URL");
            key.SetValue("URL Protocol", "");
            key.SetValue("EditFlags", 2, Microsoft.Win32.RegistryValueKind.DWord);
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\Mail\\Mozilla Thunderbird Portable\\Protocols\\mailto\\DefaultIcon");
            key.SetValue(default, applicationPath + @"\" + instDir + @"\thunderbird.exe, 0");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\Mail\\Mozilla Thunderbird Portable\\Protocols\\mailto\\shell\\open\\command");
            key.SetValue(default, "\"" + applicationPath + @"\" + instDir + @" Launcher.exe"" -compose ""%1""");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\ThunderbirdNEWS.PORTABLE");
            key.SetValue(default, "Thunderbird (News) URL");
            key.SetValue("FriendlyTypeName", "Thunderbird (News) URL");
            key.SetValue("EditFlags", 2, Microsoft.Win32.RegistryValueKind.DWord);
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\ThunderbirdNEWS.PORTABLE\\DefaultIcon");
            key.SetValue(default, applicationPath + @"\" + instDir + @"\thunderbird.exe,0");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\ThunderbirdNEWS.PORTABLE\\shell\\open\\command");
            key.SetValue(default, "\"" + applicationPath + @"\" + instDir + @" Launcher.exe"" -mail ""%1""");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable");
            key.SetValue(default, "Mozilla " + instDir + " Portable");
            key.SetValue("DLLPath", applicationPath + @"\" + instDir + @"\mozMapi32.dll");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Capabilities");
            key.SetValue("ApplicationDescription", "Thunderbird ist eine komplett ausgestattete E-Mail-Anwendung. Thunderbird unterstützt die IMAP- und POP-Mail-Protokolle ebenso wie HTML-Formatierung. Ein integrierter Junk-Filter, RSS-Unterstützung, leistungsstarke Suchfunktionen, Sofort-Rechtschreibprüfung, Globaler Posteingang und fortgeschrittene Filterfunktionen runden den modernen Funktionsumfang von Thunderbird ab.");
            key.SetValue("ApplicationIcon", applicationPath + @"\" + instDir + @"\thunderbird.exe,0");
            key.SetValue("ApplicationName", instDir + "Portable");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Capabilities\\URLAssociations");
            key.SetValue("nntp", "ThunderbirdNEWS.PORTABLE");
            key.SetValue("news", "ThunderbirdNEWS.PORTABLE");
            key.SetValue("snews", "ThunderbirdNEWS.PORTABLE");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Capabilities\\StartMenu");
            key.SetValue("Mail", "Mozilla Thunderbird Portable");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\DefaultIcon");
            key.SetValue(default, applicationPath + @"\" + instDir + @"\thunderbird.exe, 0");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\news");
            key.SetValue(default, "Thunderbird (News) URL");
            key.SetValue("FriendlyTypeName", "Thunderbird (News) URL");
            key.SetValue("URL Protocol", "");
            key.SetValue("EditFlags", 2, Microsoft.Win32.RegistryValueKind.DWord);
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\news\\DefaultIcon");
            key.SetValue(default, applicationPath + @"\" + instDir + @"\thunderbird.exe, 0");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\news\\shell\\open\\command");
            key.SetValue(default, "\"" + applicationPath + @"\" + instDir + @" Launcher.exe"" -mail ""%1""");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\nntp");
            key.SetValue(default, "Thunderbird (News) URL");
            key.SetValue("FriendlyTypeName", "Thunderbird (News) URL");
            key.SetValue("URL Protocol", "");
            key.SetValue("EditFlags", 2, Microsoft.Win32.RegistryValueKind.DWord);
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\nntp\\DefaultIcon");
            key.SetValue(default, applicationPath + @"\" + instDir + @"\thunderbird.exe, 0");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\nntp\\shell\\open\\command");
            key.SetValue(default, "\"" + applicationPath + @"\" + instDir + @" Launcher.exe"" -mail ""%1""");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\snews");
            key.SetValue(default, "Thunderbird (News) URL");
            key.SetValue("FriendlyTypeName", "Thunderbird (News) URL");
            key.SetValue("URL Protocol", "");
            key.SetValue("EditFlags", 2, Microsoft.Win32.RegistryValueKind.DWord);
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\snews\\DefaultIcon");
            key.SetValue(default, applicationPath + @"\" + instDir + @"\thunderbird.exe, 0");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\snews\\shell\\open\\command");
            key.SetValue(default, "\"" + applicationPath + @"\" + instDir + @" Launcher.exe"" -mail ""%1""");
            key.Close();
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\thunderbird.exe");
            key.SetValue(default, "\"" + applicationPath + @"\" + instDir + @" Launcher.exe""");
            key.SetValue("Path", applicationPath);
            key.Close();
            try
            {
                key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", false);
                if (key.GetValue("ProductName").ToString().Contains("Windows 10"))
                {
                    key.Close();
                    Process process = new Process();
                    process.StartInfo.FileName = "ms-settings:defaultapps";
                    process.Start();
                }
                else
                {
                    key.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void RegDel()
        {
            try
            {
                Microsoft.Win32.RegistryKey key;
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\thunderbird.exe", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\Mail\\Mozilla Thunderbird Portable\\Protocols\\mailto\\shell\\open\\command", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\Mail\\Mozilla Thunderbird Portable\\Protocols\\mailto\\shell\\open", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\Mail\\Mozilla Thunderbird Portable\\Protocols\\mailto\\shell", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\Mail\\Mozilla Thunderbird Portable\\Protocols\\mailto\\DefaultIcon", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\Mail\\Mozilla Thunderbird Portable\\Protocols\\mailto", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\Mail\\Mozilla Thunderbird Portable\\Protocols", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\Mail\\Mozilla Thunderbird Portable\\DefaultIcon", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\Mail\\Mozilla Thunderbird Portable\\Capabilities\\URLAssociations", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\Mail\\Mozilla Thunderbird Portable\\Capabilities\\StartMenu", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\Mail\\Mozilla Thunderbird Portable\\Capabilities\\FileAssociations", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\Mail\\Mozilla Thunderbird Portable\\Capabilities", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\Mail\\Mozilla Thunderbird Portable", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\news\\shell\\open\\command", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\news\\shell\\open", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\news\\shell", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\news\\DefaultIcon", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\news", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\nntp\\shell\\open\\command", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\nntp\\shell\\open", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\nntp\\shell", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\nntp\\DefaultIcon", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\nntp", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\snews\\shell\\open\\command", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\snews\\shell\\open", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\snews\\shell", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\snews\\DefaultIcon", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols\\snews", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Protocols", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\DefaultIcon", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Capabilities\\URLAssociations", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Capabilities\\StartMenu", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable\\Capabilities", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Clients\\News\\Mozilla Thunderbird Portable", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\ThunderbirdNEWS.PORTABLE\\shell\\open\\command", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\ThunderbirdNEWS.PORTABLE\\shell\\open", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\ThunderbirdNEWS.PORTABLE\\shell", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\ThunderbirdNEWS.PORTABLE\\DefaultIcon", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\ThunderbirdNEWS.PORTABLE", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\ThunderbirdEML.PORTABLE\\shell\\open\\command", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\ThunderbirdEML.PORTABLE\\shell\\open", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\ThunderbirdEML.PORTABLE\\shell", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\ThunderbirdEML.PORTABLE\\DefaultIcon", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\ThunderbirdEML.PORTABLE", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\ThunderbirdMAILTO.PORTABLE\\shell\\open\\command", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\ThunderbirdMAILTO.PORTABLE\\shell\\open", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\ThunderbirdMAILTO.PORTABLE\\shell", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\ThunderbirdMAILTO.PORTABLE\\DefaultIcon", true);
                Microsoft.Win32.Registry.CurrentUser.DeleteSubKeyTree("SOFTWARE\\Classes\\ThunderbirdMAILTO.PORTABLE", true);
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\RegisteredApplications", true);
                key.DeleteValue("Mozilla Thunderbird.PORTABLE", false);
                key.Close();
                key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\.eml\\OpenWithProgids", true);
                key.DeleteValue("ThunderbirdEML.PORTABLE", false);
                key.Close();
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\.eml");
                key.SetValue(default, "Microsoft Email Message");
                key.Close();
            }
            catch (Exception)
            {

            }
        }

    }
}
