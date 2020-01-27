﻿using System.IO;
using System.Windows.Forms;

namespace Thunderbird_Beta_x64_Launcher
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            if (radioButton1.Checked)
            {
                File.WriteAllText(@"Thunderbird Beta x64\updates\Profile.txt", "-allow-downgrade -no-remote -profile \"profile\"");
                this.Close();
            }
            if (radioButton2.Checked)
            {
                File.WriteAllText(@"Thunderbird Beta x64\updates\Profile.txt", "-no-remote -profile \"Thunderbird Beta x64\\profile\"");
                this.Close();
            }
            if (radioButton3.Checked)
            {
                File.WriteAllText(@"Thunderbird Beta x64\updates\Profile.txt", "");
                this.Close();
            }
        }
        private void RadioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            MessageBox.Show("Warning\n\nThis option is not recommended\n\nThe commandline option \"-allow-downgrade\" will be added.\n\nThunderbird downgrade protection prevents accidentally starting Thunderbird in a profile running a later version of Thunderbird. Depending on changes between the two versions, some files in a profile may not be downwards compatible. Adding this option bypasses downgrade protection.", "Thunderbird Launcher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
