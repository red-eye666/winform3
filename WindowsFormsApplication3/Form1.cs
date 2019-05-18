using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;
namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = saveFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                byte[] exeFile = File.ReadAllBytes(textBox1.Text);
                string strExeFile = Convert.ToBase64String(exeFile);
                File.WriteAllText(textBox2.Text, strExeFile);
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Please fill all fields");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = openFileDialog2.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = saveFileDialog2.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox3.Text != "")
            {
                String strBase64 = File.ReadAllText(textBox4.Text);
                byte[] exeFile = Convert.FromBase64String(strBase64);
                File.WriteAllBytes(textBox3.Text, exeFile);
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Please fill all fields");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            object[] Params = { };
            string vbs1 = @"sub execPowerShell()
Dim objShell
Set objShell=CreateObject(""WScript.Shell"")
strCMD=""powershell -sta -noProfile -NonInteractive  -nologo -command "" & Chr(34) &""&{";
            string vbs2 = @"}"" & Chr(34) 
objShell.Run strCMD,0
end sub";
            MSScriptControl.ScriptControl objSc = new MSScriptControl.ScriptControl();
            objSc.Language = "VBScript";
            objSc.AddCode(vbs1 + textBox5.Text + vbs2);
            objSc.Run("execPowerShell", Params);

        }


    }
}
