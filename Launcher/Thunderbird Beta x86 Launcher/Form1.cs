using System.IO;
using System.Windows.Forms;

namespace Thunderbird_Beta_x86_Launcher
{
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, System.EventArgs e)
        {
            if (radioButton1.Checked)
            {
                File.WriteAllText(@"Thunderbird Beta x86\updates\Profile.txt", "-allow-downgrade -no-remote -profile \"profile\"");
                this.Close();
            }
            if (radioButton2.Checked)
            {
                File.WriteAllText(@"Thunderbird Beta x86\updates\Profile.txt", "-no-remote -profile \"Thunderbird Beta x86\\profile\"");
                this.Close();
            }
            if (radioButton3.Checked)
            {
                File.WriteAllText(@"Thunderbird Beta x86\updates\Profile.txt", "");
                this.Close();
            }
        }
        private void RadioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            MessageBox.Show("Warnung\n\nDiese Option ist nicht Empfohlen\n\nDie Commandline Option \"-allow-downgrade\" wird angefügt\n\nDer Herabstufungsschutz von Thunderbird verhindert das versehentliche Starten von Thunderbird in einem Profil, in dem eine spätere Version von Thunderbird läuft. Je nach den Änderungen zwischen den beiden Versionen sind einige Dateien in einem Profil möglicherweise nicht abwärtskompatibel. Durch das Hinzufügen dieser Option wird der Herabstufungsschutz umgangen.", "Thunderbird Launcher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
