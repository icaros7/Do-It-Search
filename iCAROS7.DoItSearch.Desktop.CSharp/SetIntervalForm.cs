using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCAROS7.DoItSearch.Decktop.CSharp
{
    public partial class SetIntervalForm : Form
    {
        public SetIntervalForm(int Max)
        {
            InitializeComponent();
            textBox1.Text = Convert.ToString(Max);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Question if set interval more than 30 sec
            if (Int32.Parse(textBox1.Text) > 30)
            {
                if (MessageBox.Show(@"입력하신 " + textBox1.Text + @"가 정확합니까?", @"질문", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Number Only Filter
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    // number & BackSpace
            {
                e.Handled = true;
            }
        }

        private void SetIntervalForm_Load(object sender, EventArgs e)
        {
            // Apply Local
            label1.Text = strLang.setInterval_label1;
            label2.Text = strLang.setInterval_label2;
            label3.Text = strLang.setInterval_label3;
            this.Text = strLang.maxIntervalToolStripMenuItem + strLang.Setup;
            button1.Text = strLang.OKBtn;
            button2.Text = strLang.CancelBtn;

            // Foucs to textBox1
            this.ActiveControl = textBox1;
        }
    }
}