using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using Microsoft.VisualBasic;
using System.IO;

namespace iCAROS7.DoItSearch.Decktop.CSharp
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        public int Cnt = 0;
        public int Max_Cnt = 1;
        public string[] keywords;
        public Form1()
        {
            InitializeComponent();
            if (Settings.Instance.LoadAtStart == true)
            {
                Keyword.Text = Settings.Instance.Keyword;
                Max_Cnt = Settings.Instance.Max_Cnt;
                loadAtStartToolStripMenuItem.Checked = Settings.Instance.LoadAtStart;
            }
            this.Width = Screen.PrimaryScreen.Bounds.Width / 2;
            this.Height = Screen.PrimaryScreen.Bounds.Height / 2;
        }

        private void Keyword_Click(object sender, EventArgs e)
        {
            // TO DO: later
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int x = Screen.PrimaryScreen.Bounds.Width / 2 - this.Width / 2;
            int y = Screen.PrimaryScreen.Bounds.Height / 2 - this.Height / 2;
            this.Location = new Point(x, y);
        }
        private void OnTick(object sender, EventArgs eventArgs)
        {
            timer1.Interval = rand.Next(1000, Max_Cnt * 1000);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            webBrowser1.Url = new Uri(@"https://twitter.com/search?q=" + HttpUtility.UrlEncode(keywords[Cnt]));
            if (Cnt == keywords.Length -1)
            {
                Cnt = 0;
            }
            else
            {
                Cnt++;
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            keywords = Keyword.Text.Split(',');
            timer1.Enabled = true;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Cnt = 0;
            MessageBox.Show(@"중지 되었습니다!", @"안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void max_intervaltoolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void maxIntervalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string maxIntv = Microsoft.VisualBasic.Interaction.InputBox("검색을 할 사이에 잠깐 기다릴 최대 시간 초를 설정 합니다." + "\n" + "30을 입력하는 경우 1~30초 사이를 무작위로 기다립니다.", "검색 최대 간격 설정");
            try
            {
                Max_Cnt = Int32.Parse(maxIntv);
            }
            catch (FormatException)
            {
                MessageBox.Show(@"숫자로 적어주세요!", @"오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Instance.Max_Cnt = Max_Cnt;
            Settings.Instance.Keyword = Keyword.Text;
            Settings.Instance.LoadAtStart = loadAtStartToolStripMenuItem.Checked;
            Settings.Instance.Save();
            MessageBox.Show(@"저장되었습니다!", @"안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Keyword.Text = Settings.Instance.Keyword;
            Max_Cnt = Settings.Instance.Max_Cnt;
            loadAtStartToolStripMenuItem.Checked = Settings.Instance.LoadAtStart;
            MessageBox.Show(@"불러왔습니다!", @"안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void loadAtStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadAtStartToolStripMenuItem.Checked == true)
            {
                Settings.Instance.LoadAtStart = true;
                saveToolStripMenuItem.PerformClick();
            }
            else
            {
                Settings.Instance.LoadAtStart = false;
                saveToolStripMenuItem.PerformClick();
            }
        }

        private void 사용법ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"가장 앞쪽 하얀 박스에 검색할 텍스트를 입력합니다." + "\n" + 
                @"','(반점, 콤마) 기호를 이력하여 검색어를 구분합니다." + "\n" +
                @"예시 : 트위터,#트위터" + "\n" +"\n" +
                @"검색 최대 간격 버튼을 눌러 검색 최대간격을 설정합니다. 기본적으로 1초입니다." + "\n" + 
                @"시작을 눌러 검색을 시작합니다." + "\n" + "\n" + 
                @"제작 : hominlab@minnote.net", @"도움말", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
