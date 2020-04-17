using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.Collections.Generic;

namespace Thunderbird_Updater
{
    public partial class Form1 : Form
    {
        readonly string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        readonly string applicationPath = Application.StartupPath;
        public static string[] ring = new string[4] { "product=Thunderbird-beta-latest&os=win&lang=", "product=Thunderbird-latest&os=win&lang=", "product=Thunderbird-beta-latest&os=win64&lang=", "product=Thunderbird-latest&os=win64&lang=" };
        public static string[] lang = new string[61] { "sq", "ar", "hy-AM", "ast", "eu", "be", "br", "bg", "ca", "zh-CN", "zh-TW", "hr", "cs", "da", "nl", "en-GB", "en-US", "et", "fi", "fr", "fy-NL", "gd", "gl", "ka", "de", "el", "he", "hu", "is", "id", "ga-IE", "it", "ja", "kab", "cak", "kk", "ko", "lt", "dsb", "ms", "nb-NO", "nn-NO", "pl", "pt-BR", "pt-PT", "ro", "rm", "ru", "sr", "si", "sk", "sl", "es-AR", "es-ES", "sv-SE", "tr", "uk", "hsb", "uz", "vi", "cy" };
        public static string[] instDir = new string[5] { "Thunderbird Beta x86", "Thunderbird Stable x86", "Thunderbird Beta x64", "Thunderbird Stable x64", "Thunderbird" };
        public static string[] entpDir = new string[5] { "Beta86", "Stable86", "Beta64", "Stable64", "Single" };
        public static string[] ring2 = new string[4] { "Beta", "Stable", "Beta", "Stable" };
        public static string[] architektur = new string[2] { "x86", "x64" };
        public static string[] buildversion = new string[4];
        readonly ToolTip toolTip = new ToolTip();
        WebClient myWebClient = new WebClient();
        readonly CultureInfo culture1 = CultureInfo.CurrentUICulture;
        public int comboIndex;
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i <= 1; i++)
            {
                WebRequest myWebRequest = WebRequest.Create("https://download.mozilla.org/?" + ring[i] + "de");
                WebResponse myWebResponse = myWebRequest.GetResponse();
                myWebResponse.Close();
                string version = myWebResponse.ResponseUri.ToString();
                string[] istVersion = version.Substring(version.IndexOf("releases")).Split(new char[] { '/' });
                buildversion[i] = istVersion[1];
                buildversion[i + 2] = istVersion[1];
            }
            label6.Text = buildversion[0];
            label7.Text = buildversion[1];
            comboBox1.SelectedIndex = 24;
            comboIndex = comboBox1.SelectedIndex;
            button11.Enabled = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            if (culture1.Name != "de-DE")
            {
                button12.Text = "Quit";
                button11.Text = "Install all";
                label11.Text = "Install all x86 and or x64";
                checkBox4.Text = "Ignore version check";
                checkBox3.Text = "Create a Folder for each version";
                groupBox3.Text = "Select your desired language";
                checkBox5.Text = "Create a shortcut on the desktop";
                comboBox1.SelectedIndex = 16;
            }
            if (IntPtr.Size != 8)
            {
                button3.Visible = false;
                button4.Visible = false;
                checkBox2.Visible = false;
            }
            if (IntPtr.Size == 8)
            {
                if (File.Exists(@"Thunderbird Beta x64\thunderbird.exe") || File.Exists(@"Thunderbird Stable x64\thunderbird.exe"))
                {
                    checkBox2.Enabled = false;
                }
                if (File.Exists(@"Thunderbird Beta x86\thunderbird.exe") || File.Exists(@"Thunderbird Stable x86\thunderbird.exe"))
                {
                    checkBox1.Enabled = false;
                }
                if (File.Exists(@"Thunderbird Beta x86\thunderbird.exe") || File.Exists(@"Thunderbird Stable x86\thunderbird.exe") || File.Exists(@"Thunderbird Beta x64\thunderbird.exe") || File.Exists(@"Thunderbird Stable x64\thunderbird.exe"))
                {
                    checkBox3.Checked = true;
                    CheckButton();
                }
                else if (!checkBox3.Checked)
                {
                    checkBox1.Enabled = false;
                    checkBox2.Enabled = false;
                    button11.Enabled = false;
                    button11.BackColor = Color.FromArgb(244, 244, 244);

                    if (File.Exists(@"Thunderbird\thunderbird.exe"))
                    {
                        CheckButton2();
                    }
                }
            }
            else if (IntPtr.Size != 8)
            {
                if (File.Exists(@"Thunderbird Beta x86\thunderbird.exe") || File.Exists(@"Thunderbird Stable x86\thunderbird.exe"))
                {
                    checkBox3.Checked = true;
                    checkBox1.Enabled = false;
                    CheckButton();
                }
                else if (!checkBox3.Checked)
                {
                    checkBox1.Enabled = false;
                    button11.Enabled = false;
                    button11.BackColor = Color.FromArgb(244, 244, 244);

                    if (File.Exists(@"Thunderbird\thunderbird.exe"))
                    {
                        CheckButton2();
                    }
                }
            }
            CheckUpdate();
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboIndex = comboBox1.SelectedIndex;
        }
        private async void Button1_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                await NewMethod(0, 0, 0, 1);
            }
            else if (!checkBox3.Checked)
            {
                await NewMethod1(0, 4, 0, 1);
            }
        }
        private async void Button2_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                await NewMethod(0, 1, 1, 2);
            }
            else if (!checkBox3.Checked)
            {
                await NewMethod1(0, 4, 1, 2);
            }
        }
        private async void Button3_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                await NewMethod(1, 2, 2, 3);
            }
            else if (!checkBox3.Checked)
            {
                await NewMethod1(1, 4, 2, 3);
            }
        }
        private async void Button4_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                await NewMethod(1, 3, 3, 4);
            }
            else if (!checkBox3.Checked)
            {
                await NewMethod1(1, 4, 3, 4);
            }
        }
        private async void Button11_Click(object sender, EventArgs e)
        {
            await Testing();
        }
        private async Task Testing()
        {
            if ((!Directory.Exists(@"Thunderbird Beta x86")) && (!Directory.Exists(@"Thunderbird Stable x86")))
            {
                if (checkBox1.Checked)
                {
                    await DownloadFile(0, 0, 0, 1);
                    await DownloadFile(0, 1, 1, 2);
                    checkBox1.Checked = false;
                    checkBox1.Enabled = false;
                }
            }
            await NewMethod2(0, 0, 0, 1);
            await NewMethod2(0, 1, 1, 2);
            if (IntPtr.Size == 8)
            {
                if ((!Directory.Exists(@"Thunderbird Beta x64")) && (!Directory.Exists(@"Thunderbird Stable x64")))
                {
                    if (checkBox2.Checked)
                    {
                        await DownloadFile(1, 2, 2, 3);
                        await DownloadFile(1, 3, 3, 4);
                        checkBox2.Checked = false;
                        checkBox2.Enabled = false;
                    }
                }
                await NewMethod2(1, 2, 2, 3);
                await NewMethod2(1, 3, 3, 4);
            }
        }
        public async Task DownloadFile(int a, int b, int c, int d)
        {
            GroupBox progressBox = new GroupBox
            {
                Location = new Point(10, button12.Location.Y + button12.Height + 5),
                Size = new Size(groupBox3.Width, 90),
                BackColor = Color.Lavender,
            };
            Label title = new Label
            {
                AutoSize = false,
                Location = new Point(2, 10),
                Size = new Size(progressBox.Width - 4, 25),
                Text = "Thunderbird " + ring2[c] + " " + buildversion[c] + " " + architektur[a],
                TextAlign = ContentAlignment.BottomCenter
            };
            title.Font = new Font(title.Font.Name, 9.25F, FontStyle.Bold);
            Label downloadLabel = new Label
            {
                AutoSize = false,
                Location = new Point(5, 35),
                Size = new Size(200, 25),
                TextAlign = ContentAlignment.BottomLeft
            };
            Label percLabel = new Label
            {
                AutoSize = false,
                Location = new Point(progressBox.Size.Width - 105, 35),
                Size = new Size(100, 25),
                TextAlign = ContentAlignment.BottomRight
            };
            ProgressBar progressBarneu = new ProgressBar
            {
                Location = new Point(5, 65),
                Size = new Size(progressBox.Size.Width - 10, 7)
            };
            progressBox.Controls.Add(title);
            progressBox.Controls.Add(downloadLabel);
            progressBox.Controls.Add(percLabel);
            progressBox.Controls.Add(progressBarneu);
            Controls.Add(progressBox);
            List<Task> list = new List<Task>();
            WebRequest myWebRequest = WebRequest.Create("https://download.mozilla.org/?" + ring[c] + lang[comboIndex]);
            WebResponse myWebResponse = myWebRequest.GetResponse();
            Uri uri = new Uri(myWebResponse.ResponseUri.ToString());
            ServicePoint sp = ServicePointManager.FindServicePoint(uri);
            sp.ConnectionLimit = 4;
            myWebResponse.Close();
            using (myWebClient = new WebClient())
            {
                myWebClient.DownloadProgressChanged += (o, args) =>
                {
                    Control[] buttons = Controls.Find("button" + d, true);
                    if (buttons.Length > 0)
                    {
                        Button button = (Button)buttons[0];
                        button.BackColor = Color.Orange;
                    }
                    progressBarneu.Value = args.ProgressPercentage;
                    downloadLabel.Text = string.Format("{0} MB's / {1} MB's",
                        (args.BytesReceived / 1024d / 1024d).ToString("0.00"),
                        (args.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));
                    percLabel.Text = args.ProgressPercentage.ToString() + "%";
                };
                myWebClient.DownloadFileCompleted += (o, args) =>
                {
                    if (args.Cancelled == true)
                    {
                        MessageBox.Show("Download has been canceled.");
                    }
                    else
                    {
                        downloadLabel.Text = culture1.Name != "de-DE" ? "Unpacking" : "Entpacken";
                        string arguments = " x " + "Thunderbird_" + ring2[c] + "_" + buildversion[c] + "_" + architektur[a] + "_" + lang[comboIndex] + ".exe" + " -o" + @"Update\" + entpDir[b] + " -y";
                        Process process = new Process();
                        process.StartInfo.FileName = @"Bin\7zr.exe";
                        process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                        process.StartInfo.Arguments = arguments;
                        process.Start();
                        process.WaitForExit();
                        if (File.Exists(instDir[b] + "\\updates\\Version.log"))
                        {
                            if (checkBox3.Checked)
                            {
                                string[] instVersion = File.ReadAllText(instDir[b] + "\\updates\\Version.log").Split(new char[] { '|' });
                                if (buildversion[c] != instVersion[0])
                                {
                                    NewMethod4(a, b, c);
                                }
                                else if ((buildversion[c] == instVersion[0]) && (checkBox4.Checked))
                                {
                                    NewMethod4(a, b, c);
                                }
                            }
                            else if (!checkBox3.Checked)
                            {
                                NewMethod4(a, b, c);
                            }
                        }
                        else
                        {
                            NewMethod9(a, b, c);
                        }
                    }
                    if (checkBox5.Checked)
                    {
                        if (!File.Exists(deskDir + "\\" + instDir[b] + ".lnk"))
                        {
                            NewMethod5(b);
                        }
                    }
                    if (!File.Exists(@instDir[b] + " Launcher.exe"))
                    {
                        File.Copy(@"Bin\Launcher\" + instDir[b] + " Launcher.exe", @instDir[b] + " Launcher.exe");
                    }
                    File.Delete("Thunderbird_" + ring2[c] + "_" + buildversion[c] + "_" + architektur[a] + "_" + lang[comboIndex] + ".exe");
                    downloadLabel.Text = culture1.Name != "de-DE" ? "Unpacked" : "Entpackt";
                };
                try
                {
                    var task = myWebClient.DownloadFileTaskAsync(uri, "Thunderbird_" + ring2[c] + "_" + buildversion[c] + "_" + architektur[a] + "_" + lang[comboIndex] + ".exe");
                    list.Add(task);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            await Task.WhenAll(list);
            await Task.Delay(2000);
            Controls.Remove(progressBox);
        }
        public void Message1()
        {
            if (culture1.Name != "de-DE")
            {
                MessageBox.Show("The same version is already installed", "Portabel Thunderbird Updater", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                MessageBox.Show("Die selbe Version ist bereits installiert", "Portabel Thunderbird Updater", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        public void CheckButton()
        {
            NewMethod3();
            for (int i = 0; i <= 3; i++)
            {
                if (File.Exists(@instDir[i] + "\\updates\\Version.log"))
                {
                    Control[] buttons = Controls.Find("button" + (i + 1), true);
                    string[] instVersion = File.ReadAllText(@instDir[i] + "\\updates\\Version.log").Split(new char[] { '|' });
                    if (buildversion[i] == instVersion[0])
                    {
                        if (buttons.Length > 0)
                        {
                            Button button = (Button)buttons[0];
                            button.BackColor = Color.Green;
                        }
                    }
                    else if (buildversion[i] != instVersion[0])
                    {
                        if (culture1.Name != "de-DE")
                        {
                            button11.Text = "Update all";
                        }
                        else
                        {
                            button11.Text = "Alle Updaten";
                        }
                        button11.Enabled = true;
                        button11.BackColor = Color.FromArgb(224, 224, 224);
                        if (buttons.Length > 0)
                        {
                            Button button = (Button)buttons[0];
                            button.BackColor = Color.Red;
                        }
                    }
                }
            }
        }
        public void CheckButton2()
        {
            NewMethod3();
            if (File.Exists(@"Thunderbird\updates\Version.log"))
            {
                string[] instVersion = File.ReadAllText(@"Thunderbird\updates\Version.log").Split(new char[] { '|' });
                switch (instVersion[1])
                {
                    case "Beta":
                        NewMethod6(instVersion, 1, 3, 0);
                        break;
                    case "Stable":
                        NewMethod6(instVersion, 2, 4, 1);
                        break;
                }
            }
        }
        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                if ((File.Exists(@"Thunderbird Beta x64\thunderbird.exe")) || (File.Exists(@"Thunderbird Stable x64\thunderbird.exe")))
                {
                    checkBox2.Enabled = false;
                }
                else
                {
                    checkBox2.Enabled = true;
                }
                if ((File.Exists(@"Thunderbird Beta x86\thunderbird.exe")) || (File.Exists(@"Thunderbird Stable x86\thunderbird.exe")))
                {
                    checkBox1.Enabled = false;
                }
                else
                {
                    checkBox1.Enabled = true;
                }
                if (button11.Enabled)
                {
                    button11.BackColor = Color.FromArgb(224, 224, 224);
                }
                CheckButton();
            }
            if (!checkBox3.Checked)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                button11.Enabled = false;
                button11.BackColor = Color.FromArgb(244, 244, 244);
                CheckButton2();
            }
        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button11.Enabled = true;
                button11.BackColor = Color.FromArgb(224, 224, 224);
            }
            else if ((!checkBox1.Checked) && (!checkBox2.Checked))
            {
                button11.Enabled = false;
                button11.BackColor = Color.FromArgb(244, 244, 244);
            }
        }
        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                button11.Enabled = true;
                button11.BackColor = Color.FromArgb(224, 224, 224);
            }
            else if ((!checkBox1.Checked) && (!checkBox2.Checked))
            {
                button11.Enabled = false;
                button11.BackColor = Color.FromArgb(244, 244, 244);
            }
        }
        private void Button12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Directory.Exists(@"Update"))
            {
                Directory.Delete(@"Update", true);
            }
        }
        private void Button1_MouseHover(object sender, EventArgs e)
        {
            NewMethod7(0, "x86", 1);
        }
        private void Button2_MouseHover(object sender, EventArgs e)
        {
            NewMethod7(1, "x86", 2);
        }
        private void Button3_MouseHover(object sender, EventArgs e)
        {
            NewMethod7(2, "x64", 3);
        }
        private void Button4_MouseHover(object sender, EventArgs e)
        {
            NewMethod7(3, "x64", 4);
        }
        private void Button11_EnabledChanged(object sender, EventArgs e)
        {
            if (!button11.Enabled)
            {
                button11.BackColor = Color.FromArgb(244, 244, 244);
            }
        }
        private async Task NewMethod(int a, int b, int c, int d)
        {
            if (File.Exists(@instDir[b] + "\\updates\\Version.log"))
            {
                string[] instVersion = File.ReadAllText(@instDir[b] + "\\updates\\Version.log").Split(new char[] { '|' });
                if (instVersion[0] == buildversion[c])
                {
                    if (checkBox4.Checked)
                    {
                        await DownloadFile(a, b, c, d);
                    }
                    else
                    {
                        Message1();
                    }
                }
                else
                {
                    await DownloadFile(a, b, c, d);
                }
            }
            else
            {
                await DownloadFile(a, b, c, d);
            }
        }
        private async Task NewMethod1(int a, int b, int c, int d)
        {
            if (File.Exists(@"Thunderbird\updates\Version.log"))
            {
                string[] instVersion = File.ReadAllText(@"Thunderbird\updates\Version.log").Split(new char[] { '|' });
                if ((instVersion[0] == buildversion[c]) && (instVersion[1] == ring[c]) && (instVersion[2] == architektur[a]))
                {
                    if (checkBox4.Checked)
                    {
                        await DownloadFile(a, b, c, d);
                    }
                    else
                    {
                        Message1();
                    }
                }
                else
                {
                    await DownloadFile(a, b, c, d);
                }
            }
            else
            {
                await DownloadFile(a, b, c, d);
            }
        }
        private async Task NewMethod2(int a, int b, int c, int d)
        {
            if (Directory.Exists(instDir[b]))
            {
                if (File.Exists(@instDir[b] + "\\updates\\Version.log"))
                {
                    string[] instVersion = File.ReadAllText(@instDir[b] + "\\updates\\Version.log").Split(new char[] { '|' });
                    if (instVersion[0] != buildversion[c])
                    {
                        await DownloadFile(a, b, c, d);
                    }
                }
            }
        }
        private void NewMethod3()
        {
            for (int i = 1; i <= 4; i++)
            {
                Control[] buttons = Controls.Find("button" + i, true);
                if (buttons.Length > 0)
                {
                    Button button = (Button)buttons[0];
                    button.BackColor = Color.FromArgb(224, 224, 224);
                }
            }
        }
        private void NewMethod4(int a, int b, int c)
        {
            if (Directory.Exists(instDir[b] + "\\updates"))
            {
                Directory.Move(instDir[b] + "\\Updates", @"Update\" + entpDir[b] + "\\core\\updates");
            }
            if (Directory.Exists(instDir[b] + "\\profile"))
            {
                Directory.Move(instDir[b] + "\\profile", @"Update\" + entpDir[b] + "\\core\\profile");
            }
            Thread.Sleep(2000);
            if (Directory.Exists(instDir[b]))
            {
                Directory.Delete(instDir[b], true);
            }
            Thread.Sleep(2000);
            NewMethod9(a, b, c);
        }
        private void NewMethod5(int b)
        {
            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut link = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(deskDir + "\\" + instDir[b] + ".lnk");
            link.IconLocation = applicationPath + "\\" + instDir[b] + "\\thunderbird.exe,0";
            link.WorkingDirectory = applicationPath;
            link.TargetPath = applicationPath + "\\" + instDir[b] + " Launcher.exe";
            link.Save();
        }
        private void NewMethod6(string[] instVersion, int a, int b, int c)
        {
            Control[] buttons = Controls.Find("button" + a, true);
            Control[] buttons2 = Controls.Find("button" + b, true);
            if (instVersion[0] == buildversion[c])
            {
                if (instVersion[2] == "x86")
                {
                    if (buttons.Length > 0)
                    {
                        Button button = (Button)buttons[0];
                        button.BackColor = Color.Green;
                    }
                }
                else if (instVersion[2] == "x64")
                {
                    if (buttons2.Length > 0)
                    {
                        Button button = (Button)buttons2[0];
                        button.BackColor = Color.Green;
                    }
                }
            }
            else if (instVersion[0] != buildversion[c])
            {
                if (instVersion[2] == "x86")
                {
                    if (buttons.Length > 0)
                    {
                        Button button = (Button)buttons[0];
                        button.BackColor = Color.Red;
                    }
                }
                else if (instVersion[2] == "x64")
                {
                    if (buttons2.Length > 0)
                    {
                        Button button = (Button)buttons2[0];
                        button.BackColor = Color.Red;
                    }
                }
            }
        }
        private void NewMethod7(int a, string arch, int b)
        {
            Control[] buttons = Controls.Find("button" + (b), true);
            Button button = (Button)buttons[0];
            if (!checkBox3.Checked)
            {
                if (File.Exists(@"Thunderbird\updates\Version.log"))
                {
                    NewMethod8(a, arch, button, File.ReadAllText(@"Thunderbird\updates\Version.log").Split(new char[] { '|' }));
                }
            }
            if (checkBox3.Checked)
            {
                if (File.Exists(instDir[a] + "\\updates\\Version.log"))
                {
                    NewMethod8(a, arch, button, File.ReadAllText(instDir[a] + "\\updates\\Version.log").Split(new char[] { '|' }));
                }
            }
        }
        private void NewMethod8(int a, string arch, Button button, string[] instVersion)
        {
            if ((instVersion[1] == ring2[a]) && (instVersion[2] == arch))
            {
                toolTip.SetToolTip(button, instVersion[0]);
                toolTip.IsBalloon = true;
            }
            else
            {
                toolTip.SetToolTip(button, String.Empty);
            }
        }
        private void NewMethod9(int a, int b, int c)
        {
            Directory.Move(@"Update\" + entpDir[b] + "\\core", instDir[b]);
            if (!Directory.Exists(instDir[b] + "\\updates"))
            {
                Directory.CreateDirectory(instDir[b] + "\\updates");
            }
            File.WriteAllText(instDir[b] + "\\updates\\Version.log", buildversion[c] + "|" + ring2[c] + "|" + architektur[a]);
            Directory.Delete(@"Update\" + entpDir[b], true);
            if (checkBox3.Checked)
            {
                CheckButton();
            }
            else if (!checkBox3.Checked)
            {
                CheckButton2();
            }
        }
        private void CheckUpdate()
        {
            GroupBox groupBoxupdate = new GroupBox
            {
                Location = new Point(groupBox3.Location.X, button12.Location.Y + button12.Size.Height + 5),
                Size = new Size(groupBox3.Width, 90),
                BackColor = Color.Aqua
            };
            Label versionLabel = new Label
            {
                AutoSize = false,
                TextAlign = ContentAlignment.BottomCenter,
                Dock = DockStyle.None,
                Location = new Point(2, 30),
                Size = new Size(groupBoxupdate.Width - 4, 25),
            };
            versionLabel.Font = new Font(versionLabel.Font.Name, 10F, FontStyle.Bold);
            Label infoLabel = new Label
            {
                AutoSize = false,
                TextAlign = ContentAlignment.BottomCenter,
                Dock = DockStyle.None,
                Location = new Point(2, 10),
                Size = new Size(groupBoxupdate.Width - 4, 20),
                Text = "Eine neue Version ist verfügbar"
            };
            infoLabel.Font = new Font(infoLabel.Font.Name, 8.75F);
            Label downLabel = new Label
            {
                TextAlign = ContentAlignment.MiddleRight,
                AutoSize = false,
                Size = new Size(100, 23),
                Text = "Jetzt Updaten"
            };
            Button laterButton = new Button
            {
                Text = "Nein",
                Size = new Size(40, 23),
                BackColor = Color.FromArgb(224, 224, 224)
            };
            Button updateButton = new Button
            {
                Location = new Point(groupBoxupdate.Width - Width - 10, 60),
                Text = "Ja",
                Size = new Size(40, 23),
                BackColor = Color.FromArgb(224, 224, 224)
            };
            updateButton.Location = new Point(groupBoxupdate.Width - updateButton.Width - 10, 60);
            laterButton.Location = new Point(updateButton.Location.X - laterButton.Width - 5, 60);
            downLabel.Location = new Point(laterButton.Location.X - downLabel.Width - 20, 60);
            groupBoxupdate.Controls.Add(updateButton);
            groupBoxupdate.Controls.Add(laterButton);
            groupBoxupdate.Controls.Add(downLabel);
            groupBoxupdate.Controls.Add(infoLabel);
            groupBoxupdate.Controls.Add(versionLabel);
            updateButton.Click += new EventHandler(UpdateButton_Click);
            laterButton.Click += new EventHandler(LaterButton_Click);
            if (culture1.Name != "de-DE")
            {
                infoLabel.Text = "A new version is available";
                laterButton.Text = "No";
                updateButton.Text = "Yes";
                downLabel.Text = "Update now";
            }
            void LaterButton_Click(object sender, EventArgs e)
            {
                groupBoxupdate.Dispose();
                Controls.Remove(groupBoxupdate);
                groupBox3.Enabled = true;
            }
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                var request = (WebRequest)HttpWebRequest.Create("https://github.com/UndertakerBen/PorThunderbirdUpd/raw/master/Version.txt");
                var response = request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var version = reader.ReadToEnd();
                    versionLabel.Text = version;
                    FileVersionInfo testm = FileVersionInfo.GetVersionInfo(applicationPath + "\\Portable Thunderbird Updater.exe");
                    if (Convert.ToDecimal(version) > Convert.ToDecimal(testm.FileVersion))
                    {
                        Controls.Add(groupBoxupdate);
                        groupBox3.Enabled = false;
                    }
                    reader.Close();
                }
            }
            catch (Exception)
            {

            }
            void UpdateButton_Click(object sender, EventArgs e)
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var request2 = (WebRequest)HttpWebRequest.Create("https://github.com/UndertakerBen/PorThunderbirdUpd/raw/master/Version.txt");
                var response2 = request2.GetResponse();
                using (StreamReader reader = new StreamReader(response2.GetResponseStream()))
                {
                    var version = reader.ReadToEnd();
                    reader.Close();
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    using (WebClient myWebClient2 = new WebClient())
                    {
                        myWebClient2.DownloadFile($"https://github.com/UndertakerBen/PorThunderbirdUpd/releases/download/v{version}/Portable.Thunderbird.Updater.v{version}.7z", @"Portable.Thunderbird.Updater.v" + version + ".7z");
                    }
                    File.AppendAllText(@"Update.cmd", "@echo off" + "\n" +
                        "timeout /t 1 /nobreak" + "\n" +
                        "\"" + applicationPath + "\\Bin\\7zr.exe\" e \"" + applicationPath + "\\Portable.Thunderbird.Updater.v" + version + ".7z\" -o\"" + applicationPath + "\" \"Portable Thunderbird Updater.exe\"" + " -y\n" +
                        "call cmd /c Start /b \"\" " + "\"" + applicationPath + "\\Portable Thunderbird Updater.exe\"\n" +
                        "del /f /q \"" + applicationPath + "\\Portable.Thunderbird.Updater.v" + version + ".7z\"\n" +
                        "del /f /q \"" + applicationPath + "\\Update.cmd\" && exit\n" +
                        "exit\n");

                    string arguments = " /c call Update.cmd";
                    Process process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = arguments;
                    process.Start();
                    Close();
                }
            }
        }
    }
}
